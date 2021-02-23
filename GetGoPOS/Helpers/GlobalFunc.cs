using GetGoPOS.Model.Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetGoPOS.Helpers
{
    class GlobalFunc
    {
        public static byte[] getPrinterODByte()
        {
            byte[] code = new byte[] { };
            try
            {
                if ((code = globalvariables.PrinterODByte.Split(',').Select(n => Convert.ToByte(n)).ToArray()).Length != 5)
                    code = new byte[] { };
            }
            catch
            {
            }
            return code;
        }
        public static int CenterControlInParent(Control control, int buttonHeight)
        {
            string message = control.Text;
            BaseForm baseForm = control.Parent as BaseForm;
            Screen myScreen = Screen.FromControl(baseForm);
            Rectangle area = myScreen.WorkingArea;
            baseForm.FormBorderStyle = FormBorderStyle.None;
            int parentWitdh = baseForm.Width - 20;
            int parentHeight = (int)(baseForm.Height * 0.83);

            // Split text to check if fit in form.
            // If not it will be enter in a new line.
            List<string> newTextList = new List<string>();
            List<string> textList = message.Split(' ').ToList();
            string newText = "";
            textList.ForEach(x =>
            {
                string stringAdd = x;
                control.Text = newText + stringAdd;
                if (newText != "" && control.Width > parentWitdh)
                {
                    newTextList.Add(newText.Trim());
                    newText = "";
                }

                if (newText == "" && control.Width > parentWitdh)
                {
                    control.Text = stringAdd;
                    while (newText == "" && control.Width > parentWitdh)
                    {
                        int limit = 1;
                        control.Text = "";
                        while (control.Width < control.Parent.Width)
                        {
                            control.Text = stringAdd.Substring(0, limit);
                            limit++;
                        }
                        limit--;
                        newText = stringAdd.Substring(0, limit);
                        newTextList.Add(newText);
                        newText = "";
                        stringAdd = stringAdd.Substring(limit, stringAdd.Length - limit);
                        control.Text = stringAdd;
                    }
                }

                control.Text = newText + stringAdd;
                if (control.Width <= parentWitdh)
                    newText += stringAdd + " ";
            });
            if (newText != "")
                newTextList.Add(newText.Trim());
            control.Text = string.Join("\n", newTextList.ToArray());

            //Resize Form to fix 
            bool isResize = control.Height > parentHeight;
            if (isResize)
            {
                parentHeight = (int)(control.Height * 1.2);
                // Safety condition, so it won't exceed the current screen height.
                if (parentHeight > area.Height)
                    parentHeight = area.Height;
                baseForm.Height = parentHeight + buttonHeight + 6;
            }

            control.Left = (control.Parent.Width - control.Width) / 2;
            control.Top = (parentHeight - control.Height) / 2;
            baseForm.FormBorderStyle = FormBorderStyle.FixedDialog;

            //Re-center form in screen.
            if (isResize)
            {
                baseForm.Top = (area.Height - baseForm.Height) / 2;
                baseForm.Left = (area.Width - baseForm.Width) / 2;
            }

            if (isResize)
                return parentHeight;
            else
                return 0;
        }
    }
}
