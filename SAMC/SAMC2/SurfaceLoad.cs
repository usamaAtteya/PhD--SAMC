using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class SurfaceLoadForce:LoadForce
    {
        public LoadForceCoordinates Coordinates { get; set; }
        public override string ToString()
            => $"area{ForceX??0}{ForceY??0}{ForceZ??0}{Coordinates.ToString()}";

    }
}
