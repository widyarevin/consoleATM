using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidyaRevin_Exercise3_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] noKartu = { "123459876", "987654321", "112233445", "998877665", "111555777" };

            SortedList<string, string> noPin = new SortedList<string, string>();
            noPin.Add(noKartu[0], "123134"); 
            noPin.Add(noKartu[1], "432425"); 
            noPin.Add(noKartu[2], "121212"); 
            noPin.Add(noKartu[3], "787876"); 
            noPin.Add(noKartu[4], "999999");

            SortedList<string,decimal> saldo = new SortedList<string, decimal>();
            saldo.Add(noKartu[0], 15000);
            saldo.Add(noKartu[1], 5000);
            saldo.Add(noKartu[2], 100000);
            saldo.Add(noKartu[3], 20000);
            saldo.Add(noKartu[4], 50000);


            SortedList<string, string> historyList = new SortedList<string, string>();
            historyList.Add(noKartu[0], $"Tanggal : {DateTime.Now} :: Debet : {saldo[noKartu[0]].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))} :: Kredit : :: Saldo : {saldo[noKartu[0]]}:: Status : Sukses");
            historyList.Add(noKartu[1], $"Tanggal : {DateTime.Now} :: Debet : {saldo[noKartu[1]].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))} :: Kredit : :: Saldo : {saldo[noKartu[0]]}:: Status : Sukses");
            historyList.Add(noKartu[2], $"Tanggal : {DateTime.Now} :: Debet : {saldo[noKartu[2]].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))} :: Kredit : :: Saldo : {saldo[noKartu[0]]}:: Status : Sukses");
            historyList.Add(noKartu[3], $"Tanggal : {DateTime.Now} :: Debet : {saldo[noKartu[3]].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))} :: Kredit : :: Saldo : {saldo[noKartu[0]]}:: Status : Sukses");
            historyList.Add(noKartu[4], $"Tanggal : {DateTime.Now} :: Debet : {saldo[noKartu[4]].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))} :: Kredit : :: Saldo : {saldo[noKartu[0]]}:: Status : Sukses");


            string inputKartu;
            string inputPin;

            Console.WriteLine("Selamat Datang di ATM Sederhana \n");
            bool kondisi = true;
            do
            {
                bool kondisi1 = true;
                do
                {
                    Console.WriteLine("Masukkan Nomor Kartu : ");
                    inputKartu = Console.ReadLine();
                    if (noKartu.Contains(inputKartu))
                    {
                        break;
                    }
                    Console.WriteLine("Nomor Kartu Tidak Tersedia");
                } while (kondisi1);

                bool kondisi2 = true;
                do
                {
                    Console.WriteLine("Masukkan Pin Anda : ");
                    inputPin = Console.ReadLine();
                    if (noPin[inputKartu] == inputPin)
                    {
                        break;
                    } 
                    Console.WriteLine("Nomor pin yang Anda input salah! Silahkan input kembali!");
                }while (kondisi2);

                bool kondisiMenu = true;
                    do
                        {
                            Console.WriteLine("Menu :");
                            Console.WriteLine("1. Informasi Saldo");
                            Console.WriteLine("2. Tarik Uang");
                            Console.WriteLine("3. Setor Uang");
                            Console.WriteLine("4. Transfer");
                            Console.WriteLine("5. Ganti Pin");
                            Console.WriteLine("6. History");
                            Console.WriteLine("7. Menu Utama");
                            Console.WriteLine("8. Exit");
                            Console.WriteLine("Pilih Menu (1-8)");
                            string inputMenu = Console.ReadLine();

                            decimal uang;
                            string statusTransaksi;

                        switch (inputMenu)
                            {
                                case "1":
                                    Console.WriteLine("Saldo Anda : {0}", saldo[inputKartu].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID")));
                                    statusTransaksi = "Sukses";
                                    break;

                                case "2":
                                    Console.WriteLine("Masukkan jumlah uang yang akan ditarik");
                                    uang = Convert.ToDecimal(Console.ReadLine());

                                    saldo[inputKartu] = saldo[inputKartu] - uang;

                                    if(uang > saldo[inputKartu])
                                    {
                                        kondisiMenu = true;
                                        statusTransaksi = "Gagal";
                                        Console.WriteLine("Maaf saldo Anda tidak cukup");
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Transaksi Berhasil");
                                        statusTransaksi = "Sukses";
                                        kondisiMenu = true;
                                    }
                            string historyTransaksi = $"Tanggal : {DateTime.Now} :: Debet : :: Kredit : {uang.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))} :: Saldo : {saldo[inputKartu].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))}:: Status : {statusTransaksi} ";
                            break;

                                case "3":
                                    Console.WriteLine("Masukkan jumlah uang yang akan disetor : ");
                                    decimal uangSetor = Convert.ToDecimal(Console.ReadLine());

                                    saldo[inputKartu] = saldo[inputKartu] + uangSetor;

                                    Console.WriteLine("Penyetoran uang berhasil");
                                    statusTransaksi = "Sukses";
                                    Console.WriteLine("Saldo Anda : {0}", saldo[inputKartu].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID")));


                                    historyTransaksi = $"Tanggal : {DateTime.Now} :: Debet : {uangSetor.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))} :: Kredit :  :: Saldo : {saldo[inputKartu].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))}:: Status : {statusTransaksi} ";
                                    kondisiMenu = true;

                                    break;

                                case "4":

                                    Console.WriteLine("Masukkan No Rekening tujuan");
                                    string noRekTujuan = Console.ReadLine();

                                    Console.WriteLine("Masukkan jumlah uang yang akan ditransfer : ");
                                    decimal uangTf = Convert.ToDecimal(Console.ReadLine());


                                    if (uangTf > saldo[inputKartu])
                                    {
                                        Console.WriteLine("Maaf, Saldo Anda tidak cukup. Saldo Anda {0}", saldo[inputKartu].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID")));
                                        statusTransaksi = "Gagal";
                                        kondisiMenu = true;
                                    }
                                    else
                                    {
                                        saldo[inputKartu] = saldo[inputKartu] - uangTf;
                                        saldo[noRekTujuan] = saldo[noRekTujuan] + uangTf;
                                        Console.WriteLine("Berhasil transfer ke-{0} sebesar {1} ", noRekTujuan, uangTf.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID")));
                                        statusTransaksi = "Sukses";
                                        kondisiMenu = true;
                                        
                            }
                            historyTransaksi = $"Tanggal : {DateTime.Now} :: Debet :  :: Kredit :{uangTf.ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))}  :: Saldo : {saldo[inputKartu].ToString("C2", CultureInfo.CreateSpecificCulture("id-ID"))}:: Status : {statusTransaksi} ";
                            break;

                                case "5":
                                    Console.WriteLine("Masukkan Pin Baru");
                                    string pinBaru = Console.ReadLine();

                                    if (pinBaru.Length != 6)
                                    {
                                        Console.WriteLine("Ubah Pin Gagal!");
                                        kondisiMenu = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ubah Pin Berhasil!");
                                        kondisiMenu = true;
                                    }
                                    break;
                                case "6":
                                    Console.WriteLine("History Transaction");
                                    Console.WriteLine(historyList[inputKartu]);
                                    break;

                                case "7":
                                    kondisi = true;
                                    kondisiMenu = false;
                                    break;

                                case "8":
                                    kondisi = false;
                                    kondisiMenu = false;
                                    break;
                            }
                        } while (kondisiMenu);

            } while (kondisi);
            

            






        }
    }
}
