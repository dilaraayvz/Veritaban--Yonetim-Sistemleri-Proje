using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyonu
{
    public interface Kisi
    {
        int id { get; set; }
        string ad { get; set; }
        string soyad { get; set; }
        string telefon { get; set; }
        string email { get; set; }

    }
}
