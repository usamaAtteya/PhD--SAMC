using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;

namespace StaadConverter.StaadWriter
{
    public class StaadWriter : DocumentWriter
    {
        public StaadWriter(IDocumentSectionsWritersProvider secsWritesProvider) : base(secsWritesProvider)
        {
        }

        protected override string WriteContentHeader()
       => "STAAD SPACE";
        protected override string WriteContentFooter()
        => "FINISH";
        //public string WrtJointsCordnts()
        //{
        //    var JontsCordnts = new StringBuilder().AppendLine("JOINT COORDINATES");
        //    JontsCordnts.Append(WrtJointCordnts(_model.ElementsPoints));
        //    return JontsCordnts.AppendLine().ToString();
        //}        
        ////string WrtHeadr(string header)
        ////    => header;
        //string WrtJointCordnts(HashSet<Point> points)
        //{
        //    //=> $"{point.Id} {point.X} {point.Y} {point.Z};";
        //    var jontsCordnts = new StringBuilder();
        //    points.ToList().ForEach(p => jontsCordnts.Append($"{p.Id} {p.X} {p.Y} {p.Z};"));
        //    return jontsCordnts.ToString();
        //}


        //public string WrtAreaElmntsPropts(List<Element> AreaElmnts)
        //    => GetElmntsPropts(AreaElmnts, "ELEMENT PROPERTY");
        //public string WrtFramElmntsPropts(List<Element> FramElmnts)
        //    => GetElmntsPropts(FramElmnts, "MEMBER PROPERTY");

        //public string WrtMaterials(List<Material> MatLst)
        //    => GetMaterialsPropts(MatLst, "DEFINE MATERIAL START", "END DEFINE MATERIAL");
        //string GetMaterialsPropts(List<Material> Materials, string header, string footer)
        //{
        //    var MatsPropts = new StringBuilder().AppendLine(header);
        //    Materials.ForEach(m => MatsPropts.Append(GetMatPropts(m)));
        //    return MatsPropts.AppendLine(footer).ToString();
        //}
        //string GetMatPropts(Material material)
        //{
        //    var MatPropts = new StringBuilder();
        //    MatPropts.AppendLine($"ISOTROPIC {material.Name}");
        //    MatPropts.AppendLine($"E {material.YoungModulus}");
        //    MatPropts.AppendLine($"POISSON {material.PoissonRatio}");
        //    MatPropts.AppendLine($"DENSITY {material.WeightPerUnitVolume}");
        //    MatPropts.AppendLine($"G {material.ShearModulus}");
        //    MatPropts.AppendLine($"ALPHA {material.ThermalExpanssionC}");
        //    return MatPropts.ToString();
        //}

    }
}
