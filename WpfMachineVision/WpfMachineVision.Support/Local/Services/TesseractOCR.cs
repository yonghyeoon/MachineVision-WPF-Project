using System.IO;
using Tesseract;
using OpenCvSharp;
using WpfMachineVision.Support.Local.Helper;
using System.Windows;

namespace WpfMachineVision.Support.Local.Services
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
            try
            {
                // 그레이스케일 변환
                Mat gray = new Mat();
                Cv2.CvtColor(img, gray, ColorConversionCodes.BGR2GRAY);

                // 이진화
                Mat binary = new Mat();
                Cv2.Threshold(gray, binary, 0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);

                // Mat에서 Pix로 변환
                Pix pix = CustomImageConverter.MatToPix(binary);

                using (var page = _ocr.Process(pix))
                {
                    string texts = page.GetText();
                    return texts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCR 처리 중 오류 발생: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
