using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlsLib
{
    public static class WpfHelper
    {
        public static string GetStringFromInputBox(object startValue, string prompt)
        {
            var aaa = new InputBoxPopup() {PromptText = prompt, Text = startValue.ToString()};

            aaa.ShowDialog();

            var text = aaa.Text;
            
            return text;
        }

        public static string GetStringFromInputBox(object startValue)
        {
            string defaultPrompt = "Input value:";
            return GetStringFromInputBox(startValue, defaultPrompt);
        }

        public static string GetStringFromInputBox()
        {
            string defaultPrompt = "Input value:";
            string defaultStartValue = "";
            return GetStringFromInputBox(defaultStartValue, defaultPrompt);
        }

    }
}
