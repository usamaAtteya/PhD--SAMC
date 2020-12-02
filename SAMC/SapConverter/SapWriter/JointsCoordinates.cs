using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class JointsCoordinates:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"JOINT COORDINATES\"";
        protected override string WriteContentData()
            => WriteJointsCordnates(Model.ElementsPoints);
        string WriteJointsCordnates(IEnumerable<Point> points)
        {
            var text = new StringBuilder();
            foreach (var point in points)
            {
                text.Append(WritePropty("Joint", point.Id));
                text.Append(WritePropty("CoordSys", "GLOBAL"));
                text.Append(WritePropty("CoordType", "Cartesian"));
                text.Append(WritePropty("XorR", point.X));
                text.Append(WritePropty("Y", point.Y));
                text.Append(WritePropty("Z", point.Z));
                text.AppendLine();
            }
            return text.ToString();
        }
    }
}
