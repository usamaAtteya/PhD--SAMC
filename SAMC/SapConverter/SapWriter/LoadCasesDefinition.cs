using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class LoadCasesDefinition:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"LOAD CASE DEFINITIONS\"";
        protected override string WriteContentData()
            => WriteLoadCases(Model.LoadCases);
        string WriteLoadCases(List<LoadCase> loadCases)
        {
            var text = new StringBuilder();
            foreach (var lodCas in loadCases)
            {
                text.Append(WritePropty("Case",lodCas.Name));
                text.Append(WritePropty("Type", "LinStatic"));
                text.Append(WritePropty("DesignType",lodCas.LoadCaseType.ToString().ToUpper()));
                text.AppendLine();
            }
            text.Append(WritePropty("Case", "MODAL"));
            text.Append(WritePropty("Type", "LinModal"));
            text.Append(WritePropty("DesignType", "OTHER"));
            text.AppendLine();
            return text.ToString();
        }
    }
}
