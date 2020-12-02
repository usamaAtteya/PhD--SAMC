using SAMC2;
using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaadConverter.StaadWriter
{
    public class AreaElementsSectionProfilesWriter:DocumentSectionWriter
    {
        protected override string WriteContentData()
            => GetElementsSectionProfiles(Model.AreaElements.Cast<AreaElement>().ToList());
        protected override string WriteContentHeader()
            => "ELEMENT PROPERTY";

        string GetElementsSectionProfiles(List<AreaElement> elmnts)
        {
            var elmntsPropts = new StringBuilder();
            elmnts.Where(e=>e.Section?.Profile !=null).GroupBy(e => (e.Section.Profile  as AreaSectionProfile).Thickness).ToList()
              .ForEach(g => elmntsPropts.AppendLine($"{string.Join(" ", g.Select(e => e.Id))} THICKNESS {g.Key}"));
            return elmntsPropts.ToString();
        }
        //string WrtSecPropts(SectionProfile SecPro)
        //{
        //    if (SecPro is AreaSectionProfile)
        //        return WrtAreaSecPro((AreaSectionProfile)SecPro);
        //    throw new Exception("Not Impelmented Section Profile");
        //}
        //string WrtAreaSecPro(AreaSectionProfile AreaSec)
        //    => $"THICKNESS {AreaSec.Thickness}";
      
    }
}
