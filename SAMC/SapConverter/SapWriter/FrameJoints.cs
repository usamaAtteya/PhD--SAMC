using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class FrameJoints:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"CONNECTIVITY - FRAME\"";
        protected override string WriteContentData()
            => WriteFrameJoints();

        string WriteFrameJoints()
        {
            var txt = new StringBuilder();
            foreach (var frame in Model.FrameElements)
            {
                txt.Append(WritePropty("Frame",frame.Id));
                txt.Append(WritePropty("JointI",frame.Vertices[0].Id));
                txt.Append(WritePropty("JointJ",frame.Vertices[1].Id));
                txt.AppendLine();
            }
            return txt.ToString();
        }
    }
}
