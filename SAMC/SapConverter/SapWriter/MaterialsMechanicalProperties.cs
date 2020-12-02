using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class MaterialsMechanicalProperties:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"MATERIAL PROPERTIES 02 - BASIC MECHANICAL PROPERTIES\"";
        protected override string WriteContentData()
            => GetMaterialsMechanicalProperties();
        string GetMaterialsMechanicalProperties()
        {
            var materialPropets = new StringBuilder();            
            foreach (var m in Model.Materials)
            {
                materialPropets.Append(WritePropty("Material", m.Name));
                materialPropets.Append(WritePropty("UnitWeight", m.WeightDensity));
                materialPropets.Append(WritePropty("UnitMass",m.MassDensityFor(Model.Units.LengthUnit))); 
                materialPropets.Append(WritePropty("E1", m.YoungModulus));
                materialPropets.Append(WritePropty("G12", m.ShearModulus));
                materialPropets.Append(WritePropty("U12", m.PoissonRatio));
                materialPropets.Append(WritePropty("A1", m.ThermalExpanssionC));
                materialPropets.AppendLine();
            }
            return materialPropets.ToString();
        }

        //double GetSapUnitMass(Material material)
        //{
        //    var meterConversion = 9.80665;
        //    var feetConversion = 32.1737;
        //    var inchConversion = 386.09;
        //    switch (Model.Units.LengthUnit)
        //    {
        //        case LengthUnit.In:
        //            return Math.Round(material.WeightPerUnitVolume/inchConversion, 4);
        //        case LengthUnit.Ft:
        //            return Math.Round(material.WeightPerUnitVolume/feetConversion, 4);
        //        case LengthUnit.Mm:
        //            return Math.Round(material.WeightPerUnitVolume/(meterConversion * 1000), 4);
        //        case LengthUnit.Cm:
        //            return Math.Round(material.WeightPerUnitVolume/(meterConversion * 100), 4);
        //        case LengthUnit.M:
        //            return Math.Round(material.WeightPerUnitVolume/meterConversion, 4);
        //        default:
        //            throw new Exception("Un handeled Length Unit");
        //    }
        //}

    }
}
