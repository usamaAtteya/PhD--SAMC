using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class LoadCombinations:SapSectionWriter
    {        
        protected override string WriteContentHeader()
            => "TABLE:  \"COMBINATION DEFINITIONS\"";
        protected override string WriteContentData()
            => GetLoadCombinations(Model.LoadCombinations);
        string GetLoadCombinations(List<LoadCombination> loadCombs)
        {
            var loadCombinations = new StringBuilder();             
            foreach (var loadCombo in loadCombs)
            {
                foreach (var loadCombItem in loadCombo.LoadCombinationItems)
                {
                    loadCombinations.Append(WritePropty("ComboName",loadCombo.Name));
                    loadCombinations.Append(WritePropty("CaseName",loadCombItem.LoadCaseName));
                    loadCombinations.Append(WritePropty("ScaleFactor",loadCombItem.Factor));
                    loadCombinations.AppendLine();
                }
            }
            return loadCombinations.ToString();
        }
    }
}
