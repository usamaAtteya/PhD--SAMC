using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMC2
{
    public class Model
    {

        public ProjectUnits Units { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
        public List<LoadCase> LoadCases { get; set; } = new List<LoadCase>();
        public List<LoadCombination> LoadCombinations { get; set; } = new List<LoadCombination>();
        public IEnumerable<Element> FrameElements { get { return Elements.OfType<FrameElement>(); } }
        public IEnumerable<Element> AreaElements { get { return Elements.OfType<AreaElement>(); } }
        public IEnumerable<Material> Materials { get { return Elements.Where(e=>e.Section!=null).Select(e => e.Section.Material).Where(m =>m != null).GroupBy(m => m.Name).Select(gm => gm.First()).ToList(); } }
        public IEnumerable<Section> AreaSections { get { return GetAreaSections(); } }
        public IEnumerable<Section> FrameSections { get { return GetFrameSections(); } }
        public IEnumerable<Section> Sections { get { return FrameSections.Union(AreaSections); } }
        public IEnumerable<Point> BoundaryConditionsPoints { get { return Elements.SelectMany(e => e.Vertices).GroupBy(m => m.Id).Select(gp => gp.First()).Where(v => v.BoundaryCondition != null); } }
        public HashSet<Point> ElementsPoints
        {
            get
            {
                var retPoints = new HashSet<Point>();
                foreach (var pnt in Elements.SelectMany(e => e.Vertices).GroupBy(e=>e.Id).Select(g=>g.First()))
                    retPoints.Add(pnt);
                return retPoints;
            }
        }
        IEnumerable<Section> GetFrameSections()
             => FrameElements.Where(e=>e.Section !=null && e.Section.Profile !=null).Select(e=>e.Section).GroupBy(s => s.Profile.SectionProfileName).Select(g => g.First());
        IEnumerable<Section> GetAreaSections()
            => AreaElements.Where(e => e.Section != null && e.Section.Profile != null).Select(e => e.Section).GroupBy(s =>(s.Profile as AreaSectionProfile).Thickness).Select(g => g.First());

      //  IEnumerable<Section> GetSectionsOfElementType<T>() where T : Element
      //=> Elements.OfType<T>().Select(e => e.Section).GroupBy(s => (s.Profile.SectionProfileName)).Select(g => g.First());
    }
}
