using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;

namespace StaadConverter.StaadWriter
{
    public  class  ElmentsMaterialsWriter:DocumentSectionWriter
    {
        protected override string WriteContentHeader()
            => "CONSTANTS";
        protected override string WriteContentData()
            => GetElmentsMaterials(Model.Elements.ToList());

        protected string GetElmentsMaterials(List<Element> elmnts)
        {
            var text = new StringBuilder();
            elmnts.Where(e=>e.Section?.Material != null).GroupBy(e => e.Section.Material.Name).ToList()
                .ForEach(g => text.AppendLine($"MATERIAL {g.First().Section.Material.Name.Replace(" ","")} MEMB {string.Join(" ",g.Select(e=>e.Id))}"));
            return text.ToString();
        }
    }
}
