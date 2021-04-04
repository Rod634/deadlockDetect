using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlockDetect.entities
{
    public class Data
    {

        public int Id { get; set; }

        public string Content { get; set; }

        public string State { get; set; }
        public string usingby { get; set; }
    }
}
