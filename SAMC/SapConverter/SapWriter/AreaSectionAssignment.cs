using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class AreaSectionAssignment : SapSectionWriter
    {
        protected override string WriteContentHeader()
        => "TABLE:  \"AREA SECTION ASSIGNMENTS\"";
        protected override string WriteContentData()
            => GetAreaSections(Model.AreaElements);
        string GetAreaSections(IEnumerable<Element> areaElemnts)
        {
            var areaSections = new StringBuilder();
            foreach (var elmnt in areaElemnts)
            {
                if (elmnt.Section?.Profile != null)
                {
                    areaSections.Append(WritePropty("Area", elmnt.Id));

                    areaSections.Append(WritePropty("Section", elmnt.Section.Profile.SectionProfileName));
                    // MatProp=Default not mandatory in sap file
                    areaSections.AppendLine();
                }
            }
            return areaSections.ToString();
        }
    }
}
