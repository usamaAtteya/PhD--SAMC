using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2.ModelConverter;

namespace SapConverter.SapWriter
{
    public class SapWriter:DocumentWriter
    {
        public SapWriter(IDocumentSectionsWritersProvider secsWritesProvider) : base(secsWritesProvider)
        {

        }
        protected override string WriteContentFooter()
        => "END TABLE DATA";

    }
}
