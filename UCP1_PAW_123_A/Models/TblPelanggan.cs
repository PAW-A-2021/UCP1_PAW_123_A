using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_123_A.Models
{
    public partial class TblPelanggan
    {
        public TblPelanggan()
        {
            TblPenjualans = new HashSet<TblPenjualan>();
        }

        public string IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; }
        public string Alamat { get; set; }
        public string NoTelepon { get; set; }

        public virtual ICollection<TblPenjualan> TblPenjualans { get; set; }
    }
}
