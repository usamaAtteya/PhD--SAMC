using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class LoadCase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LoadCaseType  LoadCaseType { get; set; }
        public double ScaleFactorCoefficient { get; set; } = 1;
        public List<Load> Loads { get; set; }
    }
}
