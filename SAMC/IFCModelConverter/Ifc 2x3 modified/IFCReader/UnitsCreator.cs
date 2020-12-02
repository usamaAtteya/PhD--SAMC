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
    public class UnitsCreator
    {
        public static ProjectUnits GetProjectUnits(IfcStore ifcModel)
          => GetProjectUnits(ifcModel.Instances.OfType<IIfcProject>().First());
        public static ProjectUnits GetProjectUnits(IIfcProject ifcProject)
        {
            var ifcNamedUnits = ifcProject.UnitsInContext.Units.OfType<IIfcNamedUnit>();
            return new ProjectUnits()
            {
                ForceUnit = GetForceUnit(ifcNamedUnits.First(u => u.UnitType == IfcUnitEnum.FORCEUNIT)),
                LengthUnit = GetLengthUnit(ifcNamedUnits.First(u => u.UnitType == IfcUnitEnum.LENGTHUNIT)),
                TemperatureUnit = GetTemperatureUnit(ifcNamedUnits.First(u => u.UnitType == IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT))
            };
        }
        static ForceUnit GetForceUnit(IIfcNamedUnit ifcNamedUnit)
          => ifcNamedUnit is IIfcSIUnit ? GetForceUnit((IIfcSIUnit)ifcNamedUnit) : GetForceUnit((IIfcConversionBasedUnit)ifcNamedUnit);
        static ForceUnit GetForceUnit(IIfcSIUnit ifcstandardUnit)
            => ifcstandardUnit.Prefix == null || ifcstandardUnit.Prefix == IfcSIPrefix.DECA ? ForceUnit.N  // Newton is the only unit of type IIfcSIUnit for force
            : ifcstandardUnit.Prefix == IfcSIPrefix.KILO ? ForceUnit.KN :
            throw new Exception("Not implemented IfcSIPrefix type in function GetForceUnit");

        static ForceUnit GetForceUnit(IIfcConversionBasedUnit ifcConvBasedUnit)
        {
            switch (ifcConvBasedUnit.Name.ToString().ToUpper())
            {
                case "KIP":
                    return ForceUnit.Kip;
                case "LBF":
                    return ForceUnit.Lb;
                case "KILOGRAM FORCE":
                    return ForceUnit.Kgf;
                case "TON FORCE":
                    return ForceUnit.Tonf;
                default:
                    throw new Exception("Not implemented IIfcConversionBasedUnit type in function GetForceUnit");
            }
        }


        static LengthUnit GetLengthUnit(IIfcNamedUnit ifcNamedUnit)
        => ifcNamedUnit is IIfcSIUnit ? GetLengthUnit((IIfcSIUnit)ifcNamedUnit) : GetLengthUnit((IIfcConversionBasedUnit)ifcNamedUnit);

        static LengthUnit GetLengthUnit(IIfcSIUnit ifcstandardUnit)
            => ifcstandardUnit.Prefix == null || ifcstandardUnit.Prefix == IfcSIPrefix.DECA ? LengthUnit.M // Meter is the only unit of type IIfcSIUnit for Length
            : ifcstandardUnit.Prefix == IfcSIPrefix.CENTI ? LengthUnit.Cm
            : ifcstandardUnit.Prefix == IfcSIPrefix.MILLI ? LengthUnit.Mm
            : throw new Exception("Not implemented IfcSIPrefix type in function GetLengthUnit");
        static LengthUnit GetLengthUnit(IIfcConversionBasedUnit ifcConvBasedUnit)
        {
            switch (ifcConvBasedUnit.Name.ToString().ToUpper())
            {
                case "INCH":
                    return LengthUnit.In;
                case "FOOT":
                    return LengthUnit.Ft;
                default:
                    throw new Exception("Not implemented IIfcConversionBasedUnit type in function GetLengthUnit");
            }
        }


        static TemperatureUnit GetTemperatureUnit(IIfcNamedUnit ifcNamedUnit)
             => ifcNamedUnit is IIfcSIUnit ? GetTemperatureUnit((IIfcSIUnit)ifcNamedUnit) : GetTemperatureUnit((IIfcConversionBasedUnit)ifcNamedUnit);
        static TemperatureUnit GetTemperatureUnit(IIfcSIUnit ifcstandardUnit)
           => ifcstandardUnit.Prefix == null || ifcstandardUnit.Prefix == IfcSIPrefix.DECA ? TemperatureUnit.C // Celsius is the only unit of type IIfcSIUnit for temperature
            : throw new Exception("Not implemented IfcSIPrefix type in function GetTemperatureUnit");

        static TemperatureUnit GetTemperatureUnit(IIfcConversionBasedUnit ifcConvBasedUnit)
        {
            switch (ifcConvBasedUnit.Name.ToString().ToUpper())
            {
                case "FAHRENHEIT":
                    return TemperatureUnit.F;
                default:
                    throw new Exception("Not implemented IIfcConversionBasedUnit type in function GetTemperatureUnit");
            }
        }

    }
}
