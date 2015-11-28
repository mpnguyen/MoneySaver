using System.Collections.Generic;

namespace Entity
{
    public class SoThuChi
    {
        private readonly List<GiaoDich> listThu = new List<GiaoDich>();
        private readonly List<GiaoDich> listChi = new List<GiaoDich>();

        public List<GiaoDich> GetListThu()
        {
            return listThu;
        }

        public List<GiaoDich> GetListChi()
        {
            return listChi;
        }

        public bool AddGiaoDichThu(GiaoDich giaoDich)
        {
            listThu.Add(giaoDich);
            return true;
        }

        public bool AddGiaoDichChi(GiaoDich giaoDich)
        {
            listChi.Add(giaoDich);
            return true;
        }

    }
}