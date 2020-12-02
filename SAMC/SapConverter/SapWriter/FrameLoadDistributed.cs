using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;

namespace SapConverter.SapWriter
{
    public class FrameLoadDistributed:SapSectionWriter
    {
        protected override string WriteContentHeader()
            => "TABLE:  \"FRAME LOADS - DISTRIBUTED\"";
        protected override string WriteContentData()
            => GetFrameLoads();
        string GetFrameLoads()
        {
            var framLoads = new StringBuilder();
            var frameElmnts = Model.FrameElements;
            foreach (var lodCas in Model.LoadCases)
            {
                foreach (var load in lodCas.Loads)
                {
                    if (frameElmnts.FirstOrDefault(e => e.Id.Equals(load.AppliedOnId)) != null)
                    {


                        if (load.LoadForce is LinearLoadForce)
                        {
                            framLoads.Append(WritePropty("Frame", load.AppliedOnId));
                            framLoads.Append(WritePropty("LoadPat", lodCas.Name));
                            framLoads.Append(WritePropty("CoordSys", GetCoordinate(load.LoadForce as LinearLoadForce)));
                            framLoads.Append(WritePropty("Type", GetForceType(load.LoadForce as LinearLoadForce)));
                            framLoads.Append(WritePropty("Dir", GetDirection(load.LoadForce as LinearLoadForce)));
                            framLoads.Append(WritePropty("DistType", "RelDist"));
                            framLoads.Append(WritePropty("RelDistA", 0));
                            framLoads.Append(WritePropty("RelDistB", 1));
                            //framLoads.Append(WritePropty("AbsDistA", 0));
                            //framLoads.Append(WritePropty("AbsDistB", 1));
                            framLoads.Append(GetLoadValue(load.LoadForce as LinearLoadForce));
                            framLoads.AppendLine();
                        }
                    }
                }
            }
            return framLoads.ToString();
        }
        string GetCoordinate(LinearLoadForce loadForce)
        {
            if (loadForce.Coordinates.Equals(LoadForceCoordinates.Local))
                return "Local";
            else
                return "GLOBAL";
        }
        string GetForceType(LinearLoadForce loadForce)
        {
            var loadForceVal = loadForce.ForceX ?? loadForce.ForceY ?? loadForce.ForceZ;
            if (loadForceVal !=null)
                return "Force";
            else
                return "Moment";
        }
        string GetDirection(LinearLoadForce loadForce)
        {
            if (GetCoordinate(loadForce).Equals("Local"))
            {
                if (loadForce.ForceX != null || loadForce.MomentX!=null)
                    return "1";
                else if (loadForce.ForceZ != null || loadForce.MomentZ!=null)
                    return "2";
                else
                    return "3";
            }
            else    //global coordinate system(true or projected)                
            {
                if (loadForce.Coordinates.Equals(LoadForceCoordinates.Global_Projected_Length))
                {
                    if (loadForce.ForceX != null ||loadForce.MomentX!=null)
                        return "X Proj";
                    else if (loadForce.ForceY != null || loadForce.MomentY!=null)
                        return "Y Proj";
                    else
                        return "Z Proj";
                }
                else
                {
                    if (loadForce.ForceX != null || loadForce.MomentX != null)
                        return "X";
                    else if (loadForce.ForceY != null||loadForce.MomentY != null)
                        return "Y";
                    else
                        return "Z";
                }
            }
        }
        string GetLoadValue(LinearLoadForce loadForce)
        {
            var text = new StringBuilder();
            var loadForceVal = loadForce.ForceX ?? loadForce.ForceY ?? loadForce.ForceZ;
            var loadMomentVal = loadForce.MomentX ?? loadForce.MomentY ?? loadForce.MomentZ;
            if (loadForceVal != null)
            {
                text.Append(WritePropty("FOverLA",loadForceVal ));
                text.Append(WritePropty("FOverLB", loadForceVal));
            }
            else
            {
                text.Append(WritePropty("MOverLA", loadMomentVal));
                text.Append(WritePropty("MOverLB", loadMomentVal));
            }
            return text.ToString();
        }
    }
}
