using SAMC2;
using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaadConverter.StaadWriter
{
    public class BoundaryConditionWriter : DocumentSectionWriter
    {
        protected override string WriteContentHeader()
        => "SUPPORTS";
        protected override string WriteContentData()
        => GetFixedSupports() + GetNonFixedSupports();
        string GetFixedSupports()
        {
            var fixedSupports = Model.BoundaryConditionsPoints.Where(b => b.BoundaryCondition.IsFixed);
            return !fixedSupports.Any() ? "" : new StringBuilder().AppendLine($"{string.Join(" ", fixedSupports.Select(s => s.Id))} FIXED").ToString();
        }
        string GetNonFixedSupports()
        {
            var retString =new StringBuilder();
            var nonFixedGroupedSupports = Model.BoundaryConditionsPoints.Where(b => !b.BoundaryCondition.IsFixed).GroupBy(b=>b.BoundaryCondition.Id);          
            foreach (var group in nonFixedGroupedSupports)
            {
                retString.Append(string.Join(" ", group.Select(s => s.Id)));
                retString.AppendLine($" FIXED BUT{ GetBndCndRealeses(group.First().BoundaryCondition)}");
            }
            return retString.ToString();
            
        }
        string GetBndCndRealeses(BoundaryCondition bndCnd)
            => $"{(bndCnd.IsFreeTransX ? " FX" : "")}{ (bndCnd.IsFreeTransY ? " FY" : "")}{ (bndCnd.IsFreeTransZ ? " FZ" : "")}{ (bndCnd.IsFreeMomentX ? " MX" : "")}{ (bndCnd.IsFreeMomentY ? " MY" : "")}{ (bndCnd.IsFreeMomentZ ? " MZ" : "")}";
    }
}
