using System;
using System.Collections.Generic;

#nullable disable

namespace ApiCoreDemo.Models
{
    public partial class Nrldatum
    {
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public string SignDocVer { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
