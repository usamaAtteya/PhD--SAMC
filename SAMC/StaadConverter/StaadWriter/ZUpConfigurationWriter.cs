using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaadConverter.StaadWriter
{
    public class ZUpConfigurationWriter : DocumentSectionWriter
    {
        protected override string WriteContentData()
      => "SET z UP";
    }
}
