using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SBE_ST_ActionsLog
    {
        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime Data { get; set; }
        public string Post { get; set; }
        public int Usuario { get; set; }
    }
}
