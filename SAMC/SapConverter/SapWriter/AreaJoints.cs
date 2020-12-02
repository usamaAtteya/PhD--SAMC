using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class AreaJoints:ElementsJoints
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"CONNECTIVITY - AREA\"";
        protected override string WriteContentData()
            => Model.AreaElements.Any()? WriteElmntsJoints(Model.AreaElements):"";   
        
    }
}
