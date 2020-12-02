using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
namespace SapConverter.SapWriter
{
    public class GridLines : SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"GRID LINES\"";
        protected override string WriteContentData()
            => WriteGridLines();
        string WriteGridLines()
            => $"{WriteXLines()}{WriteYLines()}{WriteZLines()}";
        string WriteXLines()
            => WriteLines("X");
        string WriteYLines()
            => WriteLines("Y");
        string WriteZLines()
            => WriteLines("Z");
        string WriteLines(string propName)
        {

            var propVals = LineCoordinates(propName);
            if (!propVals.Any())
                return "";
            var start = propVals.Min();
            var end = propVals.Max();
            var lines = new StringBuilder();
            lines.AppendLine($"   CoordSys=GLOBAL   AxisDir={propName}   XRYZCoord={start}   LineType=Primary   LineColor=Gray8Dark   Visible=Yes   BubbleLoc=End");
            if (start != 0)
                lines.AppendLine($"   CoordSys=GLOBAL   AxisDir={propName}   XRYZCoord=0   LineType=Primary   LineColor=Gray8Dark   Visible=Yes   BubbleLoc=End");
            lines.AppendLine($"   CoordSys=GLOBAL   AxisDir={propName}   XRYZCoord={end}   LineType=Primary   LineColor=Gray8Dark   Visible=Yes   BubbleLoc=End");
            return lines.ToString();
        }
        List<double> LineCoordinates(string propName)
            => Model.ElementsPoints.GroupBy(BuildFilterQuery(propName)).Select(g => g.Key).ToList();
        Func<Point, double> BuildFilterQuery(string propName)
        {
            var pe = Expression.Parameter(typeof(Point), "p");
            var me = Expression.Property(pe, propName);
            var query = Expression.Lambda<Func<Point, double>>(me, pe);
            return query.Compile();
        }
    }
}
