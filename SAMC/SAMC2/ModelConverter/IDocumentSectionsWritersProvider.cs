using System.Collections.Generic;


namespace SAMC2.ModelConverter
{
   public interface IDocumentSectionsWritersProvider
    {
        IEnumerable<DocumentSectionWriter> GetSectionsWriters();
    }
}