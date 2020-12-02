using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;
using System.Text.RegularExpressions;

namespace SapConverter.SapWriter
{
    public abstract class SapSectionWriter : DocumentSectionWriter
    {
        protected string seperator = "   ";
        protected override string WriteContentFooter()
            => $" {Environment.NewLine}";
        protected virtual string WritePropty(string propertyName, object propertyValue)
            => $"{seperator}{propertyName}={WriteDoubleQuote(propertyValue)}";

        protected string WriteDoubleQuote(object propertyValue)
        {
            var propValStr = propertyValue.ToString();
            var valHasSpaces = Regex.IsMatch(propValStr, @"[\s]");
            if (valHasSpaces)
                return $"\"{propValStr}\"";
            return propValStr;
        }
        
    }
}
