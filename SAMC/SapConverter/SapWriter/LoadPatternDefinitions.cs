using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
namespace SapConverter.SapWriter
{
    public class LoadPatternDefinitions:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"LOAD PATTERN DEFINITIONS\"";
        protected override string WriteContentData()
            => WriteLoadPatterns(Model.LoadCases);
        string WriteLoadPatterns(List<LoadCase> loadCases)
        {
            var text = new StringBuilder();
            foreach (var lodCas in loadCases)
            {
                text.Append(WritePropty("LoadPat",lodCas.Name));
                text.Append(WritePropty("DesignType",lodCas.LoadCaseType.ToString().ToUpper()));
                if (lodCas.LoadCaseType.Equals(LoadCaseType.Dead))
                    text.Append(WritePropty("SelfWtMult",1));
                else
                    text.Append(WritePropty("SelfWtMult", 0));
                text.AppendLine();
            }
            return text.ToString();
        }
    }
}
