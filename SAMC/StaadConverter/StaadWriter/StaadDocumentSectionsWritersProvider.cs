using SAMC2.ModelConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaadConverter.StaadWriter
{
    public class StaadDocumentSectionsWritersProvider : IDocumentSectionsWritersProvider
    {
        public IEnumerable<DocumentSectionWriter> GetSectionsWriters()
        {
            yield return new ZUpConfigurationWriter();
            yield return new UnitsWriter();
            yield return new JointsWriter();
            yield return new FramElementsWriter();
            yield return new AreaElementsWriter();
            yield return new AreaElementsSectionProfilesWriter();
            yield return new MaterialsWriter();
            yield return new FramElementsSectionProfilesWriter();
            yield return new ElmentsMaterialsWriter();           
            yield return new BoundaryConditionWriter();
            yield return new LoadCasesWriter();
            yield return new LoadCombinationWriter();

        }
    }
}
