using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ZedGraph;
using AForge;
using AForge.Imaging.Filters;
using Tesseract;


namespace Final_Project
{
    public partial class Form1 : Form
    {
        Bitmap InputImage;
        Bitmap Hinhxam1;
        Bitmap SobelImage;
        Bitmap SegmentationImage;
        Bitmap HinhBinary;
        Bitmap HinhCrop;
        public Form1()
        {
            InitializeComponent();
            //Khởi tạo logo
        }
        public static Bitmap Sobel(Bitmap Hinhgoc, byte threshold)
        {
            Bitmap tempImage = new Bitmap(Hinhgoc.Width, Hinhgoc.Height);

            double[,] filter1 = new double[3, 3];

            filter1[0, 0] = -1;
            filter1[0, 1] = -2;
            filter1[0, 2] = -1;
            filter1[1, 0] = 0;
            filter1[1, 1] = 0;
            filter1[1, 2] = 0;
            filter1[2, 1] = 1;
            filter1[2, 2] = 2;
            filter1[2, 0] = 1;

            double[,] filter2 = new double[3, 3];

            filter2[0, 0] = -1;
            filter2[0, 1] = 0;
            filter2[0, 2] = 1;
            filter2[1, 0] = -2;
            filter2[1, 1] = 0;
            filter2[1, 2] = 2;
            filter2[2, 1] = -1;
            filter2[2, 2] = 0;
            filter2[2, 0] = 1;

            Color[,] result = new Color[Hinhgoc.Width, Hinhgoc.Height];

            for (int x = 0; x < Hinhgoc.Width; ++x)
            {
                for (int y = 0; y < Hinhgoc.Height; ++y)
                {
                    double redx = 0.0, greenx = 0.0, bluex = 0.0;
                    double redy = 0.0, greeny = 0.0, bluey = 0.0;
                    for (int filterX = 0; filterX < 3; filterX++)
                    {
                        for (int filterY = 0; filterY < 3; filterY++)
                        {
                            int imageX = (x - 3 / 2 + filterX + Hinhgoc.Width) % Hinhgoc.Width;
                            int imageY = (y - 3 / 2 + filterY + Hinhgoc.Height) % Hinhgoc.Height;
                            Color imageColor = Hinhgoc.GetPixel(imageX, imageY);
                            redx += imageColor.R * filter1[filterX, filterY];
                            redy += imageColor.R * filter2[filterX, filterY];
                        }
                    }
                    double gr = Math.Abs(redx) + Math.Abs(redy);
                    if (gr <= threshold)
                    {
                        result[x, y] = Color.FromArgb(0, 0, 0);
                    }
                    else result[x, y] = Color.FromArgb(255, 255, 255);
                }
            }

            for (int i = 0; i < Hinhgoc.Width; ++i)
            {
                for (int j = 0; j < Hinhgoc.Height; ++j)
                {
                    tempImage.SetPixel(i, j, result[i, j]);
                }
            }

            return tempImage;
        }
        public Bitmap ChuyenHinhRGBSangHinhXamLuminance(Bitmap HinhGoc)
        {
            Bitmap HinhXamLuminance = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            for (int x = 0; x < HinhGoc.Width; x++)
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    // lấy điểm ảnh
                    Color pixel = HinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Tính giá trị mức xám cho điểm ảnh tại x,y
                    byte gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);

