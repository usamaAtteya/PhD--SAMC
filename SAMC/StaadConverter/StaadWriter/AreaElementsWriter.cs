using System.Linq;

namespace StaadConverter.StaadWriter
{
    public class AreaElementsWriter:ElementsJointsWriter
    {
        protected override string WriteContentHeader()
            => "ELEMENT INCIDENCES SHELL";
        protected override string WriteContentData()
            => WriteElementsJonits(Model.AreaElements.ToList());
    }
}
