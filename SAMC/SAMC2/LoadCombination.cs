using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class LoadCombination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LoadCombinationItem> LoadCombinationItems { get; set; }
    }
}
