using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class Material
    {
        public string Name { get; set; }
        public double ShearModulus { get; set; }
        public double ThermalExpanssionC { get; set; }
        public double PoissonRatio { get; set; }
        public double YoungModulus { get; set; }
        public double WeightDensity { get; set; }
        public MaterialType? Type { get; set; }

        public void SetWeightDensityByMassDensity(double massDensity, LengthUnit lengthUnit)
            => WeightDensity = Math.Round(massDensity * GravityValue(lengthUnit), 4);
        public double MassDensityFor(LengthUnit lengthUnit)
        => Math.Round(WeightDensity / GravityValue(lengthUnit), 4);

        double GravityValue(LengthUnit lengthUnit)
        {
            var meterConversionRate = 9.80665;
            var feetConversionRate = 32.1737;
            var inchConversionRate = 386.09;
            switch (lengthUnit)
            {
                case LengthUnit.In:
                    return inchConversionRate;
                case LengthUnit.Ft:
                    return feetConversionRate;
                case LengthUnit.Mm:
                    return meterConversionRate * 1000;
                case LengthUnit.Cm:
                    return meterConversionRate * 100;
                case LengthUnit.M:
                    return meterConversionRate;
                default:
                    throw new Exception("Un handeled Length Unit");
            }
        }
    }
    public enum MaterialType
    {
        Concrete,
        Steel,
        Other
    }
}
