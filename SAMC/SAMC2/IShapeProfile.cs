using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class IShapeProfile: FrameSectionProfile
    {
        public double OverallHeight { get; set; }
        public double WebThickness { get; set; }
        public double TopFlangeWidth { get; set; }
        public double TopFlangeThickness { get; set; }
        public double? TopFlangeFilletRadius { get; set; }
        public double? TopFlangeEdgeRadius { get; set; }
        public double BottomFlangeWidth { get; set; }
        public double BottomFlangeThickness { get; set; }
        public double? BottomFlangeFilletRadius { get; set; }
        public double? BottomFlangeEdgeRadius { get; set; }

    }
}
