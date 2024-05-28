using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGara
{
    internal class TaiKhoan
    {
        private string taikhoan;
        private string matkhau;
        private string ten;
        private string sdt;
        private string vaitro;

        public TaiKhoan(string taikhoan,string matkhau, string ten,string sdt,string vaitro)
        {
            this.taikhoan = taikhoan;
            this.matkhau  = matkhau;
            this.ten = ten;
            this.sdt = sdt;
            this.vaitro = vaitro;
        }

        public string Taikhoan
        {
            get => taikhoan;
            set => taikhoan = value;
        }

        public string Matkhau
        {
            get => matkhau;
            set => matkhau = value;
        }

        public string Ten
        {
            get => ten;
            set => ten = value;
        }

        public string Vaitro
        {
            get => vaitro;
            set => vaitro = value;
        }

        public string Sdt
        {
            get => sdt;
            set => sdt = value;
        }


    }
}
