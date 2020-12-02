using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaadConverter.StaadWriter
{
    public class FramElementsWriter:ElementsJointsWriter
    {
        protected override string WriteContentData()
            => WriteElementsJonits(Model.FrameElements.ToList());
        protected override string WriteContentHeader()
            => "MEMBER INCIDENCES";
    }
}
