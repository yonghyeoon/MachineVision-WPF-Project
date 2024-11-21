using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMachineVision.Support.Local.Events
{
    /// <summary>
    /// Prism Event Aggregator를 위해 Prism.Core Nuget 패키지 설치
    /// </summary>
    public class MessageSendEvent : PubSubEvent<string>
    {

    }
}
