using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class MaterialsGeneralProperties:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"MATERIAL PROPERTIES 01 - GENERAL\"";
        protected override string WriteContentData()
            => WriteMaterialsProperties();
        //not implmenteds
        string WriteMaterialsProperties()
        {
            var text = new StringBuilder();
            foreach (var mtrial in Model.Materials)
            {
                text.Append(WritePropty("Material",mtrial.Name));
                text.Append(WritePropty("Type",mtrial.Type??MaterialType.Other));
                text.Append(WritePropty("SymType", "Isotropic"));
                text.AppendLine();
            }
            if(Model.Materials.Select(m=>m.Name).Contains("Default Material"))
                text.AppendLine("   Material=\"Default Material\"   Type=Other   SymType=Isotropic");
            return text.ToString();
        }
    }
}
