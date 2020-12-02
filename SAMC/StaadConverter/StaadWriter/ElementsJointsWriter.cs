using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;

namespace StaadConverter.StaadWriter
{
    public abstract class ElementsJointsWriter:DocumentSectionWriter
    {
        protected string WriteElementsJonits(List<Element> Elmnts)
        {
            var ElmntsJonts = new StringBuilder();
            Elmnts.ForEach(e => ElmntsJonts.Append($"{e.Id} {string.Join(" ", e.Vertices.Select(v => v.Id))};"));
            return ElmntsJonts.AppendLine().ToString();
        }
    }
}
