using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class BoundaryCondition
    {
        public string Id { get { return ToString(); } }
        public bool IsFreeTransX { get; set; }
        public bool IsFreeTransY { get; set; }
        public bool IsFreeTransZ { get; set; }
        public bool IsFreeMomentX { get; set; }
        public bool IsFreeMomentY { get; set; }
        public bool IsFreeMomentZ { get; set; }

        public bool IsFixed
        {
            get
            {
                return !IsFreeTransX
            && !IsFreeTransY
            && !IsFreeTransZ
            && !IsFreeMomentX
            && !IsFreeMomentY
            && !IsFreeMomentZ;
            }
        }

        public override string ToString()
       => $"{IsFreeTransX}{IsFreeTransY}{IsFreeTransZ}{IsFreeMomentX}{IsFreeMomentY}{IsFreeMomentZ}";
        }
}
