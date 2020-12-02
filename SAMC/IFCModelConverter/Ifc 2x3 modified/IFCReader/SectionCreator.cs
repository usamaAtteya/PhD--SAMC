using SAMC2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;

namespace IFCModelConverter.Ifc_2x3_modified.IFCReader
{
    class SectionCreator
    {
        public static Section Create(IIfcStructuralMember strMember)
     => new Section() { Profile = GetSectionProfile(strMember), Material = GetStrMemberMaterial(strMember) };

        static SectionProfile GetSectionProfile(IIfcRectangleProfileDef rectProfile)
  => new RecangularProfile() { Depth = rectProfile.YDim, Width = rectProfile.XDim, SectionProfileName = rectProfile.ProfileName };
        static SectionProfile GetSectionProfile(IIfcIShapeProfileDef iShapProfile)
        {
            var retSec = new IShapeProfile() { SectionProfileName = iShapProfile.ProfileName, OverallHeight = iShapProfile.OverallDepth, WebThickness = iShapProfile.WebThickness };
            if (iShapProfile is IIfcAsymmetricIShapeProfileDef)
            {
                var asymmetricIShape = (IIfcAsymmetricIShapeProfileDef)iShapProfile;

                retSec.BottomFlangeThickness = asymmetricIShape.BottomFlangeThickness;
                retSec.BottomFlangeFilletRadius = Convert.ToDouble(asymmetricIShape.BottomFlangeFilletRadius?.Value ?? 0);
                retSec.BottomFlangeWidth = asymmetricIShape.BottomFlangeWidth;
                retSec.BottomFlangeEdgeRadius = Convert.ToDouble(asymmetricIShape.BottomFlangeEdgeRadius?.Value ?? 0);
                retSec.TopFlangeThickness = Convert.ToDouble(asymmetricIShape.TopFlangeThickness?.Value ?? 0);
                retSec.TopFlangeFilletRadius = Convert.ToDouble(asymmetricIShape.TopFlangeFilletRadius?.Value ?? 0);
                retSec.TopFlangeWidth = asymmetricIShape.TopFlangeWidth;
                retSec.TopFlangeEdgeRadius = Convert.ToDouble(asymmetricIShape.TopFlangeEdgeRadius?.Value ?? 0);
            }
            else
            {
                retSec.BottomFlangeThickness = retSec.TopFlangeThickness = iShapProfile.FlangeThickness;
                retSec.BottomFlangeWidth = retSec.TopFlangeWidth = iShapProfile.OverallWidth;
                retSec.BottomFlangeFilletRadius = retSec.TopFlangeFilletRadius = iShapProfile.FilletRadius;
                retSec.BottomFlangeEdgeRadius = retSec.TopFlangeEdgeRadius = iShapProfile.FlangeEdgeRadius;
            }
            return retSec;
        }
        static SectionProfile GetSectionProfile(IIfcStructuralSurfaceMember surfaceMember)
  => new AreaSectionProfile() { SectionProfileName = $"{Enum.GetName(typeof(IfcStructuralSurfaceMemberTypeEnum) , surfaceMember.PredefinedType)}-{Math.Round(surfaceMember.Thickness.Value,5)} ", Thickness = surfaceMember.Thickness.Value };
        static SectionProfile GetSectionProfile(IIfcStructuralCurveMember curveMember)
        {
            var sectionAsssoc = curveMember.HasAssociations.FirstOrDefault(a => a is Xbim.Ifc2x3.Interfaces.IIfcRelAssociatesProfileProperties) as Xbim.Ifc2x3.Interfaces.IIfcRelAssociatesProfileProperties;
            var profProps = sectionAsssoc?.RelatingProfileProperties as Xbim.Ifc2x3.Interfaces.IIfcStructuralProfileProperties;
            if (profProps != null)
            {


                if (profProps.ProfileDefinition is IIfcRectangleProfileDef)
                    return GetSectionProfile((IIfcRectangleProfileDef)profProps.ProfileDefinition);
                else if (profProps.ProfileDefinition is IIfcIShapeProfileDef)
                    return GetSectionProfile((IIfcIShapeProfileDef)profProps.ProfileDefinition);
            }
            //throw new Exception("Not Implemented Frame Section");
            return null;
        }
        static SectionProfile GetSectionProfile(IIfcStructuralMember strMmeber)
          => strMmeber is IIfcStructuralCurveMember ? GetSectionProfile((IIfcStructuralCurveMember)strMmeber) : GetSectionProfile((IIfcStructuralSurfaceMember)strMmeber);


        static Material GetStrMemberMaterial(IIfcStructuralItem strItem)
        {
            var ifcMaterial = strItem.HasAssociations.OfType<IIfcRelAssociatesMaterial>().Select(r => r.RelatingMaterial).OfType<IIfcMaterial>().FirstOrDefault();
            if (ifcMaterial == null)
                return null;
            var ifcMaterialCategory = ifcMaterial.Category == null ? "" : ifcMaterial.Category.ToString().ToUpper();
            var material = new Material() { Name = ifcMaterial.Name, Type = ifcMaterialCategory.Contains("CONCRETE") ? MaterialType.Concrete : ifcMaterialCategory.Contains("STEEL") ? MaterialType.Steel : MaterialType.Other };
            var mechanicalProps = strItem.Model.Instances.OfType<Xbim.Ifc2x3.Interfaces.IIfcMechanicalMaterialProperties>().FirstOrDefault(p => p.Material.Name.Equals(material.Name));
            if (mechanicalProps != null)
            {
                material.PoissonRatio = Convert.ToDouble(mechanicalProps.PoissonRatio?.Value ?? 0);
                material.ShearModulus = Convert.ToDouble(mechanicalProps.ShearModulus?.Value ?? 0);
                material.ThermalExpanssionC = Convert.ToDouble(mechanicalProps.ThermalExpansionCoefficient?.Value ?? 0);
                material.YoungModulus = Convert.ToDouble(mechanicalProps.YoungModulus?.Value ?? 0);
            }
            var generalProps = strItem.Model.Instances.OfType<Xbim.Ifc2x3.Interfaces.IIfcGeneralMaterialProperties>().FirstOrDefault(p => p.Material.Name.Equals(material.Name));
            if (generalProps != null)

                if (generalProps.MassDensity != null)
                {
                    var projUnits = UnitsCreator.GetProjectUnits(strItem.Model.Instances.OfType<IIfcProject>().First() );
                    material.SetWeightDensityByMassDensity(generalProps.MassDensity.Value, projUnits.LengthUnit);
                }


            return material;
        }
    }
}
