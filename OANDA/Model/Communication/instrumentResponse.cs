using System;
using System.Collections.Generic;
using System.Text;

namespace OANDA.Model.Communication
{
   public  class InstrumentResponse
    {
        public List<instrument> instruments { get; set; }

    }
    public class instrument
    {
        public string name { get; set; }
        public string type { get; set; }
        public string displayName { get; set; }
        public int pipLocation { get; set; }
    }

}
