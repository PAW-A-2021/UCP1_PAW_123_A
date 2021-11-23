using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_123_A.Models
{
    public partial class TblBarang
    {
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public int Harga { get; set; }
        public int Stok { get; set; }
        public string Satuan { get; set; }
    }
}
