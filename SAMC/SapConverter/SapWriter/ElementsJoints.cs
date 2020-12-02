using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public abstract class ElementsJoints:SapSectionWriter
    {
        protected string WriteElmntsJoints(IEnumerable<Element> elmnts)
        {
            string elmntType = GetElmntType(elmnts.First());
            var elmntsJoints = new StringBuilder();
            foreach (var elmnt in elmnts)
            {
                elmntsJoints.Append(WritePropty(elmntType,elmnt.Id));
                elmntsJoints.Append(WriteJoints(elmnt.Vertices));
                elmntsJoints.AppendLine();
            }
            return elmntsJoints.ToString();
        }
        string GetElmntType(Element elmnt)
        {
            if (elmnt is AreaElement)
                return "Area";
            else
                return "Frame";
        }
        string WriteJoints(List<Point> points)
        {
            var joints = new StringBuilder();
            for (int i = 0; i < points.Count; i++)
            {
                joints.Append(WritePropty($"Joint{(i + 1).ToString()}",points[i].Id ));
            }            
            return joints.ToString();
        }
    }
    
}
