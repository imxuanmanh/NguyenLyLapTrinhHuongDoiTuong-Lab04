using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab4
{
    class HinhTron : HinhHoc
    {
        public float BanKinh
        {
            get { return this.Canh; }
        }
        public HinhTron(float bk) : base(bk)
        { }
        public override string ToString()
        {
            return string.Format("Hinh Tron co ban kinh = {0}, dien tich = {1}, chu vi = {2}",
                this.Canh, this.TinhDienTich(), this.TinhChuVi());
        }

        public override void XuatHinhHoc()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(string.Format("Hinh Tron co ban kinh = {0}, dien tich = {1}, chu vi = {2}",
                this.Canh, this.TinhDienTich(), this.TinhChuVi()));
            Console.ResetColor();
        }

        public override float TinhDienTich()
        {
            return (float)Math.Round(Math.PI * this.Canh * this.Canh, 2);
        }

        public override float TinhChuVi()
        {
            return (float)Math.Round(Math.PI * this.Canh * 2, 2);
        }


    }
}
