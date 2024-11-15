using OpenCvSharp;

namespace WpfMachineVision.Support.Services
{
    public class HaarCascadeFaceDetector
    {
        private CascadeClassifier _faceCascade;

        public HaarCascadeFaceDetector(string cascadeFilePath)
        {
            _faceCascade = new CascadeClassifier(cascadeFilePath);
        }

        public Mat DetectFaces(Mat image)
        {
            Rect[] faces = _faceCascade.DetectMultiScale(image, scaleFactor: 1.1, minNeighbors: 3, minSize: new Size(30, 30));
            foreach (Rect face in faces)
            {
                Cv2.Rectangle(img:image, rect:face, color: Scalar.LightGreen, thickness: 2, lineType:LineTypes.AntiAlias);
            }

            return image;
        }
    }
}
