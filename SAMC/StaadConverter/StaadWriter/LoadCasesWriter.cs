using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;

namespace StaadConverter.StaadWriter
{
    public class LoadCasesWriter:DocumentSectionWriter
    {
        protected override string WriteContentData()
        {
            var LoadCasesData = new StringBuilder();
            Model.LoadCases.ForEach(l => LoadCasesData.Append(WriteLoadCase(l)));
            return LoadCasesData.ToString();
        }
        string WriteLoadCase(LoadCase LoadCase)
        {
            var text = new StringBuilder().AppendLine($"LOAD {LoadCase.Id} LOADTYPE {LoadCase.LoadCaseType} TITLE {LoadCase.Name}");
            text.Append(GetLoadCaseLoads(LoadCase.Loads));
            return text.ToString();
        }
        string GetLoadCaseLoads(List<Load> LoadCaseLoads)
        {
            var loadsData = new StringBuilder();
            loadsData.Append(WriteAreaLoads(LoadCaseLoads.Where(l => l.LoadForce is SurfaceLoadForce)));
            loadsData.Append(WritePointLoads(LoadCaseLoads.Where(l => l.LoadForce is PointLoadForce)));
            loadsData.Append(WriteFrameLoads(LoadCaseLoads.Where(l => l.LoadForce is LinearLoadForce)));            
            return loadsData.ToString();
        }
        string WriteAreaLoads(IEnumerable<Load> areaLoadsLst)
        {
            if (!areaLoadsLst.Any())
                return "";
            var areaElmnts = Model.AreaElements;
            return CaseLoads(areaLoadsLst.Where(p => areaElmnts.FirstOrDefault(ep => ep.Id.Equals(p.AppliedOnId)) != null), "ELEMENT LOAD");
        }
        string WritePointLoads(IEnumerable<Load> pointLoadsLst)
        {
            if (!pointLoadsLst.Any())
                return "";
            var elmntsPoint = Model.ElementsPoints;
            return CaseLoads(pointLoadsLst.Where(p => elmntsPoint.FirstOrDefault(ep=>ep.Id.Equals(p.AppliedOnId))!=null), "JOINT LOAD");
        }
        string WriteFrameLoads(IEnumerable<Load> framLoadsLst)
        {
            if (!framLoadsLst.Any())
                return "";
            var frmaeElmnts = Model.FrameElements;
            return CaseLoads(framLoadsLst.Where(p => frmaeElmnts.FirstOrDefault(ep => ep.Id.Equals(p.AppliedOnId)) != null), "MEMBER LOAD");
        }
        string  CaseLoads(IEnumerable<Load> loads,string title)
        {
            var caseLoads = new StringBuilder().AppendLine(title);            
            loads.GroupBy(l => l.LoadForce.ToString()).ToList().ForEach
                (g => caseLoads.AppendLine($"{string.Join(" ",g.Select(l=>l.AppliedOnId))} {WriteLoadForce(g.First().LoadForce)}"));            
            return caseLoads.ToString();            
        }
        
        string WriteLoadForce(LoadForce loadForce)
           => loadForce is LinearLoadForce ? WriteLoadForce((LinearLoadForce)loadForce) :
            loadForce is SurfaceLoadForce ? WriteLoadForce((SurfaceLoadForce)loadForce) :
             WriteLoadForce((PointLoadForce)loadForce);
        string WriteLoadForce(LinearLoadForce loadForce)
            => $"UNI {GetLoadCoordinates(loadForce)}{GetLoadDirection(loadForce)}";        

        string GetLoadCoordinates(LinearLoadForce loadForce)
           => loadForce.Coordinates == LoadForceCoordinates.Global_True_Length ? "G"
           : loadForce.Coordinates == LoadForceCoordinates.Global_Projected_Length ? "P"
           : "";
        string GetLoadDirection(LinearLoadForce loadForce)
            => loadForce.ForceX != null ? $"X {loadForce.ForceX}"
            : loadForce.ForceY != null ? $"Y {loadForce.ForceY}"
            : $"Z {loadForce.ForceZ}";

        
        string WriteLoadForce(SurfaceLoadForce loadForce)
            => GetSurfaceLoadFormat($"PR {GetLoadCoordinates(loadForce)}{GetLoadDirection(loadForce)}");
        string GetSurfaceLoadFormat(string surfaceLoadForce)
        {
            string modelLocalZFormat = "LZ ";
            string staadLocalZFormat = "";
            return surfaceLoadForce.Replace(modelLocalZFormat, staadLocalZFormat);
        }

        string GetLoadCoordinates(SurfaceLoadForce loadForce)
           => loadForce.Coordinates == LoadForceCoordinates.Local ? "L"           
           : "G";
        string GetLoadDirection(SurfaceLoadForce loadForce)
            => loadForce.ForceX != null ? $"X {loadForce.ForceX}"
            : loadForce.ForceY != null ? $"Y {loadForce.ForceY}"
            : $"Z {loadForce.ForceZ}";
        
        string WriteLoadForce(PointLoadForce loadForce)
            => $"FX {loadForce.ForceX ??0} FY {loadForce.ForceY??0 } FZ {loadForce.ForceZ ??0} MX {loadForce.MomentX??0} MY {loadForce.MomentY??0} MZ {loadForce.MomentZ??0}";

    }
}
