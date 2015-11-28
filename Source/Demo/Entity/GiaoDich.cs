using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.NetworkOperators;

namespace Entity
{
    public enum LoaiGD
    {
        Thu,
        Chi,
        Vay,
        ChoVay,
        TietKiem
    }
    public class GiaoDich
    {
        public string Ten { get; set; }
        public int SoTien { get; set; }
        public DateTime Ngay { get; set; }
        public string NguoiThamGia { get; set; }
        public string GhiChu { get; set; }
        public NhomGD NhomGd { get; set; }
    }   
}
