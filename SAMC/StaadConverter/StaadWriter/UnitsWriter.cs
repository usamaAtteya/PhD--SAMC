using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;

namespace StaadConverter.StaadWriter
{
    public class UnitsWriter : DocumentSectionWriter
    {

        protected override string WriteContentData()
       => $"UNIT {GetLengthUnit()} {GetForceUnit()}";

        
        string GetForceUnit()
        {
            switch (Model.Units.ForceUnit)
            {
                case ForceUnit.Lb:
                    return "POUND";
                case ForceUnit.Kip:
                    return "KIP";
                case ForceUnit.KN:
                    return "KN";
                case ForceUnit.Kgf:
                    return "KG";
                case ForceUnit.N:
                    return "NEWTON";
                case ForceUnit.Tonf:
                default:
                    return "MTON";
            }
        }
        string GetLengthUnit()
        {
            switch (Model.Units.LengthUnit)
            {
                case LengthUnit.In:
                    return "INCHES";
                case LengthUnit.Ft:
                    return "FEET";
                case LengthUnit.Mm:
                    return "MMS";
                case LengthUnit.Cm:
                    return "CM";
                case LengthUnit.M:
                default:
                    return "METER";
            }
        }
    }
}
