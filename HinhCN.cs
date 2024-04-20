using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab4
{
    class HinhCN : HinhVuong
    {
        private float _rong;
        public float Dai
        {
            get { return this.Canh; }
        }
        public float Rong
        {
            get { return _rong; }
            set
            {
                if (value <= 0)
                    value = 1;
                _rong = value;
            }
        }
        public HinhCN(float d, float r) : base(d)
        {
            this.Rong = r;
        }
        public override float TinhDienTich()
        {
            return this.Dai * this.Rong;
        }

        public override float TinhChuVi()
        {
            return 2 * (this.Dai + this.Rong);
        }

        public override string ToString()
        {
            return String.Format("Hinh Chu Nhat co chieu dai = {0}, chieu rong = {1}, dien tich = {2}, chu vi = {3}",
                this.Dai, this.Rong, this.TinhDienTich(), this.TinhChuVi());
        }

        public override void XuatHinhHoc()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(String.Format("Hinh Chu Nhat co chieu dai = {0}, chieu rong = {1}, dien tich = {2}, chu vi = {3}",
                this.Dai, this.Rong, this.TinhDienTich(), this.TinhChuVi()));
            Console.ResetColor();
        }

    }
}

