using System;
using System.Collections.Generic;
using System.Text;

namespace SAMC2
{
    public class Section
    {
      // public string Id { get { return Profile.SectionProfileName; } }
        public Material Material { get; set; }
        public SectionProfile Profile { get; set; }
    }
}
