using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class FrameSectionsPropertiesGeneral : SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"FRAME SECTION PROPERTIES 01 - GENERAL\"";
        protected override string WriteContentData()
            => GetFramSectionsPropets(Model.FrameSections);
        string GetFramSectionsPropets(IEnumerable<Section> framSections)
        {
            var text = new StringBuilder();
            foreach (var frameSection in framSections)
            {
                text.Append(WritePropty("SectionName", frameSection.Profile.SectionProfileName));
                if (frameSection.Material != null)
                    text.Append(WritePropty("Material", frameSection.Material.Name));
                text.Append(WriteFramSectProfile(frameSection));
                text.AppendLine();
            }
            return text.ToString();
        }
        string WriteFramSectProfile(Section section)
        {
            if (section.Profile is RecangularProfile)
                return WriteRectProperts(section.Profile as RecangularProfile);
            else
                return WriteIShapeProperts(section.Profile as IShapeProfile);
        }
        string WriteRectProperts(RecangularProfile profile)
        {
            var text = new StringBuilder();
            text.Append(WritePropty("Shape", "Rectangular"));
            text.Append(WritePropty("t3", profile.Depth));
            text.Append(WritePropty("t2", profile.Width));
            return text.ToString();
        }
        string WriteIShapeProperts(IShapeProfile profile)
        {
            var text = new StringBuilder();
            text.Append(WritePropty("Shape", "I/Wide Flange"));
            text.Append(WritePropty("t3", profile.OverallHeight));
            text.Append(WritePropty("t2", profile.TopFlangeWidth));
            text.Append(WritePropty("tf", profile.TopFlangeThickness));
            text.Append(WritePropty("tw", profile.WebThickness));
            text.Append(WritePropty("t2b", profile.BottomFlangeWidth));
            text.Append(WritePropty("tfb", profile.BottomFlangeThickness));
            return text.ToString();
        }
    }
}
