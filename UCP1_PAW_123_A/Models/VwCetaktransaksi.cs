using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_123_A.Models
{
    public partial class VwCetaktransaksi
    {
        public string NoKwitansi { get; set; }
        public DateTime TglKwitansi { get; set; }
        public string IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; }
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public int Harga { get; set; }
        public int Jumlah { get; set; }
        public int? JumlahBayar { get; set; }
    }
}
