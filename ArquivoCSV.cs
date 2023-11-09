using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioDVH
{
    public partial class ArquivoCSV
    {
        public string Estrutura { get; set; }
        public string Constraints { get; set; }
        public string Aceitavel { get; set; }
        public string LimiteDose { get; set; }

        public ArquivoCSV() { }
    }
}
