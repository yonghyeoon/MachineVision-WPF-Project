using System.IO;
using Tesseract;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using WpfMachineVision.Support.Helper;
using System.Windows;

namespace WpfMachineVision.Support.Services
{
    public class TesseractOCR
    {
        private string _tessDataPath = Directory.GetCurrentDirectory() + @"\tessdata";
        private readonly TesseractEngine _ocr;

        public TesseractOCR()
        {
            //MessageBox.Show(Directory.Exists(_tessDataPath).ToString());
            //MessageBox.Show("TesseractOCR 생성자");
            _ocr = new TesseractEngine(_tessDataPath, "kor+eng", EngineMode.Default);
        }

        public string OcrGetText(Mat img)
        {
            Pix pix = CustomImageConverter.MatToPix(img);

            // using 구문을 사용하여 Page 객체를 명시적으로 Dispose
            using (var page = _ocr.Process(pix))
            {
                string texts = page.GetText();
                return texts;
            }
        }
    }
}
