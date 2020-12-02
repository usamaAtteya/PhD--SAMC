using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class ProgramControl:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"PROGRAM CONTROL\"";
        protected override string WriteContentData()
            => WriteProgramControl(Model.Units);
        string WriteProgramControl(ProjectUnits units)
        {
            var txt = new StringBuilder();
            txt.Append(WritePropty("ProgramName", "SAP2000"));
            txt.Append(WritePropty("Version", "12.0.0"));
            txt.Append(WritePropty("CurrUnits", WriteSapUnits(units)));
            txt.AppendLine();
            return txt.ToString();
        }
        string WriteSapUnits(ProjectUnits units)
            => $"{WriteForceUnit(units.ForceUnit)}, {WriteLengthUnit(units.LengthUnit)}, {WriteTempUnit(units.TemperatureUnit)}";
        string WriteForceUnit(ForceUnit force)
        {
            switch (force)
            {
                case ForceUnit.Lb:
                    return "lb";
                case ForceUnit.Kip:
                    return "Kip";
                case ForceUnit.KN:
                    return "Kn";
                case ForceUnit.Kgf:
                    return "Kgf";
                case ForceUnit.N:
                    return "N";
                case ForceUnit.Tonf:
                    return "Tonf";
                default:
                    return "Kn";
            }
        }
        string WriteLengthUnit(LengthUnit length)
        {
            switch (length)
            {
                case LengthUnit.In:
                    return "in";
                case LengthUnit.Ft:
                    return "ft";
                case LengthUnit.Mm:
                    return "mm";
                case LengthUnit.Cm:
                    return "cm";
                case LengthUnit.M:
                    return "m";
                default:
                    return "m";
            }
        }
        string WriteTempUnit(TemperatureUnit temp)
        {
            switch (temp)
            {
                case TemperatureUnit.C:
                    return "C";
                case TemperatureUnit.F:
                    return "F";
                default:
                    return "C";
            }
        }
    }
}
