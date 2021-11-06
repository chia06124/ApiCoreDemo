using System;
using System.Collections.Generic;

#nullable disable

namespace ApiCoreDemo.Models
{
    public partial class SysFormDatum
    {
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public string Com { get; set; }
        public string Dept { get; set; }
        public string FormStatus { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
