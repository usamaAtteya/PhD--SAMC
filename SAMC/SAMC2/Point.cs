﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class Point
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public BoundaryCondition BoundaryCondition { get; set; }
    }
}
