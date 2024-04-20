using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab4
{
    class HinhHoc
    {
        protected float _canh;

        public float Canh
        {
            get { return _canh; }
            set
            {
                if (value <= 0)
                    value = 1;
                this._canh = value;
            }
        }

        public HinhHoc()
        {
            this.Canh = 0;
        }

        public HinhHoc(float c)
        {
            this.Canh = c;
        }

        public virtual float TinhDienTich()
        {
            return 0;
        }

        public virtual float TinhChuVi()
        {
            return 0;
        }

        public override string ToString()
        {
            return String.Format("Hinh hoc:\tc={0}\tDT={1}\tCV={2}",
              this.Canh, this.TinhDienTich(), this.TinhChuVi());
        }

        public virtual void XuatHinhHoc()
        {
            Console.WriteLine("Thong tin cua hinh");
        }
    }
}
