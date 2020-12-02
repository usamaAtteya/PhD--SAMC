using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class LinearLoadForce:LoadForce
    {
        public LoadForceCoordinates Coordinates { get; set; }
        public double? MomentX { get; set; }
        public double? MomentY { get; set; }
        public double? MomentZ { get; set; }
        public override string ToString()
            => $"frame{ForceX??0}{ForceY??0}{ForceZ??0}{MomentX??0}{MomentY??0}{MomentZ??0}{Coordinates.ToString()}";
    }
}
