using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAMC2.ModelConverter
{
   public abstract class ContentWriter
    {
        protected Model Model;
        public virtual string WriteContent(Model model)
        {
            Model = model;
            var content = WriteContentData();
            return String.IsNullOrEmpty(content) ||String.IsNullOrWhiteSpace(content) ? "": GetTextFormated(WriteContentHeader()) + GetTextFormated(content) + GetTextFormated(WriteContentFooter());
        }
        protected virtual string WriteContentHeader() => "";
        protected abstract string WriteContentData();
        protected virtual string WriteContentFooter() => "";

        string GetTextFormated(string text)
        => text + (String.IsNullOrWhiteSpace(text) || Regex.IsMatch(text, @"(\n|\r|\r\n)$") ? "" : Environment.NewLine);

    }
}
