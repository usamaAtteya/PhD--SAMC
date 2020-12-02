using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc;
using SAMC2.ModelConverter;

namespace IFCModelConverter.Ifc_2x3_modified.IFCReader
{
    public class IFCModelReader:IModelReader
    {

        IfcStore _ifcModel;
        public IFCModelReader()
        {

        }
        public Model GetModel(string filePath)
        {
            _ifcModel = IfcStore.Open(filePath);
            var units = UnitsCreator.GetProjectUnits(_ifcModel);
            var strElements = ElementCreator.CreateElements(_ifcModel).ToList();
            var loadCases = LoadCreator.GetLoadCases(_ifcModel).ToList();
            var loadCombos = LoadCreator.GetLoadCombinations(_ifcModel).ToList();
            return new Model() { Units = units, Elements = strElements, LoadCases = loadCases, LoadCombinations = loadCombos };
        }
        #region Old Implementation
        //List<Section> GetFrameSections()
        //{
        //    var retFrameSecs = new List<Section>();
        //    var frameElements = _ifcModel.Instances.OfType<IIfcStructuralCurveMember>().ToList();
        //    foreach (var elmnt in frameElements)
        //    {
        //        var sectionAsssoc = elmnt.HasAssociations.First(a => a is Xbim.Ifc2x3.Interfaces.IIfcRelAssociatesProfileProperties) as Xbim.Ifc2x3.Interfaces.IIfcRelAssociatesProfileProperties;
        //        var profProps = sectionAsssoc.RelatingProfileProperties as Xbim.Ifc2x3.Interfaces.IIfcStructuralProfileProperties;
        //        if (profProps.ProfileDefinition is IIfcRectangleProfileDef)
        //        {
        //            var recProfile = profProps.ProfileDefinition as IIfcRectangleProfileDef;

        //        }
        //        else if (profProps.ProfileDefinition is IIfcIShapeProfileDef)
        //        {
        //            var iProfile = profProps.ProfileDefinition as IIfcIShapeProfileDef;

        //        }

        //    }

        //    return null;
        //}
        //  List<Section> GetRectSections()
        //=> _ifcModel.Instances.OfType<IIfcRectangleProfileDef>().Select(pd => GetSection(pd)).Cast<Section>().ToList();


        //List<Section> GetIShapeSections()
        //{
        //    var retSections = new List<Section>();
        //    var iShapes = _ifcModel.Instances.OfType<IIfcIShapeProfileDef>();
        //    foreach (var iShape in iShapes)
        //        retSections.Add(GetSection(iShape));
        //    return retSections.Cast<Section>().ToList();
        //}


        //   List<AreaSection> GetAreaSections()
        //=> _ifcModel.Instances.OfType<IIfcStructuralSurfaceMember>().Select(m => new AreaSection() { SectionName = m.Name, BendingThickness = m.Thickness.Value, MembranceThickness = m.Thickness.Value }).ToList();







        //List <Element> GetAreaElements()
        //{
        //    var surfaceElements = _ifcModel.Instances.OfType<IIfcStructuralSurfaceMember>().ToList();
        //    foreach (var elmnt in surfaceElements)
        //    {
        //        var thickness = elmnt.Thickness;
        //        //  var surfaceRep = elmnt.Representation.Representations.First().Items.First as IIfcFaceSurface;
        //        #region Surface Points
        //        var surfPointsRels = elmnt.ConnectedBy;
        //        foreach (var surfPointRel in surfPointsRels)
        //        {
        //            var connection = surfPointRel.RelatedStructuralConnection; //as IfcStructuralPointConnection to get boundary condition
        //            var point = (connection.Representation.Representations.First().Items.First as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;
        //        }
        //        #endregion
        //    }
        //    return null;
        //}
        //List<Element> GetFrameElements()
        //{
        //    var frameElements = _ifcModel.Instances.OfType<IIfcStructuralCurveMember>().ToList();
        //    foreach (var elmnt in frameElements)
        //    {
        //        var framePoints = elmnt.ConnectedBy.Where(c => c.RelatedStructuralConnection is IIfcStructuralPointConnection);
        //        foreach (var point in framePoints)
        //        {
        //            var cartesianPoint = (point.RelatedStructuralConnection.Representation.Representations.First().Items.First as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;
        //        }
        //        //  elmnt.ConnectedBy to get boundary condition of points if there is 
        //        var curve = elmnt.Representation.Representations.First().Items.First as IIfcEdge;

        //        var startPoint = (curve.EdgeStart as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;
        //        var endPoint = (curve.EdgeEnd as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;


        //    }
        //    return null;
        //}
        //string GetUnits()
        //{
        //    var project = _ifcModel.Instances.OfType<IIfcProject>().First();
        //    var assignments = project.HasAssignments;
        //    var units = project.UnitsInContext.Units;
        //    foreach (var unit in units)
        //    {
        //        var name = unit.FullName;
        //    }
        //    return null;
        //}



        //List<BoundaryCondition> GetBoundaryConditions()
        //       => _ifcModel.Instances.OfType<IIfcStructuralPointConnection>().Where(p => p.AppliedCondition != null)
        //        .Select(p =>
        //        {
        //            var bndCnd = p.AppliedCondition as IIfcBoundaryNodeCondition;
        //            var cartesianPoint = (p.Representation.Representations.First().Items.First as IIfcVertexPoint).VertexGeometry as IIfcCartesianPoint;

        //            return new BoundaryCondition()
        //            {
        //                IsFreeTransX = (int)bndCnd.TranslationalStiffnessX.Value == 0,
        //                IsFreeTransY = (int)bndCnd.TranslationalStiffnessY.Value == 0,
        //                IsFreeTransZ = (int)bndCnd.TranslationalStiffnessZ.Value == 0,
        //                IsFreeMomentX = (int)bndCnd.RotationalStiffnessX.Value == 0,
        //                IsFreeMomentY = (int)bndCnd.RotationalStiffnessY.Value == 0,
        //                IsFreeMomentZ = (int)bndCnd.RotationalStiffnessZ.Value == 0,
        //                Point = new Point() { X = cartesianPoint.X, Y = cartesianPoint.Y, Z = cartesianPoint.Z }
        //            };

        //        }).ToList();



        //public List<Material> GetMaterials()
        //{
        //    var retMats = new List<Material>();
        //    var ifcMats = _ifcModel.Instances.OfType<IIfcMaterial>();
        //    foreach (var mat in ifcMats)
        //        retMats.Add(new Material() { Name = mat.Name.Value.ToString() });
        //    return retMats;
        //}

        #endregion


    }
}
