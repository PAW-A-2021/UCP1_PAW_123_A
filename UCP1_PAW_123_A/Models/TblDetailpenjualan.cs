using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_123_A.Models
{
    public partial class TblDetailpenjualan
    {
        public string NoKwitansi { get; set; }
        public string KodeBarang { get; set; }
        public int Jumlah { get; set; }

        public virtual TblBarang KodeBarangNavigation { get; set; }
        public virtual TblPenjualan NoKwitansiNavigation { get; set; }
    }
}
