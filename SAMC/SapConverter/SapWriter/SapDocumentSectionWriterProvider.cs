using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2.ModelConverter;

namespace SapConverter.SapWriter
{
    public class SapDocumentSectionWriterProvider:IDocumentSectionsWritersProvider
    {
       public IEnumerable<DocumentSectionWriter>GetSectionsWriters()
        {
            yield return new AreaSectionAssignment();
            yield return new AreaSectionProperties();
            yield return new LoadCaseAssignment1();
            yield return new LoadCombinations();
            yield return new AreaLoadsUniform();
            yield return new AreaJoints();
            yield return new FrameJoints();
            yield return new FrameLoadDistributed();
            yield return new FramSectionsAssignment();
            yield return new FrameSectionsPropertiesGeneral();
            yield return new GridLines();
            yield return new JointsCoordinates();
            yield return new JointLoads();
            yield return new JointsBoundaryConditions();
            yield return new LoadCasesDefinition();
            yield return new LoadPatternDefinitions();
            yield return new MaterialsGeneralProperties();
            yield return new MaterialsMechanicalProperties();
            yield return new ProgramControl();
                  }
    }
}
