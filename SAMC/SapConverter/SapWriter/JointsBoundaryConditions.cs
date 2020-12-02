using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class JointsBoundaryConditions:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"JOINT RESTRAINT ASSIGNMENTS\"";
        protected override string WriteContentData()
            => WritePointsBoundary(Model.BoundaryConditionsPoints);
        string WritePointsBoundary(IEnumerable<Point> points)
        {
            var text = new StringBuilder();
            foreach (var point in points)
            {
                text.Append(WritePropty("Joint", point.Id));
                text.Append(WritePropty("U1",RestraintVal(point.BoundaryCondition.IsFreeTransX)));
                text.Append(WritePropty("U2",RestraintVal(point.BoundaryCondition.IsFreeTransY)));
                text.Append(WritePropty("U3",RestraintVal(point.BoundaryCondition.IsFreeTransZ)));
                text.Append(WritePropty("R1",RestraintVal(point.BoundaryCondition.IsFreeMomentX)));
                text.Append(WritePropty("R2",RestraintVal(point.BoundaryCondition.IsFreeMomentY)));
                text.Append(WritePropty("R3",RestraintVal(point.BoundaryCondition.IsFreeMomentZ)));
                text.AppendLine();
            }
            return text.ToString();
        }
        string RestraintVal(bool boundary)
        {
            if (boundary)
                return "No";
            else
                return "Yes";
        }
    }
}
