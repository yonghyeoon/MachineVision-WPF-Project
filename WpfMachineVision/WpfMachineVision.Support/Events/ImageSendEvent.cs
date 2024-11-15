using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfMachineVision.Support.Events
{
    /// <summary>
    /// Prism Event Aggregator를 위해 Prism.Core Nuget 패키지 설치
    /// </summary>
    public class ImageSendEvent : PubSubEvent<WriteableBitmap>
    {
        
    }
}
