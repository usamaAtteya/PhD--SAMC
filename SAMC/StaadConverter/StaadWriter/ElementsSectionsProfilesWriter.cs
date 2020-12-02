//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using SAMC2;
//using SAMC2.ModelConverter;

//namespace StaadConverter.StaadWriter
//{
//    public abstract class ElementsSectionsProfilesWriter:DocumentSectionWriter
//    {
//        protected string GetElmntsPropts(List<Element> Elmnts)
//        {
//            var ElmntsPropts = new StringBuilder();
//            Elmnts.GroupBy(e => e.Section.Profile.SectionProfileName).ToList()
//              .ForEach(g => ElmntsPropts.AppendLine($"{string.Join(" ", g.Select(e => e.Id))} {WrtSecPropts(g.First().Section.Profile)}"));
//            return ElmntsPropts.ToString();
//        }
//        string WrtSecPropts(SectionProfile SecPro)
//        {
//            if (SecPro is AreaSectionProfile)
//                return WrtAreaSecPro((AreaSectionProfile)SecPro);
//            else if (SecPro is RecangularProfile)
//                return WrtRectSecPro((RecangularProfile)SecPro);
//            else if (SecPro is IShapeProfile)
//                return WrtIShapeSecPro((IShapeProfile)SecPro);
//            throw new Exception("Not Impelmented Section Profile");
//        }
//        string WrtAreaSecPro(AreaSectionProfile AreaSec)
//            => $"THICKNESS {AreaSec.Thickness}";
//        string WrtRectSecPro(RecangularProfile RectSec)
//            => $"PRIS YD {RectSec.Width} ZD {RectSec.Depth}";
//        string WrtIShapeSecPro(IShapeProfile ISec)
//            => $"TAPPERED {ISec.OverallHeight} {ISec.WebThickness} {ISec.OverallHeight} {ISec.TopFlangeWidth} {ISec.TopFlangeThickness} {ISec.BottomFlangeWidth} {ISec.BottomFlangeThickness}";

//    }
//}
