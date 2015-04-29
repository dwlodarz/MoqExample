using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqExample.Data.Types
{
    public class SampleEvenMoreComplexType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SampleComplexType> ListOfSampleComplexTypes { get; set; }
    }
}
