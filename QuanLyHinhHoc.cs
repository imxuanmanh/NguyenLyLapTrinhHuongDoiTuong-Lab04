using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab4
{
    public enum LoaiHinh
    {
        All,
        HinhTron,
        HinhVuong,
        HinhCN,
        HinhTG
    }
    class QuanLyHinhHoc
    {
        List<HinhHoc> dshh;
        List<HinhHoc> dskq;
        public QuanLyHinhHoc()
        {
            dshh = new List<HinhHoc>();
        }

        public HinhHoc this[int index]
        {
            get { return dshh[index]; }
            set { dshh[index] = value; }
        }

        public override string ToString()
        {
            string s = "";
            foreach (HinhHoc hh in dshh)
            {
                s += hh + "\n";
            }
            return s;
        }

        public void XuatDanhSach()
        {
            foreach (HinhHoc hh in this.dshh)
            {
                hh.XuatHinhHoc();
                Console.WriteLine();
            }
        }

        public void NhapCD()
        {
            this.dshh.Add(new HinhTG(2, 6, 5));
            this.dshh.Add(new HinhTron(1.2f));
            this.dshh.Add(new HinhCN(3, 2));
            this.dshh.Add(new HinhTG(3, 4, 5));
            this.dshh.Add(new HinhTron(1));
            this.dshh.Add(new HinhTron(3.5f));
            this.dshh.Add(new HinhVuong(2));
            this.dshh.Add(new HinhTG(6, 8, 10));
            this.dshh.Add(new HinhCN(3.5f, 2.5f));
            this.dshh.Add(new HinhVuong(5));
            this.dshh.Add(new HinhTG(4.4f, 5.1f, 3.3f));
            this.dshh.Add(new HinhVuong(1));
            this.dshh.Add(new HinhCN(3, 4));
            this.dshh.Add(new HinhTG(3.7f, 4.9f, 6.2f));

        }

        public float TongDT()
        {
            float t = 0;
            foreach (HinhHoc hh in this.dshh)
            {
                t += hh.TinhDienTich();
            }
            return t;
        }

        public void DemSoLuong(int chon)
        {
            LoaiHinh lh = (LoaiHinh)chon;
            int dem = 0;


            switch (lh)
            {
                case LoaiHinh.HinhTron:
                    foreach (HinhHoc hh in this.dshh)
                        if (hh is HinhTron)
                            dem++;
                    if (dem == 0)
                        Console.WriteLine("Trong danh sach khong co hinh tron!");
                    else Console.WriteLine("Trong danh sach co {0} hinh tron!", dem);
                    break;
                case LoaiHinh.HinhVuong:
                    foreach (HinhHoc hh in this.dshh)
                        if (hh is HinhVuong && !(hh is HinhCN))
                            dem++;
                    if (dem == 0)
                        Console.WriteLine("Trong danh sach khong co hinh vuong!");
                    else Console.WriteLine("Trong danh sach co {0} hinh vuong!", dem);
                    break;
                case LoaiHinh.HinhCN:
                    foreach (HinhHoc hh in this.dshh)
                        if (hh is HinhCN)
                            dem++;
                    if (dem == 0)
                        Console.WriteLine("Trong danh sach khong co hinh chu nhat!");
                    else Console.WriteLine("Trong danh sach co {0} hinh chu nhat!", dem);
                    break;
                case LoaiHinh.All:
                    foreach (HinhHoc hh in this.dshh)
                        dem++;
                    Console.WriteLine("Trong danh sach co tong cong {0} hinh", dem);
                    break;
            }


        }

        public void XoaAllHinhTron()
        {
            for (int i = 0; i < dshh.Count; i++)
            {
                if (dshh[i] is HinhTron)
                {
                    dshh.Remove(dshh[i]); //dshh.RemoveAt(i);
                    i--;
                }
            }

            //dshh.RemoveAll(hh => hh is HinhTron);
        }

        public void SXGiamDTHTron()
        {
            bool dk;
            for (int i = 0; i < dshh.Count - 1; i++)
                for (int j = i + 1; j < dshh.Count; j++)
                {
                    dk = dshh[i] is HinhTron &&
                        dshh[j] is HinhTron &&
                        dshh[i].TinhDienTich() < dshh[j].TinhDienTich();
                    if (dk)
                    {
                        HinhHoc hh = dshh[i];
                        dshh[i] = dshh[j];
                        dshh[j] = hh;
                    }
                }
            //--> su dung phuong Sort cua List
        }

        public float TongDTTheoLH(int loaihinh)
        {
            float t = 0;
            foreach (HinhHoc hh in this.dshh)
            {
                switch (loaihinh)
                {
                    case 0:
                        if (hh is HinhTron)
                            t += hh.TinhDienTich();
                        break;
                    case 1:
                        if (hh is HinhVuong && !(hh is HinhCN))
                            t += hh.TinhDienTich();
                        break;
                    case 2:
                        if (hh is HinhCN)
                            t += hh.TinhDienTich();
                        break;
                    default:
                        t += hh.TinhDienTich();
                        break;
                }

            }
            return t;
        }

        private float Max()
        {
            float max = 0;
            foreach (HinhHoc hh in this.dshh)
                if (hh.TinhDienTich() > max)
                    max = hh.TinhDienTich();
            return max;
        }

        private float Min()
        {
            float min = float.MaxValue;
            foreach (HinhHoc hh in this.dshh)
                if (hh.TinhDienTich() < min)
                    min = hh.TinhDienTich();
            return min;
        }

        private float HVMin()
        {
            float hvmin = float.MaxValue;
            foreach (HinhHoc hh in this.dshh)
            {
                if (hh is HinhVuong && !(hh is HinhCN) && hh.TinhDienTich() < hvmin)
                    hvmin = hh.TinhDienTich();
            }  
            return hvmin;
        }

        public List<HinhHoc> DienTichMax()
        {
            float max = Max();
            List<HinhHoc> kq = new List<HinhHoc>();
            foreach (HinhHoc hh in this.dshh)
                if (hh.TinhDienTich() == max)
                    kq.Add(hh);
            return kq;
        }

        public void SapGiam()
        {
            this.dshh.Sort((hinh1, hinh2) => hinh2.TinhDienTich().CompareTo(hinh1.TinhDienTich()));
        }

        private float HinhVuongMin()
        {
            float min = float.MaxValue;
            //List <HinhVuong> kq = new List<HinhVuong>();
            foreach (HinhHoc hh in this.dshh)
                if (hh is HinhVuong && hh.TinhDienTich() < min)
                    min = hh.TinhDienTich();
            return min;
        }

        /*public List<HinhHoc> DsHinhVuongMin()
        {
            List<HinhHoc> kq = new List<HinhHoc>();
            foreach (HinhHoc hh in this.dshh)
            {
                if (hh is HinhVuong)
                {
                    HinhVuong hv = (HinhVuong)hh;
                    if (hv.TinhDienTich() == HinhVuongMin())
                    {
                        kq.Add(hh);
                    }
                }
            }
            return kq;
        }*/

        public void SapTangHinhVuong()
        {
            for (int i = 0; i < this.dshh.Count - 1; i++)
            {
                for (int j = i + 1; j < this.dshh.Count; j++)
                {
                    if (this.dshh[i] is HinhVuong &&
                        this.dshh[j] is HinhVuong &&
                        this.dshh[i].TinhDienTich() > this.dshh[j].TinhDienTich())
                    {
                        HinhHoc temp = this.dshh[i];
                        this.dshh[i] = this.dshh[j];
                        this.dshh[j] = temp;
                    }
                }
            }
        }

        private int VtMaxCuoiCung()
        {
            int vt = 0;
            for (int i = 0; i < this.dshh.Count; i++)
            {
                if (this.dshh[i].TinhDienTich() == Max())
                    vt = i;
            }
            return vt;
        }

        public static void XuatDanhSach(List<HinhHoc> ds)
        {
            foreach (HinhHoc hh in ds)
            {
                Console.WriteLine(hh.ToString());
            }
        }

        public void Them(HinhHoc hh)
        {
            this.dshh.Add(hh);
        }

        public int SoPt()
        {
            return this.dshh.Count();
        }

        #region Lab 4
        public QuanLyHinhHoc HinhLonNhat()
        {
            QuanLyHinhHoc kq = new QuanLyHinhHoc();
            foreach (HinhHoc hh in this.dshh)
            {
                if (hh.TinhDienTich() == this.Max())
                    kq.Them(hh);
            }
            return kq;
        }

        public QuanLyHinhHoc DSHinhVuongNhoNhat()
        {
            QuanLyHinhHoc kq = new QuanLyHinhHoc();
            foreach (HinhHoc hh in this.dshh)
                if (hh is HinhVuong && hh.TinhDienTich() == this.HVMin())
                    kq.Them(hh);
            return kq;
        }

        public void SapTang()
        {
            this.dshh.Sort((hinh1, hinh2) => hinh1.TinhDienTich().CompareTo(hinh2.TinhDienTich()));
        }

        public float TongDienTichHinhTron()
        {
            float sum = 0;
            foreach(HinhHoc hh in this.dshh)
            {
                if (hh is HinhTron)
                    sum += hh.TinhDienTich();
            }
            return sum;
        }

        public void SapTangHinhTron()
        {
            for (int i = 0; i < this.dshh.Count - 1; i++)
            {
                for (int j = i + 1; j < this.dshh.Count; j++)
                {
                    if (this.dshh[i] is HinhTron &&
                        this.dshh[j] is HinhTron &&
                        this.dshh[i].TinhDienTich() > this.dshh[j].TinhDienTich())
                    {
                        HinhHoc temp = this.dshh[i];
                        this.dshh[i] = this.dshh[j];
                        this.dshh[j] = temp;
                    }
                }
            }
        }

        public QuanLyHinhHoc DienTichNhoHonX(float x)
        {
            QuanLyHinhHoc kq = new QuanLyHinhHoc();
            foreach (HinhHoc hh in this.dshh)
                if (hh.TinhDienTich() < x)
                    kq.Them(hh);
            return kq;
        }

        public float SoLuongTheoLoaiHinh(int lh)
        {
            int dem = 0;
            foreach (HinhHoc hh in this.dshh)
            {
                switch (lh)
                {
                    case 1:
                        if (hh is HinhTron)
                            dem++;
                        break;

                    case 2:
                        if (hh is HinhVuong && !(hh is HinhCN))
                            dem++;
                        break;

                    case 3:
                        if (hh is HinhCN)
                            dem++;
                        break;

                    case 4:
                        if (hh is HinhTG)
                            dem++;
                        break;

                    default:
                        break;
                }

            }
            return dem;
        }

        public void XoaTatCaTheoLoaiHinh(int lh)
        {
            for (int i = 0; i < this.dshh.Count; i++)
            {
                switch (lh)
                {
                    case 1:
                        if (this.dshh[i] is HinhTron)
                        {
                            this.dshh.RemoveAt(i);
                            i--;
                        }
                        break;
                    case 2:
                        if (this.dshh[i] is HinhVuong && !(this.dshh[i] is HinhCN))
                        {
                            this.dshh.RemoveAt(i);
                            i--;
                        }
                        break;
                    case 3:
                        if (this.dshh[i] is HinhCN)
                        {
                            this.dshh.RemoveAt(i);
                            i--;
                        }
                        break;
                    case 4:
                        if (this.dshh[i] is HinhTG)
                        {
                            this.dshh.RemoveAt(i);
                            i--;
                        }
                        break;
                }
            }
        }

        public void ChenHinhTron(float bk)
        {
            HinhTron ht = new HinhTron(bk);
            int vt = VtMaxCuoiCung();
            this.dshh.Insert(VtMaxCuoiCung(), ht);
            Console.WriteLine("Da chen xong! \nDanh sach sau khi chen:");
            for (int i = 0; i < vt; i++)
            {
                this.dshh[i].XuatHinhHoc();
                Console.WriteLine();
            }
            this.dshh[vt].XuatHinhHoc();
            Console.WriteLine(" (Hinh duoc chen)");
            this.dshh[vt+1].XuatHinhHoc();
            Console.WriteLine(" (Hinh lon nhat cuoi cung)");
            for (int i = vt + 2; i < this.dshh.Count; i++)
            {
                this.dshh[i].XuatHinhHoc();
                Console.WriteLine();
            } 
                
        }

        public void XoaHinhVuongNhoNhat()
        {
            for (int i = 0; i < this.dshh.Count; i++)
                if (this.dshh[i] is HinhVuong && !(this.dshh[i] is HinhCN) && this.dshh[i].TinhDienTich() == HVMin())
                {
                    this.dshh.Remove(this.dshh[i]);
                    i--;
                }
        }

        public void SapXep()
        { 
            for (int i = 0; i<this.dshh.Count - 1; i++)
            {
                for(int j = i+1;j<this.dshh.Count; j++)
                {
                    if (!(this.dshh[i] is HinhTron) && (this.dshh[j] is HinhTron) ||
                        (this.dshh[i] is HinhTron) && (this.dshh[j] is HinhTron) && this.dshh[i].TinhDienTich() < this.dshh[j].TinhDienTich() ||
                        !(this.dshh[i] is HinhTron) && !(this.dshh[j] is HinhTron) && this.dshh[i].TinhDienTich() > this.dshh[j].TinhDienTich()
                        )
                    {
                        HinhHoc temp = this.dshh[i];
                        this.dshh[i] = this.dshh[j];
                        this.dshh[j] = temp;
                    }
                }
            }
        }

        public void SapGiamHinhTG()
        {
            for (int i = 0; i < this.dshh.Count - 1; i++)
            {
                for (int j = i + 1; j < this.dshh.Count; j++)
                {
                    if (this.dshh[i] is HinhTG &&
                        this.dshh[j] is HinhTG &&
                        this.dshh[i].TinhDienTich() < this.dshh[j].TinhDienTich())
                    {
                        HinhHoc temp = this.dshh[i];
                        this.dshh[i] = this.dshh[j];
                        this.dshh[j] = temp;
                    }
                }
            }
        }

        private float TGMin()
        {
            float tgmin = float.MaxValue;
            foreach (HinhHoc hh in this.dshh)
            {
                if (hh is HinhTG)
                {
                    tgmin = hh.TinhDienTich();
                    break;
                }
            }
            return tgmin;
        }

        public void XoaTamGiacNhoNhat()
        {
            /*foreach (HinhHoc hh in this.dshh)
                if (hh is HinhTG && hh.TinhDienTich() == TGMin())
                    this.dshh.Remove(hh);*/
            float min = this.TGMin();
            for (int i = 0; i < this.dshh.Count; i++)
            {
                if (this.dshh[i] is HinhTG && this.dshh[i].TinhDienTich() == min)
                {
                    this.dshh.Remove(this.dshh[i]);
                    i--;
                }
            }
        }
        #endregion
    }
}
