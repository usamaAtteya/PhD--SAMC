using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class FramSectionsAssignment:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"FRAME SECTION ASSIGNMENTS\"";
        protected override string WriteContentData()
            => GetFramSections(Model.FrameElements);
        string GetFramSections(IEnumerable<Element> framElmnts)
        {
            var text = new StringBuilder();
            foreach (var elmnt in framElmnts)
            {
                if (elmnt.Section?.Profile?.SectionProfileName != null)
                {
                    text.Append(WritePropty("Frame", elmnt.Id));
                    text.Append(WritePropty("AnalSect", elmnt.Section.Profile.SectionProfileName));
                    text.AppendLine();
                }

            }
            return text.ToString();
        }
    }
}
