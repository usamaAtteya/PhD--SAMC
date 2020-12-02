using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;

namespace StaadConverter.StaadWriter
{
    public class LoadCombinationWriter : DocumentSectionWriter
    {

        protected override string WriteContentData()
        {
            var text = new StringBuilder();
            Model.LoadCombinations.ForEach(l => text.AppendLine(WriteLoadCombination(l)));
            return text.ToString();
        }
        string WriteLoadCombination(LoadCombination loadComb)
        {
            if (loadComb.LoadCombinationItems == null || !loadComb.LoadCombinationItems.Any())
                return "";
            var text = new StringBuilder().AppendLine($"LOAD COMB {loadComb.Id} {loadComb.Name}");
            text.Append(GetLoadCombItems(loadComb.LoadCombinationItems));
            return text.ToString();
        }
        string GetLoadCombItems(List<LoadCombinationItem> combItems)
        {
            var text = new StringBuilder();
            combItems.ForEach(i => text.Append($"{i.LoadCaseId} {i.Factor} "));
            return text.ToString();
        }
    }
}
