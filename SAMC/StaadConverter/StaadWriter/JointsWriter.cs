using SAMC2;
using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaadConverter.StaadWriter
{
    public class JointsWriter : DocumentSectionWriter
    {
        protected override string WriteContentData()
        => string.Join("", Model.ElementsPoints.Select(p => WriteJoint(p)));

        protected override string WriteContentHeader()
        => "JOINT COORDINATES";

        string WriteJoint(Point p)
            => $"{p.Id} {p.X} {p.Y} {p.Z};";
    }
}
