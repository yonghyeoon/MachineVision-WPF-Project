using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMachineVision.Support.Local.Common
{
    public class CheckboxEventPayload
    {
        public string Message { get; set; }
        public bool IsChecked { get; set; }

        public CheckboxEventPayload(string message, bool isChecked)
        {
            Message = message;
            IsChecked = isChecked;
        }
    }
}
