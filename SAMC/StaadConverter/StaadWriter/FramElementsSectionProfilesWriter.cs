using SAMC2;
using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaadConverter.StaadWriter
{
    public class FramElementsSectionProfilesWriter:DocumentSectionWriter
    {
        protected override string WriteContentHeader()
            => "MEMBER PROPERTY";
        protected override string WriteContentData()
            => GetElmntsPropts(Model.FrameElements.ToList());

         string GetElmntsPropts(List<Element> elmnts)
        {
            var ElmntsPropts = new StringBuilder();
            elmnts.Where(e => e.Section?.Profile != null).GroupBy(e => e.Section.Profile.SectionProfileName).ToList()
              .ForEach(g => ElmntsPropts.AppendLine($"{string.Join(" ", g.Select(e => e.Id))} {WrtSecPropts(g.First().Section.Profile)}"));
            return ElmntsPropts.ToString();
        }
        string WrtSecPropts(SectionProfile SecPro)
        {
            //if (SecPro is AreaSectionProfile)
            //    return WrtAreaSecPro((AreaSectionProfile)SecPro);
             if (SecPro is RecangularProfile)
                return WrtRectSecPro((RecangularProfile)SecPro);
            else if (SecPro is IShapeProfile)
                return WrtIShapeSecPro((IShapeProfile)SecPro);
            throw new Exception("Not Impelmented Section Profile");
        }

        string WrtRectSecPro(RecangularProfile RectSec)
            => $"PRIS YD {RectSec.Depth} ZD {RectSec.Width}";
        string WrtIShapeSecPro(IShapeProfile ISec)
            => $"TAPERED {ISec.OverallHeight} {ISec.WebThickness} {ISec.OverallHeight} {ISec.TopFlangeWidth} {ISec.TopFlangeThickness} {ISec.BottomFlangeWidth} {ISec.BottomFlangeThickness}";


    }
}
