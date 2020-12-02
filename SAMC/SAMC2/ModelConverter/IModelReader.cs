using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMC2.ModelConverter
{
   public interface IModelReader
    {
        Model GetModel(string filePath);
    }
}
