using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMC2.ModelConverter
{
    public abstract class DocumentWriter : ContentWriter
    {
        private readonly IDocumentSectionsWritersProvider secsWritesProvider;

        public DocumentWriter(IDocumentSectionsWritersProvider secsWritesProvider)
        {
            this.secsWritesProvider = secsWritesProvider;
        }

        protected override string WriteContentData()
       => string.Join("", secsWritesProvider.GetSectionsWriters().Select(s => s.WriteContent(Model)));
    }
}
