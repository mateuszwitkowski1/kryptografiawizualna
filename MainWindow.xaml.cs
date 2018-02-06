using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Drawing.Imaging;

namespace KryptografiaWiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string sciezka;
        private BitmapImage zdjecie;
        private Bitmap bitmap;
        private BitmapImage zdjecieudz1;
        private Bitmap udzial1;
        private BitmapImage zdjecieudz2;
        private Bitmap udzial2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private Bitmap dobmp(BitmapImage zdjecie2)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(zdjecie2));
                enc.Save(outStream);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
                return new Bitmap(bitmap);
            }
        }

        private void zaladuj_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    zdjecie = new BitmapImage();
                    sciezka = dlg.FileName;
                    zdjecie.BeginInit();
                    zdjecie.UriSource = new Uri(sciezka);
                    zdjecie.EndInit();
                    image.Source = zdjecie;
                    bitmap = dobmp(zdjecie);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void podziel_Click(object sender, RoutedEventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Najpierw wybierz obraz!");
            }
            else
            {
                Bitmap nowy1 = new Bitmap(bitmap.Width * 2, bitmap.Height);
                Bitmap nowy2 = new Bitmap(bitmap.Width * 2, bitmap.Height);
                Random random = new Random();
                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        int wynik = random.Next(0, 2);
                        System.Drawing.Color pixelwej = bitmap.GetPixel(j, i);
                        if (pixelwej.R == 0 && pixelwej.G == 0 && pixelwej.B == 0)
                        {
                            if (wynik == 0)
                            {
                                nowy1.SetPixel(j * 2, i, System.Drawing.Color.White);
                                nowy1.SetPixel((j * 2) + 1, i, System.Drawing.Color.Black);
                                nowy2.SetPixel(j * 2, i, System.Drawing.Color.Black);
                                nowy2.SetPixel((j * 2) + 1, i, System.Drawing.Color.White);
                            }
                            else
                            {
                                nowy1.SetPixel(j * 2, i, System.Drawing.Color.Black);
                                nowy1.SetPixel((j * 2) + 1, i, System.Drawing.Color.White);
                                nowy2.SetPixel(j * 2, i, System.Drawing.Color.White);
                                nowy2.SetPixel((j * 2) + 1, i, System.Drawing.Color.Black);
                            }
                        }
                        else
                        {
                            if (wynik == 0)
                            {
                                nowy1.SetPixel(j * 2, i, System.Drawing.Color.White);
                                nowy1.SetPixel((j * 2) + 1, i, System.Drawing.Color.Black);
                                nowy2.SetPixel(j * 2, i, System.Drawing.Color.White);
                                nowy2.SetPixel((j * 2) + 1, i, System.Drawing.Color.Black);
                            }
                            else
                            {
                                nowy1.SetPixel(j * 2, i, System.Drawing.Color.Black);
                                nowy1.SetPixel((j * 2) + 1, i, System.Drawing.Color.White);
                                nowy2.SetPixel(j * 2, i, System.Drawing.Color.Black);
                                nowy2.SetPixel((j * 2) + 1, i, System.Drawing.Color.White);
                            }
                        }
                    }
                }
                System.Drawing.Image nowy1a = (System.Drawing.Image)nowy1;
                nowy1a.Save("1.png", ImageFormat.Png);
                System.Drawing.Image nowy2a = (System.Drawing.Image)nowy2;
                nowy2a.Save("2.png", ImageFormat.Png);
                MessageBox.Show("Ukryto w plikach 1.png i 2.png");
            }
        }

        private void zaladuj1_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    zdjecieudz1 = new BitmapImage();
                    sciezka = dlg.FileName;
                    zdjecieudz1.BeginInit();
                    zdjecieudz1.UriSource = new Uri(sciezka);
                    zdjecieudz1.EndInit();
                    image1.Source = zdjecieudz1;
                    udzial1 = dobmp(zdjecieudz1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void zaladuj2_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    zdjecieudz2 = new BitmapImage();
                    sciezka = dlg.FileName;
                    zdjecieudz2.BeginInit();
                    zdjecieudz2.UriSource = new Uri(sciezka);
                    zdjecieudz2.EndInit();
                    image2.Source = zdjecieudz2;
                    udzial2 = dobmp(zdjecieudz2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void odszyfruj_Click(object sender, RoutedEventArgs e)
        {
            if (image1 == null || image2 == null)
            {
                MessageBox.Show("Musisz wybrać dwa udziały!");
            }
            else
            {
                Bitmap wynik1 = new Bitmap(udzial1.Width, udzial1.Height);
                Bitmap wynik2 = new Bitmap(udzial1.Width / 2, udzial1.Height);
                for (int i = 0; i < udzial1.Height; i++)
                {
                    for (int j = 0; j < udzial1.Width; j++)
                    {
                        System.Drawing.Color pixel1 = udzial1.GetPixel(j, i);
                        System.Drawing.Color pixel2 = udzial2.GetPixel(j, i);
                        if (pixel1.R == 0 || pixel2.R == 0)
                        {
                            wynik1.SetPixel(j, i, System.Drawing.Color.Black);
                        }
                        else
                        {
                            wynik1.SetPixel(j, i, System.Drawing.Color.White);
                        }
                    }
                }
                for (int i = 0; i < udzial1.Height; i++)
                {
                    for (int j = 0; j < udzial1.Width/2; j++)
                    {
                        System.Drawing.Color pixel1 = udzial1.GetPixel(j*2, i);
                        System.Drawing.Color pixel2 = udzial2.GetPixel(j*2, i);
                        System.Drawing.Color pixel1a = udzial1.GetPixel((j * 2)+1, i);
                        System.Drawing.Color pixel2a = udzial2.GetPixel((j * 2)+1, i);
                        if ((pixel1.R == 0 && pixel2.R == 0) || pixel1a.R == 0 && pixel2a.R==0)
                        {
                            wynik2.SetPixel(j, i, System.Drawing.Color.White);
                        }
                        else
                        {
                            wynik2.SetPixel(j, i, System.Drawing.Color.Black);
                        }
                    }
                }
                System.Drawing.Image wynik1a = (System.Drawing.Image)wynik1;
                wynik1a.Save("wynik1.png", ImageFormat.Png);
                System.Drawing.Image wynik2a = (System.Drawing.Image)wynik2;
                wynik2a.Save("wynik2.png", ImageFormat.Png);
                MessageBox.Show("Wynikowy obraz został zapisany do pliku wynik1.png\nPrzekształcony wynik został zapisany do pliku wynik2.png");
            }
        }
    }
}
