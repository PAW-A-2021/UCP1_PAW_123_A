using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_123_A.Models
{
    public partial class VwPenjualan
    {
        public string NoKwitansi { get; set; }
        public DateTime TglKwitansi { get; set; }
        public string IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; }
    }
}
