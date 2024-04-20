using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab4
{
    class HinhTG : HinhHoc
    {
        private float canh1;
        public float Canh1 
        { 
            get { return canh1; }
            set { canh1 = value; }
        }
        private float canh2;
        public float Canh2
        {
            get { return canh2; }
            set { canh2 = value; }
        }
        private float canh3;
        public float Canh3
        {
            get { return canh3; }
            set { canh3 = value; }
        }
        public HinhTG(float a, float b, float c) : base(a)
        {
            Canh1 = a;
            Canh2 = b;
            Canh3 = c;
        }

        public float p
        { get { return (Canh1 + Canh2 + Canh3) / 2; } }

        public override float TinhDienTich()
        {
            float dt = (float)Math.Sqrt(p*(p-Canh1)*(p-Canh2)*(p-Canh3));
            return (float)Math.Round(dt, 2);
        }

        public override float TinhChuVi()
        {
            return Canh1 + Canh2 + Canh3;
        }

        public override string ToString()
        {
            return String.Format("Hinh Tam Giac co 3 canh la {0}, {1}, {2}, dien tich = {3}, chu vi = {4}",
                Canh1, Canh2, Canh3, TinhDienTich(), TinhChuVi());
        }

        public override void XuatHinhHoc()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(String.Format("Hinh Tam Giac co 3 canh la {0}, {1}, {2}, dien tich = {3}, chu vi = {4}",
                Canh1, Canh2, Canh3, TinhDienTich(), TinhChuVi()));
            Console.ResetColor();
        }
    }
}