                    // Gán giá trị vừa tính vào hình mức xám
                    HinhXamLuminance.SetPixel(x, y, Color.FromArgb(gray, gray, gray));

                }
            return HinhXamLuminance;
        }
        public Image RotateImage(Image img)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return bmp;
        }
        public int[] Segmentation(Bitmap HinhGoc, double a)
        {
            int[] range = new int[4];
            double count = 0;
            double[] NumberpointinRow = new double[HinhGoc.Width];
            double[] NumberpointinColumn = new double[HinhGoc.Height];
            double averagex = 0;
            double averagey = 0;
            int fristpointx = 0;
            int lastpointx = 0;
            int fristpointy = 0;
            int lastpointy = 0;

            for (int x = 0; x < HinhGoc.Width; x++)
            {
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    // lấy điểm ảnh
                    Color color = HinhGoc.GetPixel(x, y);
                    if (color.R == 255)
                    {
                        count++;
                        NumberpointinColumn[y]++;
                    }
                }
                NumberpointinRow[x] = count;
                averagex = (count / HinhGoc.Width) + averagex;
                averagey = (count / HinhGoc.Height) + averagey;
                count = 0;
            }
            for (int x = 0; x < HinhGoc.Width; x++)
            {
                if (NumberpointinRow[x] > averagex * a)
                {
                    fristpointx = x;
                    break;
                }
            }
            for (int x = HinhGoc.Width -1; x > 0; x--)
            {
                if (NumberpointinRow[x] > averagex * a)
                {
                    lastpointx = x;
                    break;
                }
            }
            for (int x = 0; x < HinhGoc.Height; x++)
            {
                if (NumberpointinColumn[x] > averagey * a)
                {
                    fristpointy = x;
                    break;
                }
            }
            for (int x = HinhGoc.Height - 1; x > 0; x--)
            {
                if (NumberpointinColumn[x] > averagey * a)
                {
                    lastpointy = x;
                    break;
                }
            }
            range[0] = fristpointx;
            range[1] = lastpointx;
            range[2] = fristpointy;
            range[3] = lastpointy;
            return range;
        }
        // Tính BĐ Red
        public double[] TinhHistogramred(Bitmap Hinhred)
        {
            // Mỗi pixel mức xám có giá trị từ 0-255 , do vậy ta khái báo 1 mảng
            // có 256 phần tử dùng để chứa số đếm của các pixel có cùng mức red trong ảnh
            // Chúng ta nên dùng kiểu double vì tổng số đếm có thể rất lớn , phụ thuộc vào kích thước ảnh
            double[] histogramred = new double[256];
            double sum = 0;

            for (int x = 0; x < Hinhred.Width; x++)
                for (int y = 0; y < Hinhred.Height; y++)
                {
                    Color color = Hinhred.GetPixel(x, y);
                    byte red = color.R;

                    // Giá trị red tính ra cũng chính là phần tử thứ red trong mảng histogram đã khai báo
                    // Sẽ tăng số đếm của phần tử thứ red lên 1
                    histogramred[red]++;
                }

            for (int y = 0; y < 255; y++)
            {
                sum = histogramred[y] + sum;
            }
            double average = sum / 255;
            for (int y = 0; y < 255; y++)
            {
                histogramred[y] = average;
            }
            return histogramred;
        }
        PointPairList ChuyenDoiHistogramred(double[] histogramred)
        {
            // PointPairList là công cụ của ZedGraph dùng để vẽ biểu đồ
            PointPairList points = new PointPairList();

            for (int i = 0; i < histogramred.Length; i++)
            {
                // i tương ứng với trục nằm ngang , 0-255
                // histogram[i] tương ứng với trục thẳng đứng , là số pixel cùng mức xám

                points.Add(i, histogramred[i]);
            }
            return points;
        }
        public GraphPane BieuDoHistogramred(PointPairList histogramred)
        {
            // GraphPane là đối tượng biểu đồ trong ZedGraph
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"Biểu đồ Histogram RED"; // Tên biểu đồ
            gp.Rect = new Rectangle(0, 0, 400, 300); // Khung chứa biểu đồ

            // Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị mức RED của các điểm ảnh";
            gp.XAxis.Scale.Min = 0; // Giá trị nhỏ nhất là 0
            gp.XAxis.Scale.Max = 255; // Giá trị lớn nhất là 255
            gp.XAxis.Scale.MajorStep = 5; // Mỗi bước chính là 5
            gp.XAxis.Scale.MinorStep = 1; // Mỗi bước trong 1 bước chính là 1

            // Tương tự với trục đứng
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức RED";
            gp.YAxis.Scale.Min = 0; // Giá trị nhỏ nhất là 0
            gp.YAxis.Scale.Max = 15000; // Số này phải lớn hơn kích thước ảnh
            gp.YAxis.Scale.MajorStep = 5; // Mỗi bước chính là 5
            gp.YAxis.Scale.MinorStep = 1; // Mỗi bước trong 1 bước chính là 1

            // Dùng biểu đồ dạng bar để biểu diễn histogram
            gp.AddBar("Histogram", histogramred, Color.Red);

            return gp;
        }

        // Tính BĐ Green
        public double[] TinhHistogramgreen(Bitmap Hinhgreen)
        {
            // Mỗi pixel mức xám có giá trị từ 0-255 , do vậy ta khái báo 1 mảng
            // có 256 phần tử dùng để chứa số đếm của các pixel có cùng mức green trong ảnh
            // Chúng ta nên dùng kiểu double vì tổng số đếm có thể rất lớn , phụ thuộc vào kích thước ảnh
            double[] histogramgreen = new double[256];

            for (int x = 0; x < Hinhgreen.Width; x++)
                for (int y = 0; y < Hinhgreen.Height; y++)
                {
                    Color color = Hinhgreen.GetPixel(x, y);
                    byte green = color.G;

                    // Giá trị green tính ra cũng chính là phần tử thứ green trong mảng histogram đã khai báo
                    // Sẽ tăng số đếm của phần tử thứ green lên 1
                    histogramgreen[green]++;
                }
            return histogramgreen;
        }

        PointPairList ChuyenDoiHistogramgreen(double[] histogramgreen)
        {
            // PointPairList là công cụ của ZedGraph dùng để vẽ biểu đồ
            PointPairList points = new PointPairList();

            for (int i = 0; i < histogramgreen.Length; i++)
            {
                // i tương ứng với trục nằm ngang , 0-255
                // histogram[i] tương ứng với trục thẳng đứng , là số pixel cùng mức xám

                points.Add(i, histogramgreen[i]);
            }
            return points;
        }

        public GraphPane BieuDoHistogramgreen(PointPairList histogramgreen)
        {
            // GraphPane là đối tượng biểu đồ trong ZedGraph
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"Biểu đồ Histogram GREEN"; // Tên biểu đồ
            gp.Rect = new Rectangle(0, 0, 400, 300); // Khung chứa biểu đồ

            // Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị mức GREEN của các điểm ảnh";
            gp.XAxis.Scale.Min = 0; // Giá trị nhỏ nhất là 0
            gp.XAxis.Scale.Max = 255; // Giá trị lớn nhất là 255
            gp.XAxis.Scale.MajorStep = 5; // Mỗi bước chính là 5
            gp.XAxis.Scale.MinorStep = 1; // Mỗi bước trong 1 bước chính là 1

            // Tương tự với trục đứng
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức GREEN";
            gp.YAxis.Scale.Min = 0; // Giá trị nhỏ nhất là 0
            gp.YAxis.Scale.Max = 15000; // Số này phải lớn hơn kích thước ảnh
            gp.YAxis.Scale.MajorStep = 5; // Mỗi bước chính là 5
            gp.YAxis.Scale.MinorStep = 1; // Mỗi bước trong 1 bước chính là 1

            // Dùng biểu đồ dạng bar để biểu diễn histogram
            gp.AddBar("Histogram", histogramgreen, Color.Green);

            return gp;
        }

        // Tính BĐ Blue
        public double[] TinhHistogramblue(Bitmap Hinhblue)
        {
            // Mỗi pixel mức xám có giá trị từ 0-255 , do vậy ta khái báo 1 mảng
            // có 256 phần tử dùng để chứa số đếm của các pixel có cùng mức blue trong ảnh
            // Chúng ta nên dùng kiểu double vì tổng số đếm có thể rất lớn , phụ thuộc vào kích thước ảnh
            double[] histogramblue = new double[256];

            for (int x = 0; x < Hinhblue.Width; x++)
                for (int y = 0; y < Hinhblue.Height; y++)
                {
                    Color color = Hinhblue.GetPixel(x, y);
                    byte blue = color.B;

                    // Giá trị blue tính ra cũng chính là phần tử thứ blue trong mảng histogram đã khai báo
                    // Sẽ tăng số đếm của phần tử thứ blue lên 1
                    histogramblue[blue]++;
                }
            return histogramblue;
        }
        PointPairList ChuyenDoiHistogramblue(double[] histogramblue)
        {
            // PointPairList là công cụ của ZedGraph dùng để vẽ biểu đồ
            PointPairList points = new PointPairList();

            for (int i = 0; i < histogramblue.Length; i++)
            {
                // i tương ứng với trục nằm ngang , 0-255
                // histogram[i] tương ứng với trục thẳng đứng , là số pixel cùng mức xám

                points.Add(i, histogramblue[i]);
            }
            return points;
        }
        public GraphPane BieuDoHistogramblue(PointPairList histogramblue)
        {
            // GraphPane là đối tượng biểu đồ trong ZedGraph
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"Biểu đồ Histogram BLUE"; // Tên biểu đồ
            gp.Rect = new Rectangle(0, 0, 400, 300); // Khung chứa biểu đồ

            // Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị mức BLUE của các điểm ảnh";
            gp.XAxis.Scale.Min = 0; // Giá trị nhỏ nhất là 0
            gp.XAxis.Scale.Max = 255; // Giá trị lớn nhất là 255
            gp.XAxis.Scale.MajorStep = 5; // Mỗi bước chính là 5
            gp.XAxis.Scale.MinorStep = 1; // Mỗi bước trong 1 bước chính là 1

            // Tương tự với trục đứng
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức BLUE";
            gp.YAxis.Scale.Min = 0; // Giá trị nhỏ nhất là 0
            gp.YAxis.Scale.Max = 15000; // Số này phải lớn hơn kích thước ảnh
            gp.YAxis.Scale.MajorStep = 5; // Mỗi bước chính là 5
            gp.YAxis.Scale.MinorStep = 1; // Mỗi bước trong 1 bước chính là 1

            // Dùng biểu đồ dạng bar để biểu diễn histogram
            gp.AddBar("Histogram", histogramblue, Color.Blue);

            return gp;
        }

        private void InputPicture_Click(object sender, EventArgs e)
        {

        }
        private void SelectBT_Click(object sender, EventArgs e)
        {
            //Mở hình ảnh cần xác định
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg,*.png,*.gif)|*.jpg;*.png;*.gif";//lọc chỉ mở file 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Hiển thị hình ảnh cần xác định
                InputImage = new Bitmap(ofd.FileName);//Địa chỉ được gán vô hình input
                InputPicture.Image = InputImage;

                //Chuyển sang mức xám để dùng sobel
                Hinhxam1 = ChuyenHinhRGBSangHinhXamLuminance(InputImage);
                //crop image
                //Ban đầu tạo ra mảng 4 phần tử
                int[] arage = new int[4];
                //Lấy sobel hình đầu vào
                SobelImage = Sobel(Hinhxam1, 160);
                //Hàm segmen trả về 4 vị trí để mình cắt hình
                arage = Segmentation(SobelImage, 1.2);//Xác định viền 
                //
                double chieurong = arage[1] - arage[0];
                double chieudai = arage[3] - arage[2];
                //Cắt khung thẻ sinh viên
                Crop filter = new Crop(new Rectangle((int)arage[0], (int)arage[2], (int)chieurong, (int)chieudai));//2 tham số đầu là vị trí góc trái hình vuông
                Bitmap newImage = filter.Apply(InputImage);
                HinhCrop = newImage;
            }
            ofd.Dispose();
        }
        private void RotateBT_Click(object sender, EventArgs e)
        {
            //Xoay hình
            //Xoay hình gốc
            Bitmap Rotate = (Bitmap)RotateImage(InputImage);
            InputImage = (Bitmap)Rotate;
            //Hiển thị lại
            InputPicture.Image = Rotate;
            //Xoay hinh crop
            Rotate = (Bitmap)RotateImage(HinhCrop);
            HinhCrop = (Bitmap)Rotate;
        }
        private void SobelBT_Click(object sender, EventArgs e)
        {
            //Hiển thị hình cắt khung của thẻ
            OutputPicture.Image = HinhCrop;

            txtResult.Text = "";
        }
    }
}
