using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab4
{
    class MenuCT
    {
        #region     Menu
        enum Menu
        {
            Thoat = 0,
            NhapCD,
            XuatDS,
            DienTichMax,
            DSHinhVuongMin,
            SapTangTheoDienTich,
            TongDienTichHinhTron,
            SapTangHinhTron,
            DSDienTichNhoHonX,
            DemSoLuongTheoLoai,
            XoaTatCaTheoLoai,
            ChenHinhTron,
            XoaHinhVuongNhoNhat,
            SapXepDanhSach,
            SapGiamHinhTamGiac,

            XoaHinhTamGiacNhoNhat       // Cuoi cung 

        }
        QuanLyHinhHoc dshh;
        QuanLyHinhHoc dskq;

        public MenuCT()
        {
            dshh = new QuanLyHinhHoc();
        }

        private static void XuatMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                CHUONG TRINH QUAN LY HINH HOC                ");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("Danh sach chuc nang:");
            Console.ResetColor();
            Console.WriteLine(" 0. Thoat chuong trinh");
            Console.WriteLine(" 1. Nhap danh sach co dinh");
            Console.WriteLine(" 2. Xuat danh sach");
            Console.WriteLine(" 3. Tim hinh co dien tich lon nhat");
            Console.WriteLine(" 4. Tim danh sach hinh vuong co dien tich nho nhat");
            Console.WriteLine(" 5. Sap xep theo chieu tang dien tich");
            Console.WriteLine(" 6. Tinh tong dien tich hinh tron co trong danh sach");
            Console.WriteLine(" 7. Sap xep danh sach hinh tron tang theo dien tich");
            Console.WriteLine(" 8. Tim danh sach hinh co dien tich nho hon x");
            Console.WriteLine(" 9. Dem so luong theo loai hinh");
            Console.WriteLine("10. Xoa tat ca theo loai hinh");
            Console.WriteLine("11. Chen hinh tron truoc hinh cuoi cung co dien tich lon nhat");
            Console.WriteLine("12. Xoa hinh vuong co dien tich nho nhat");
            Console.WriteLine("13. Sap xep danh sach hinh hoc");
            Console.WriteLine("14. Sap xep hinh tam giac giam dan theo dien tich");
            Console.WriteLine("15. Xoa hinh tam giac nho nhat");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('-', 60));
            Console.ResetColor();
        }

        private static Menu ChonMenu()
        {
            int chon;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Nhap chuc nang can thuc hien: ");
                Console.ResetColor();
                chon = int.Parse(Console.ReadLine());
                if ((int)Menu.Thoat <= chon && chon <= (int)Menu.XoaHinhTamGiacNhoNhat)
                    break;
            } while (true);
            return (Menu)chon;
        }

        private void XuLyMenu(Menu chon)
        {
            Console.Clear();
            switch (chon)
            {
                case Menu.Thoat:
                    break;

                case Menu.NhapCD:
                    dshh.NhapCD();
                    Console.WriteLine("Danh sach hinh hoc da duoc nhap!\n");
                    //Color.Red("Danh sach hinh hoc da duoc nhap!\n");
                    Console.WriteLine(new string('-', 80));
                    dshh.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                case Menu.XuatDS:
                    //Console.WriteLine(dshh.ToString());
                    Console.WriteLine("Danh sach hinh hoc:\n");
                    Console.WriteLine(new string('-', 80));
                    dshh.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                case Menu.DienTichMax:
                    dskq = dshh.HinhLonNhat();
                    if (dskq.SoPt() == 1)
                    {
                        Console.Write("Hinh co dien tich lon nhat:\n");
                        Console.WriteLine(new string('-', 80));
                        dskq.XuatDanhSach();

                    }
                    else
                    {
                        Console.WriteLine("Trong danh sach co {0} hinh lon nhat:\n ");
                        Console.WriteLine(new string('-', 80));
                        dskq = dshh.HinhLonNhat();
                        dskq.XuatDanhSach();
                        Console.WriteLine(new string('-', 80));
                    }
                    break;

                case Menu.SapTangTheoDienTich:
                    dshh.SapTang();
                    Console.WriteLine("Danh sach da duoc sap xep!\n");
                    Console.WriteLine(new string('-', 80));
                    dshh.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                case Menu.DSHinhVuongMin:
                    QuanLyHinhHoc kq = new QuanLyHinhHoc();
                    kq = dshh.DSHinhVuongNhoNhat();
                    if (kq.SoPt() == 0)
                        Console.WriteLine("Danh sach khong co hinh vuong!");
                    else
                    {
                        Console.WriteLine("Danh sach hinh vuong nho nhat:\n");
                        Console.WriteLine(new string('-', 80));
                        kq.XuatDanhSach();
                        Console.WriteLine(new string('-', 80));
                    }
                    break;

                case Menu.TongDienTichHinhTron:
                    Console.WriteLine("Cac hinh tron trong danh sach:\n");
                    Console.WriteLine(new string('-', 80));
                    for (int  i = 0; i < dshh.SoPt(); i++)
                    {
                        if (dshh[i] is HinhTron)
                        {
                            //Console.WriteLine(dshh[i].ToString());
                            dshh[i].XuatHinhHoc();
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine(new string('-', 80));
                    Console.Write("Tong dien tich: {0}", dshh.TongDienTichHinhTron());
                    break;

                case Menu.SapTangHinhTron:
                    dshh.SapTangHinhTron();
                    Console.WriteLine("Cac hinh tron trong danh sach da duoc sap xep!\n");
                    Console.WriteLine(new string('-', 80));
                    dshh.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                case Menu.DSDienTichNhoHonX:
                    Console.Write("Nhap x: ");
                    float x = float.Parse(Console.ReadLine());
                    Console.WriteLine(new string('-', 80));
                    dskq = dshh.DienTichNhoHonX(x);
                    Console.WriteLine("Cac hinh co dien tich nho hon {0}:\n", x);
                    dskq.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                case Menu.DemSoLuongTheoLoai:
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine("1. Hinh tron \n2. HinhVuong \n3. Hinh chu nhat \n4. HinhTamGiac");
                    Console.WriteLine(new string('-', 30));
                    Console.Write("Nhap loai hinh can dem: ");
                    int n = int.Parse((Console.ReadLine()));
                    Console.WriteLine("Trong danh sach co {0} {1}", dshh.SoLuongTheoLoaiHinh(n), (LoaiHinh)n);
                    break;

                case Menu.XoaTatCaTheoLoai:
                    Console.WriteLine(new string('-', 30));
                    Console.WriteLine("1. Hinh tron \n2. HinhVuong \n3. Hinh chu nhat \n4. HinhTamGiac");
                    Console.WriteLine(new string('-', 30));
                    Console.Write("Nhap loai hinh can xoa: ");
                    n = int.Parse((Console.ReadLine()));
                    dshh.XoaTatCaTheoLoaiHinh(n);
                    Console.WriteLine("Da xoa tat ca {0} co trong danh sach!", (LoaiHinh)n);
                    break;

                case Menu.ChenHinhTron:
                    Console.Write("Nhap ban kinh hinh tron can chen: ");
                    float bk = float.Parse(Console.ReadLine());
                    dshh.ChenHinhTron(bk);
                    break;

                case Menu.XoaHinhVuongNhoNhat:
                    dshh.XoaHinhVuongNhoNhat();
                    Console.WriteLine("Da xoa hinh vuong nho nhat trong danh sach!");
                    break;

                case Menu.SapXepDanhSach:
                    dshh.SapXep();
                    Console.WriteLine("Danh sach da duoc sap xep!");
                    Console.WriteLine(new string('-', 80));
                    dshh.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                case Menu.SapGiamHinhTamGiac:
                    dshh.SapGiamHinhTG();
                    Console.WriteLine("Cac hinh tam giac trong danh sach da duoc sap xep!\n");
                    Console.WriteLine(new string('-', 80));
                    dshh.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                case Menu.XoaHinhTamGiacNhoNhat:
                    dshh.XoaTamGiacNhoNhat();
                    Console.WriteLine("Da xoa hinh tam giac co dien tich nho nhat trong danh sach!\n");
                    Console.WriteLine(new string('-', 80));
                    dshh.XuatDanhSach();
                    Console.WriteLine(new string('-', 80));
                    break;

                default:
                    break;
            }
        }

        public void ChayChuongTrinh()
        {

            Menu chon;
            do
            {
                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == Menu.Thoat)
                    break;
                XuLyMenu(chon);
                Console.ReadKey();
            } while (true);
        }
        #endregion
    }
}
