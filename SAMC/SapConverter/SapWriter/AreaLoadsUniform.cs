using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
namespace SapConverter.SapWriter
{
    public class AreaLoadsUniform:SapSectionWriter
    {
        //List<Load> _areaLoads = Model.LoadCases.SelectMany(lc => lc.Loads).Where(l => l.LoadForce is SurfaceLoadForce).ToList();
        protected override string WriteContentHeader()
            => "TABLE:  \"AREA LOADS - UNIFORM\"";
        protected override string WriteContentData()
            => GetAreaLoads(Model.LoadCases.SelectMany(lc => lc.Loads).Where(l=>l.LoadForce is SurfaceLoadForce));
        string GetAreaLoads(IEnumerable<Load> loads)
        {
            var areaLoads = new StringBuilder();
            var areaElmnts = Model.AreaElements;
            foreach (var load in loads)
            {
                if (areaElmnts.FirstOrDefault(e => e.Id.Equals(load.AppliedOnId)) != null)
                {
                    areaLoads.Append(WritePropty("Area", load.AppliedOnId));
                    areaLoads.Append(WritePropty("LoadPat", GetLoadPattern(load)));
                    areaLoads.Append(WritePropty("CoordSys", GetCoordinate(load.LoadForce as SurfaceLoadForce)));
                    areaLoads.Append(WritePropty("Dir", GetDirection(load.LoadForce as SurfaceLoadForce)));
                    areaLoads.Append(WritePropty("UnifLoad", GetLoadValue(load)));
                    areaLoads.AppendLine();
                }
            }
            return areaLoads.ToString();
        }
        string GetCoordinate(SurfaceLoadForce load)
        {            
            if (load.Coordinates.Equals(LoadForceCoordinates.Local))
                return "Local";
            else
                return "GLOBAL";
        }
        string GetDirection(SurfaceLoadForce load)
        {            
            if (GetCoordinate(load).Equals("Local"))               
            {
                if (load.ForceX != null)
                    return "1";
                else if (load.ForceY != null)
                    return "2";
                else
                    return "3";
            }
            else    //global coordinate system(true or projected)                
            {
                if(load.Coordinates.Equals(LoadForceCoordinates.Global_Projected_Length))
                {
                    if (load.ForceX != null)
                        return "X Proj";
                    else if (load.ForceY != null)
                        return "Y Proj";
                    else
                        return "Z Proj";
                }
                else
                {
                    if (load.ForceX != null)
                        return "X";
                    else if (load.ForceY != null)
                        return "Y";
                    else
                        return "Z";
                }
            }              
        }
        double GetLoadValue(Load load)
        {
            if (load.LoadForce.ForceX != null)
                return load.LoadForce.ForceX.Value;
            else if (load.LoadForce.ForceY != null)
                return load.LoadForce.ForceY.Value;
            else
                return load.LoadForce.ForceZ.Value;
        }
        string GetLoadPattern(Load currentload)
        {
            //=> Model.LoadCases.Find(l => l.Loads.Contains(load)).Name.ToString().ToUpper();
            foreach (var loadCase in Model.LoadCases)
            {
                foreach (var load in loadCase.Loads)
                {
                    if (currentload.LoadForce.ToString().Equals(load.LoadForce.ToString()))
                        return loadCase.Name;
                }
            }
            return "Not Impelmented Area Load";
        }

    }
}
