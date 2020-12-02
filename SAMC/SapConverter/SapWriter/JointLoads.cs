using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class JointLoads:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"JOINT LOADS - FORCE\"";
        protected override string WriteContentData()
            => WriteJointsLoads();
        string WriteJointsLoads()
        {            
            var text = new StringBuilder();
            var elmntsPoints = Model.ElementsPoints;
            foreach (var loadCase in Model.LoadCases)
            {
                foreach (var load in loadCase.Loads)
                {
                    if(load.LoadForce is PointLoadForce)
                    {
                        if (elmntsPoints.FirstOrDefault(e => e.Id.Equals(load.AppliedOnId)) != null)
                        {
                            text.Append(WritePropty("Joint", load.AppliedOnId));
                            text.Append(WritePropty("LoadPat", loadCase.Name));
                            text.Append(WritePropty("CoordSys", "GLOBAL"));
                            text.Append(WritePropty("F1", (load.LoadForce as PointLoadForce).ForceX ?? 0));
                            text.Append(WritePropty("F2", (load.LoadForce as PointLoadForce).ForceY ?? 0));
                            text.Append(WritePropty("F3", (load.LoadForce as PointLoadForce).ForceZ ?? 0));
                            text.Append(WritePropty("M1", (load.LoadForce as PointLoadForce).MomentX ?? 0));
                            text.Append(WritePropty("M2", (load.LoadForce as PointLoadForce).MomentY ?? 0));
                            text.Append(WritePropty("M3", (load.LoadForce as PointLoadForce).MomentZ ?? 0));
                            text.AppendLine();
                        }
                    }
                }
            }
            return text.ToString();            
        }
    }
}
