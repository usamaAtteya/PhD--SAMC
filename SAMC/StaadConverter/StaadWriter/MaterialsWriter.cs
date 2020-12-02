using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAMC2;
using SAMC2.ModelConverter;

namespace StaadConverter.StaadWriter
{
    public class MaterialsWriter:DocumentSectionWriter
    {
        protected override string WriteContentHeader()
            => "DEFINE MATERIAL START";
        protected override string WriteContentFooter()
            => "END DEFINE MATERIAL";
        protected override string WriteContentData()
            => GetMaterialsPropts(Model.Materials.ToList());

        string GetMaterialsPropts(List<Material> Materials)
        {
            var MatsPropts = new StringBuilder();
            Materials.ForEach(m => MatsPropts.Append(GetMatPropts(m)));
            return MatsPropts.ToString();
        }
        string GetMatPropts(Material material)
        {
            var MatPropts = new StringBuilder();
            MatPropts.AppendLine($"ISOTROPIC {material.Name.Replace(" " , "")}");
            MatPropts.AppendLine($"E {material.YoungModulus}");
            MatPropts.AppendLine($"POISSON {material.PoissonRatio}");
            MatPropts.AppendLine($"DENSITY {material.WeightDensity}");
            MatPropts.AppendLine($"G {material.ShearModulus}");
            MatPropts.AppendLine($"ALPHA {material.ThermalExpanssionC}");
            if ((material.Type != MaterialType.Other) && (material.Type != null))
                MatPropts.AppendLine($"TYPE {material.Type.ToString().ToUpper()}");
            return MatPropts.ToString();
        }
    }
}
