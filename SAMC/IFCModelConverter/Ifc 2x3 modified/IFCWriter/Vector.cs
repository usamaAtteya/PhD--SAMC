using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
namespace IFCModelConverter.Ifc_2x3_modified.IFCWriter
{
    public class Vector
    {
        public Vector(Element elmnt)
        {
            _Frame = elmnt;
        }
        Element _Frame; 
        public int X { get {return (_Frame.Vertices[1].X > _Frame.Vertices[0].X) ? 1 : (_Frame.Vertices[1].X < _Frame.Vertices[0].X) ? -1 : 0; } }
        public int Y { get { return (_Frame.Vertices[1].Y > _Frame.Vertices[0].Y) ? 1 : (_Frame.Vertices[1].Y < _Frame.Vertices[0].Y) ? -1 : 0; } }
        public int Z { get { return (_Frame.Vertices[1].Z > _Frame.Vertices[0].Z) ? 1 : (_Frame.Vertices[1].Z < _Frame.Vertices[0].Z) ? -1 : 0; } }
        public double Abs { get { return Math.Sqrt((Math.Pow((_Frame.Vertices[1].X - _Frame.Vertices[0].X), 2)) + (Math.Pow((_Frame.Vertices[1].Y - _Frame.Vertices[0].Y), 2)) + (Math.Pow((_Frame.Vertices[1].Z - _Frame.Vertices[0].Z), 2))); } }

        
    }
}
