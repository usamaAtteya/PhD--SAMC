using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class LoadCaseAssignment1:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"CASE - STATIC 1 - LOAD ASSIGNMENTS\"";
        protected override string WriteContentData()
            => GetLoadCasesPropeties(Model.LoadCases);
        string GetLoadCasesPropeties(List<LoadCase> loadCases)
        {
            var loadCsesTxt = new StringBuilder();
            foreach (var loadCase in loadCases)
            {
                loadCsesTxt.Append(WritePropty("Case",loadCase.Name));
                loadCsesTxt.Append(WritePropty("LoadType", "Load pattern"));
                loadCsesTxt.Append(WritePropty("LoadName",loadCase.Name));
                loadCsesTxt.Append(WritePropty("LoadSF",loadCase.ScaleFactorCoefficient));
                loadCsesTxt.AppendLine();
            }
            return loadCsesTxt.ToString();
        }
    }
}
