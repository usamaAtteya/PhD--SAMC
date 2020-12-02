using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public abstract class Element
    {
        public int Id { get; set; }
        public Section Section { get; set; } = new Section();
        public List<Point> Vertices { get; set; }

    }
}
