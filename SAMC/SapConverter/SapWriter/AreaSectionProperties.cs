using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class AreaSectionProperties : SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"AREA SECTION PROPERTIES\"";
        protected override string WriteContentData()
            => GetAreaSectionProperties(Model.AreaSections);
        string GetAreaSectionProperties(IEnumerable<Section> sections)
        {
            var areaSectionsProperties = new StringBuilder();
            foreach (var sec in sections)
            {
                areaSectionsProperties.Append(WritePropty("Section", sec.Profile.SectionProfileName));
                if (sec.Material != null)
                    areaSectionsProperties.Append(WritePropty("Material", sec.Material.Name));
                areaSectionsProperties.Append(WritePropty("AreaType", "Shell"));
                areaSectionsProperties.Append(WritePropty("Thickness", GetAreaSectionThick(sec)));
                areaSectionsProperties.Append(WritePropty("BendThick", GetAreaSectionThick(sec)));
                areaSectionsProperties.AppendLine();
            }
            return areaSectionsProperties.ToString();
        }
        double GetAreaSectionThick(Section areaSection)
        {
            var secPro = areaSection.Profile as AreaSectionProfile;
            return secPro.Thickness;
        }
    }
}
