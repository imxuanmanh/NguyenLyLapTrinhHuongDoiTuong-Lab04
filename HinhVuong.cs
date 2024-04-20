using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab4
{
    class HinhVuong : HinhHoc
    {
        public HinhVuong(float c) : base(c)
        {}

        public override float TinhDienTich()
        {
            return this.Canh * this.Canh;
        }

        public override float TinhChuVi()
        {
            return 4 * this.Canh;
        }

        public override string ToString()
        {

            return String.Format("Hinh Vuong co canh = {0}, dien tich = {1}, chu vi = {2}",
                this.Canh, this.TinhDienTich(), this.TinhChuVi());
        }

        public override void XuatHinhHoc()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(String.Format("Hinh Vuong co canh = {0}, dien tich = {1}, chu vi = {2}",
                this.Canh, this.TinhDienTich(), this.TinhChuVi()));
            Console.ResetColor();
        }
    }
}
