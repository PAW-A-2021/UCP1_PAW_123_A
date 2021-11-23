using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_123_A.Models
{
    public partial class VwDetail
    {
        public string NoKwitansi { get; set; }
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public int Harga { get; set; }
        public string Satuan { get; set; }
        public int Jumlah { get; set; }
    }
}
