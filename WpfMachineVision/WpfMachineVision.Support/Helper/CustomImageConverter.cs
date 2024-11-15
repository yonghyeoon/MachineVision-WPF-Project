using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using Tesseract;

namespace WpfMachineVision.Support.Helper
{
    public class CustomImageConverter
    {
        public static Mat WriteableBitmapToMat(WriteableBitmap writeableBitmap)
        {
            return writeableBitmap.ToMat();
        }

        public static WriteableBitmap MatToWriteableBitmap(Mat mat)
        {
            return mat.ToWriteableBitmap();
        }

        public static Bitmap MatToBitmap(Mat mat)
        {
            return BitmapConverter.ToBitmap(mat);
        }

        public static Pix MatToPix(Mat mat)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Mat 객체를 바이트 배열로 변환 (BMP 형식 사용)
                mat.ToMemoryStream(".bmp").CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Tesseract의 Pix 객체로 변환
                return Pix.LoadFromMemory(memoryStream.ToArray());
            }
        }
    }
}
