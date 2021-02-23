using Cobainsoft.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using GetGoPOS.Enums;
using System.Drawing.Drawing2D;
using System.Globalization;
using GetGoPOS.Model.Global;

namespace GetGoPOS.Helpers
{
    public class ReceiptPrinterHelper
    {
        /// <summary>
        /// Get or sets the maximum possible number of characters that can be printed per line.
        /// </summary>
        public int StringFullWidth { get; set; }
        /// <summary>
        /// Gets or sets the number of characters that will actually be printed per line.
        /// </summary>
        public int StringWidth { get; set; }
        /// <summary>
        /// Gets or sets the number of whitespaces to be inserted in front of every line.
        /// </summary>
        public int StringBufferWidth { get; set; }
        public string PrinterName { get; set; }
        public int LineSpacing
        {
            get { return _lineSpacing; }
            set
            {
                if (_lineSpacing == value)
                    return;
                _lineSpacing = value;
                setSpacingForText();
            }
        }

        public ReceiptPrinterHelper(int stringWidth)
            : this(stringWidth, new PrintDocument().PrinterSettings.PrinterName) { }
        public ReceiptPrinterHelper(int stringWidth, string printerName)
            : this(stringWidth, printerName, 0) { }
        public ReceiptPrinterHelper(int stringWidth, string printerName, int lineSpacing)
        {
            this.StringWidth = stringWidth;
            this.StringFullWidth = this.StringWidth;
            this.PrinterName = printerName;
            this.LineSpacing = lineSpacing;
            this.buffer = new byte[] { };
            this.setSpacingForText();
            this.NormalFont();
            this.CPI12();
        }

        public void ActivateCutter()
        {
            RawPrinterHelper.SendStringToPrinter(this.PrinterName, "\n\r");
            byte[] bytes = new byte[] { 0x1D, 0x56, 0x42, 0x00 };
            IntPtr unmanagedPointer = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, unmanagedPointer, bytes.Length);
            RawPrinterHelper.SendBytesToPrinter(this.PrinterName, unmanagedPointer, bytes.Length);
            Marshal.FreeHGlobal(unmanagedPointer);
        }
        public void CPI12()
        {
            // Set the character Font to 'B'.
            if (!globalvariables.PrintReceiptDisableBypass)
            {
                addBytesToBuffer(new byte[] { 0x1B, 0x4D });
                addStringToBuffer("1");
            }
        }
        public string GetRepeatingCharacter(char character, int numberOfRepeats)
        {
            string result = "";
            for (int i = 0; i < numberOfRepeats; i++)
                result += character;
            return result;
        }
        public void LargeFont()
        {
            //For Normal Characters
            byte[] bytes = new byte[] { 0x1B, 0x21, 0x10 };
            addBytesToBuffer(bytes);
            //For Chinese Characters
            byte[] bytes2 = new byte[] { 0x1C, 0x21, 0x08 };
            addBytesToBuffer(bytes2);
            if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_76mm_journal)
            {
                byte[] bytes3 = new byte[] { 0x1C, 0x53, 0x02, 0x02 };
                addBytesToBuffer(bytes3);
            }
            else
            {
                byte[] bytes3 = new byte[] { 0x1C, 0x53, 0x00, 0x00 };
                addBytesToBuffer(bytes3);
            }
        }
        public void NormalFont()
        {
            //For Normal Characters
            byte[] bytes = new byte[] { 0x1B, 0x21, 0x00 };
            addBytesToBuffer(bytes);
            //For Chinese Characters
            byte[] bytes2 = new byte[] { 0x1C, 0x21, 0x00 };
            addBytesToBuffer(bytes2);
        }
        public void OpenCashDrawer()
        {
            byte[] DrawerOpen = GlobalFunc.getPrinterODByte();
            IntPtr unmanagedPointer = Marshal.AllocHGlobal(DrawerOpen.Length);
            Marshal.Copy(DrawerOpen, 0, unmanagedPointer, DrawerOpen.Length);
            RawPrinterHelper.SendBytesToPrinter(PrinterName, unmanagedPointer, DrawerOpen.Length);
            Marshal.FreeHGlobal(unmanagedPointer);
        }

        public void WriteBarcode(string barcode)
        {
            WriteBarcode(barcode, BarcodeType.CODE128B);
        }
        public void WriteBarcode(string barcode, BarcodeType barcodeType)
        {
            BarcodeControl BCctrl = new BarcodeControl();
            BCctrl.TextPosition = BarcodeTextPosition.NotShown;
            BCctrl.HorizontalAlignment = BarcodeHorizontalAlignment.Center;
            BCctrl.Location = new Point(0, 0);
            BCctrl.BarcodeType = barcodeType;
            BCctrl.CopyRight = "";
            BCctrl.Size = new Size(200, 40);
            BCctrl.Data = barcode;
            Rectangle rect = new Rectangle(0, 0, BCctrl.Width, BCctrl.Height);
            Bitmap bitmap = new Bitmap(BCctrl.Width, BCctrl.Height);

            BCctrl.DrawToBitmap(bitmap, rect);
            WriteImage(bitmap);
        }
        public void WriteImage(Image image)
        {
            if (image.PixelFormat != PixelFormat.Format32bppArgb)
                throw new Exception("Pixel Format not yet supported.");

            Image tempImage = image;
            float scale = tempImage.Height / tempImage.Width;
            if (tempImage.Width > 255)
                tempImage = new Bitmap(image, new Size(255, (int)(255 / scale)));
            if (tempImage.Height > 255)
                tempImage = new Bitmap(image, new Size((int)(scale / 255), 255));
            image = tempImage;

            Bitmap bmp = new Bitmap(image);
            Rectangle rect = new Rectangle(0, 0, image.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            List<int[]> tempList = new List<int[]>();
            List<int> tempList2 = new List<int>();
            int nonzero = 0;
            for (int i = 0; i < rgbValues.Length;)
            {
                int byte1 = (((int)rgbValues[i]) << 24);
                int byte2 = (((int)rgbValues[i + 1]) << 16);
                int byte3 = (((int)rgbValues[i + 1]) << 8);
                int byte4 = (((int)rgbValues[i + 1]));
                int finalInt = byte1 | byte2 | byte3 | byte4;
                if (finalInt != -1)
                    nonzero++;
                tempList2.Add(finalInt);
                if (((i += 4) % bmpData.Stride) == 0)
                {
                    tempList.Add(tempList2.ToArray());
                    tempList2 = new List<int>();
                }
            }
            int[][] thefinalarray = tempList.ToArray();

            int[][] anotherarray = (int[][])thefinalarray.Clone();
            for (int i = 0; i < anotherarray.Length; i++)
            {
                for (int j = 0; j < anotherarray[i].Length; j++)
                {
                    if (anotherarray[i][j] != -1)
                        anotherarray[i][j] = 1;
                    else
                        anotherarray[i][j] = 0;
                }
            }
            // Unlock the bits.
            bmp.UnlockBits(bmpData);
            betterPrintImage(anotherarray);
        }
        public void WriteLines(string text)
        {
            WriteLines(text, StringAlignment.Center);
        }
        public void WriteLines(string text, StringAlignment alignment)
        {
            text = text.Replace('\t', ' ');
            // Replaces all non ascii characters with 2 space (ex. chinese characters)
            if (!globalvariables.PrintChineseCharacters)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    int tempInt = (int)text[i];
                    if (tempInt > 127)
                        text = text.Replace(text[i] + "", "  ");
                }
            }
            text = getFormattedString(text, alignment, this.StringWidth);
            List<string> tempStringList = text.Split('\n', '\r').ToList();
            tempStringList.RemoveAll(x => x == "");
            if (tempStringList.Count > 0)
            {
                tempStringList.ForEach(x => this.addStringToBuffer(GetRepeatingCharacter(' ', this.StringBufferWidth) + x
                    + ((textLength(x) + this.StringBufferWidth < this.StringFullWidth) ? "\n\r" : "")));
            }
        }
        public void WriteRow(string[] strings, StringAlignment[] alignments, int[] columnWidths)
        {
            if (strings.Length != alignments.Length || strings.Length != columnWidths.Length)
                throw new Exception("All arrays must have the same lengths.");

            columnWidths[columnWidths.Length - 1] += this.StringWidth - columnWidths.Sum();
            List<List<string>> stringListToPrint = new List<List<string>>();
            for (int i = 0; i < strings.Length; i++)
            {
                string temptmeptmep = getFormattedString(strings[i], alignments[i], columnWidths[i]);
                List<string> tempStringList = temptmeptmep.Replace("\n\r", "\0").Split('\0').ToList();
                tempStringList.RemoveAll(x => x == "");
                stringListToPrint.Add(tempStringList);
            }
            int numberOfLines = stringListToPrint.Max(x => x.Count);
            for (int i = 0; i < numberOfLines; i++)
            {
                string line = "";
                for (int j = 0; j < stringListToPrint.Count; j++)
                {

                    if (stringListToPrint[j].Count > i)
                        line += stringListToPrint[j][i];
                    else
                        line += GetRepeatingCharacter(' ', columnWidths[j]);
                }
                WriteLines(line);
            }
        }
        public void WriteRepeatingCharacterLine(char character)
        {
            WriteRepeatingCharacterLine(character, this.StringWidth, StringAlignment.Near);
        }
        public void WriteRepeatingCharacterLine(char character, int numberOfRepeats, StringAlignment alignment)
        {
            WriteLines(GetRepeatingCharacter(character, numberOfRepeats), alignment);
        }
        public void WriteTable(string[][] strings, StringAlignment[] alignments, int[] columnWidths)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                WriteRow(strings[i], alignments, columnWidths);
            }
        }
        public void WriteTable(DataTable data, StringAlignment[] alignments, int[] columnWidths)
        {
            foreach (DataRow row in data.Rows)
            {
                List<string> stringList = new List<string>();
                foreach (object obj in row.ItemArray)
                    stringList.Add(obj.ToString());
                WriteRow(stringList.ToArray(), alignments, columnWidths);
            }
        }
        public void PreviewOR(PrintPageEventArgs e, Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            printPage(ref g, ref e);
        }
        public void Print()
        {

            if (EJournalReceipt == PrintingType.EJournalTextFile)
            {
                SaveToFile(Path.Combine(DirectoryLocation, ReceiptFileName + ".txt"), true);
                return;
            }
            if (this.PrinterName == "Microsoft XPS Document Writer" || EJournalReceipt == PrintingType.EJournalXPSFile)
            {
                doc.PrintController = new StandardPrintController();
                if (EJournalReceipt == PrintingType.EJournalXPSFile)
                {
                    this.PrinterName = "Microsoft XPS Document Writer";
                    doc.PrinterSettings = new PrinterSettings()
                    {
                        PrinterName = "Microsoft XPS Document Writer",
                        PrintToFile = true,
                        PrintFileName = Path.Combine(DirectoryLocation, ReceiptFileName + ".xps")
                    };
                }
                else
                    doc.PrinterSettings.PrinterName = this.PrinterName;

                this.byteIndex = 0;

                doc.PrintPage += (sender, e) =>
                {
                    Graphics g = e.Graphics;
                    printPage(ref g, ref e);
                };
                try
                {
                    doc.Print();
                }
                catch (InvalidPrinterException e)
                {
                }
                catch (Exception ex)
                {
                    FncFilter.Alert(ex.Message);
                }
                return;
            }

            IntPtr unmanagedPointer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, unmanagedPointer, buffer.Length);
            RawPrinterHelper.SendBytesToPrinter(this.PrinterName, unmanagedPointer, buffer.Length);
            Marshal.FreeHGlobal(unmanagedPointer);
            buffer = new byte[] { };
        }
        /// <summary>
        /// Current byte of index of print document.
        /// </summary>
        private int byteIndex { get; set; } = 0;
        private void printPage(ref Graphics g, ref PrintPageEventArgs e)
        {
            int y = 0;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Font normalFont = new Font(FontFamily.GenericMonospace, 9F);
            float yPoint = 0;
            float yScale = 1;
            float yScaleLarge = 1;
            float yScaleNormal = 1;
            float xScale = 1;
            int maxLine = 0;
            int scaledHeaderTextCount = 0;
            if (globalvariables.PrintChineseCharacters)
            {
                yScaleLarge = 2;
                yScaleNormal = 1.2f;
                float fontSize = 1;
                if (this.PrinterName == "Microsoft XPS Document Writer")
                    fontSize = 11F;
                else if (globalvariables.PrintReceiptFormat == PrintFormat.Custom_76mm_journal)
                {
                    fontSize = 8.65f;
                    maxLine = 71;
                }
                else if (globalvariables.PrintReceiptFormat == PrintFormat.None)
                {
                    fontSize = 6.65f;
                    xScale = 0.9f;
                }
                normalFont = new Font("NSimSun", fontSize);
            }
            int yMultiplier = (int)g.MeasureString("Og", normalFont).Height;
            string text = "";
            List<byte> chinseBytes = new List<byte>();
            List<byte> byteListTemp = new List<byte>();
            for (int i = byteIndex; i < this.buffer.Length; i++)
            {
                byte cmd = this.buffer[i];
                // Command bytes
                if (cmd == 0x1C || cmd == 0x1B || byteListTemp.Count > 0)
                {
                    byteListTemp.Add(cmd);
                    byte[] array = byteListTemp.ToArray();

                    // CPI12()
                    if (array.Count() == 3 && array[0] == 0x1B && array[1] == 0x4D)
                        byteListTemp.Clear();
                    // NormalFont(), LargeFont()
                    else if (array.Count() == 3 && array[0] == 0x1B && array[1] == 0x21)
                        byteListTemp.Clear();
                    else if (array.Count() == 3 && array[0] == 0x1C && array[1] == 0x21)
                        byteListTemp.Clear();
                    // Set Font Spacing
                    else if (array.Count() == 3 && array[0] == 0x1B && array[1] == 0x33)
                        byteListTemp.Clear();
                    // Chinese Font Spacing
                    else if (array.Count() == 4 && array[0] == 0x1C && array[1] == 0x53)
                        byteListTemp.Clear();
                }
                // Text
                else
                {
                    if (cmd > 127)
                        chinseBytes.Add(cmd);

                    if (chinseBytes.Count == 2)
                    {
                        text += System.Text.Encoding.GetEncoding("GB18030").GetString(chinseBytes.ToArray());
                        chinseBytes.Clear();
                    }
                    else if (chinseBytes.Count != 1)
                        text += (char)cmd;

                    if (text.Contains("\n\r") || textLength(text) + chinseBytes.Count == this.StringFullWidth)
                    {
                        float yPointScaled = yPoint;

                        // When printer is not xps and enable printing of chinese characters, create settings for transform(scale).
                        if (this.PrinterName != "Microsoft XPS Document Writer" && globalvariables.PrintChineseCharacters)
                        {
                            Matrix m = new Matrix();

                            // When text contains business name and below or equal to 5 lines and total header scale count is not yet equal,
                            // text must me scaled to large.
                            // When text contains 'amount due:', text must be scaled to large.
                            // Otherwise, text must be scaled to normal.
                            if ((globalvariables.BusinessName.ToLower().Contains(text.Trim().ToLower()) &&
                                y <= 5 && scaledHeaderTextCount != globalvariables.BusinessName.Count()) ||
                                text.ToLower().Contains("amount due:"))
                            {
                                yScale = yScaleLarge;

                                // While 'scaledHeaderTextCount' is not equal to Business Name text count,
                                // add trimmed text count to scaled header text count.
                                if (scaledHeaderTextCount != globalvariables.BusinessName.Count())
                                    scaledHeaderTextCount += text.Trim().Count();
                            }
                            else
                                yScale = yScaleNormal;
                            m.Scale(xScale, yScale);
                            g.Transform = m;

                            if (yPoint > 0)
                                yPointScaled = yPoint / yScale;
                        }

                        g.DrawString(text, normalFont, solidBrush, new PointF(0, yPointScaled));

                        // When printer is not xps and enable printing of chinese characters, text must be transform(scale).
                        if (this.PrinterName != "Microsoft XPS Document Writer" && globalvariables.PrintChineseCharacters)
                            g.ResetTransform();

                        if (maxLine != 0 && y > maxLine)
                        {
                            this.byteIndex = i + 1;
                            e.HasMorePages = true;
                            return;
                        }

                        yPoint += (yMultiplier * yScale);
                        y++;
                        text = "";
                    }
                }
            }
        }

        private void betterPrintImage(int[][] pixels)
        {
            int height = pixels.Length;
            int width = pixels[0].Length;
            setSpacingForImage();
            byte[] lengthByte = new byte[] { 0x1B, 0x2A, 0x00, (byte)(0x00FF & width), (byte)((0xFF00 & width) >> 8) };

            for (int y = 0; y < height; y += 8)
            {
                // Select image mode. (Needs to be done per line)
                addBytesToBuffer(new byte[] { 0x1B, 0x2A, 33 });
                // Send nL and nH
                addBytesToBuffer(lengthByte);

                // Process one block of 8x8
                for (int x = 0; x < width; x += 8)
                    addBytesToBuffer(process8x8(pixels, x, y));

                addStringToBuffer("\n\r");
            }
            setSpacingForText();
        }
        private byte[] process8x8(int[][] pixels, int x, int y)
        {
            int yEnd = Math.Min(pixels.Length, y + 8);
            int xEnd = Math.Min(pixels[0].Length, x + 8);
            List<byte> result = new List<byte>();

            for (int j = x; j < xEnd; j++)
            {
                byte temp = 0;
                for (int i = y; i < yEnd; i++)
                {
                    temp <<= 1;
                    if (pixels[i][j] != 0)
                        temp |= 0x01;
                }
                result.Add(temp);
            }
            return result.ToArray();
        }

        private void setSpacingForText()
        {
            // Special case where spacing becomes very small for EPSON TM-T82 (Thermal Printer)
            if (this.LineSpacing == 0)
            {
                if (StringFullWidth == 64)
                    addBytesToBuffer(new byte[] { 0x1B, 0x33, 50 });
                else
                    addBytesToBuffer(new byte[] { 0x1B, 0x33, 20 });
            }
            else
            {
                addBytesToBuffer(new byte[] { 0x1B, 0x33, (byte)LineSpacing });
            }
        }
        private void setSpacingForImage()
        {
            addBytesToBuffer(new byte[] { 0x1B, 0x33, 8 });
        }

        private int subStringAdjust { get; set; }
        private string subString(string text, int start, int lenght)
        {
            string tempString = "";
            List<byte> chineseBytes = new List<byte>();
            byte[] gb18030bytes = System.Text.Encoding.GetEncoding("GB18030").GetBytes(text);
            int minBytesIndex = (start < 0) ? 0 : (start - subStringAdjust);
            int maxBytesIndex = minBytesIndex + lenght + subStringAdjust;
            if (subStringAdjust > 0)
                subStringAdjust = 0;
            for (int x = minBytesIndex; x < maxBytesIndex; x++)
            {
                if (gb18030bytes[x] > 127)
                    chineseBytes.Add(gb18030bytes[x]);

                if (chineseBytes.Count() >= 1 && (gb18030bytes[x] < 127 || x + 1 == maxBytesIndex))
                {
                    if (chineseBytes.Count % 2 == 1 && gb18030bytes.Count() > x + 1)
                    {
                        chineseBytes.RemoveAt(chineseBytes.Count - 1);
                        subStringAdjust = 1;
                    }

                    tempString += System.Text.Encoding.GetEncoding("GB18030").GetString(chineseBytes.ToArray());
                    chineseBytes.Clear();
                }

                if (gb18030bytes[x] < 127 && chineseBytes.Count() != 1)
                    tempString += (char)gb18030bytes[x];
            }
            return tempString;
        }
        private string getFormattedString(string text, StringAlignment alignment, int maxLineLength)
        {
            AlignmentMethod alignmentMethod = leftAlignString;
            subStringAdjust = 0;
            switch (alignment)
            {
                case StringAlignment.Center:
                    alignmentMethod = centerAlignString;
                    break;
                case StringAlignment.Far:
                    alignmentMethod = rightAlignString;
                    break;
                case StringAlignment.Near:
                    alignmentMethod = leftAlignString;
                    break;
            }
            if (textLength(text) > maxLineLength)
            {
                string tempString1 = "";
                string tempString2 = "";
                string[] stringArray = text.Split(' ');
                text = "";
                for (int i = 0; i < stringArray.Length; i++)
                {
                    string textIterator = stringArray[i];
                    tempString1 += ' ' + textIterator;
                    if (textLength(textIterator) > maxLineLength)
                    {
                        int truncateIndex = maxLineLength;
                        if (tempString2.Length > 0)
                            truncateIndex = truncateIndex - textLength(tempString2) - 1;
                        //string partsOfIterator = textIterator.Substring(0, truncateIndex);
                        string partsOfIterator = subString(textIterator, 0, truncateIndex);

                        if (tempString2 != "")
                            tempString2 = subString(tempString2, 1, textLength(tempString2) - 1);

                        if (tempString2.Length > 0)
                            text += alignmentMethod(tempString2 + ' ' + partsOfIterator, maxLineLength).Trim() + "\n\r";
                        else
                            text += alignmentMethod(partsOfIterator, maxLineLength).Trim() + "\n\r";

                        for (; truncateIndex < textLength(textIterator); truncateIndex += maxLineLength)
                        {
                            if (truncateIndex + maxLineLength <= textLength(textIterator))
                                //text += textIterator.Substring(truncateIndex, maxLineLength) + "\n\r";
                                text += alignmentMethod(subString(textIterator, truncateIndex, maxLineLength), maxLineLength).Trim() + "\n\r";
                            else
                                //text += textIterator.Substring(truncateIndex, textIterator.Length - truncateIndex);
                                text += alignmentMethod(subString(textIterator, truncateIndex, textLength(textIterator) - truncateIndex), maxLineLength);
                        }
                        tempString1 = "";
                        tempString2 = "";
                    }
                    // Minus 1 is for the extra leading space
                    else if (textLength(tempString1) - 1 > maxLineLength)
                    {
                        if (tempString2 != "")
                            //tempString2 = tempString2.Substring(1, tempString2.Length - 1);
                            tempString2 = subString(tempString2, 1, textLength(tempString2) - 1);
                        text += alignmentMethod(tempString2, maxLineLength) + "\n\r";
                        tempString1 = ' ' + textIterator;
                        tempString2 = tempString1;
                    }
                    else if (textLength(tempString1) == maxLineLength || textLength(tempString1) - 1 == maxLineLength)
                    {
                        //text += alignmentMethod(tempString1.Substring(1, textLength(tempString1) - 1), maxLineLength) + "\n\r";
                        text += alignmentMethod(subString(tempString1, 1, textLength(tempString1) - 1), maxLineLength) + "\n\r";
                        tempString1 = "";
                        tempString2 = "";
                    }
                    // Cancelled out Minus 1 to consider trailing space for line && tempString1.Length < maxLineLength
                    else if (i != stringArray.Length - 1)
                    {
                        tempString2 = tempString1;
                    }
                    else
                    {
                        if (tempString1 != "")
                            //text += alignmentMethod(tempString1.Substring(1, textLength(tempString1) - 1), maxLineLength);
                            text += alignmentMethod(subString(tempString1, 1, textLength(tempString1) - 1), maxLineLength);
                        tempString1 = "";
                        tempString2 = "";
                    }
                }
                if (tempString1 != "")
                    //text += alignmentMethod(tempString1.Substring(1, textLength(tempString1) - 1), maxLineLength);
                    text += alignmentMethod(subString(tempString1, 1, textLength(tempString1) - 1), maxLineLength);
            }
            else
            {
                text = alignmentMethod(text, maxLineLength);
            }
            List<string> padderListString = text.Split('\n', '\r').ToList();
            padderListString.RemoveAll(x => x == "");
            text = "";
            for (int i = 0; i < padderListString.Count; i++)
            {
                string tempText = padderListString[i];
                int length = maxLineLength - textLength(tempText);
                for (int j = 0; j < length; j++)
                    tempText += " ";
                text += tempText;
                if (i != padderListString.Count - 1)
                    text += "\n\r";
            }

            //Check if there is a chinese char on productname
            for (int index = 0; index < text.Length; index++)
            {
                if (char.GetUnicodeCategory(text[index]) == UnicodeCategory.OtherLetter)
                {
                    globalvariables.PrintChineseCharacters = true;
                    break;
                }
            }

            return text;
        }
        private string centerAlignString(string text)
        {
            return centerAlignString(text, this.StringWidth);
        }
        private string centerAlignString(string text, int maxLength)
        {
            int spaceleft = maxLength - textLength(text);
            int leftindent = spaceleft / 2;
            int totallength = leftindent + text.Length;
            return String.Format("{0, " + totallength + "}", text);
        }
        private int textLength(string text)
        {
            byte[] gb18030bytes = System.Text.Encoding.GetEncoding("GB18030").GetBytes(text);
            int chineseChars = gb18030bytes.Where(x => x > 127).Count();
            return gb18030bytes.Where(x => x <= 127).Count() + chineseChars;
        }
        private string rightAlignString(string text)
        {
            return rightAlignString(text, this.StringWidth);
        }
        private string rightAlignString(string text, int maxLength)
        {
            return String.Format("{0, " + (maxLength) + "}", text);
        }
        private string leftAlignString(string text)
        {
            return leftAlignString(text, this.StringWidth);
        }
        private string leftAlignString(string text, int maxLength)
        {
            return text;
        }

        private void addBytesToBuffer(byte[] bytes)
        {
            List<byte> tempBuffer = this.buffer.ToList();
            foreach (byte x in bytes)
                tempBuffer.Add(x);
            this.buffer = tempBuffer.ToArray();
        }
        private void addStringToBuffer(string text)
        {
            List<byte> tempBuffer = this.buffer.ToList();
            //foreach (char x in text)
            //    tempBuffer.Add((byte)x);
            byte[] gb18030bytes = System.Text.Encoding.GetEncoding("GB18030").GetBytes(text);
            foreach (byte b in gb18030bytes)
                tempBuffer.Add(b);

            this.buffer = tempBuffer.ToArray();
        }

        private delegate string AlignmentMethod(string text, int maxLength);
        public void SaveToFile(string fileNameAndPath, bool deleteExistingFile)
        {
            try
            {
                new FileInfo(fileNameAndPath).Directory.Create();
            }
            catch
            {
                Directory.CreateDirectory(DirectoryLocation);
            }
            if (deleteExistingFile)
            {
                if (File.Exists(fileNameAndPath))
                    File.Delete(fileNameAndPath);
            }
            string text = "";
            List<byte> chinseBytes = new List<byte>();
            List<byte> byteListTemp = new List<byte>();
            foreach (byte cmd in this.buffer)
            {
                // Command bytes
                if (cmd == 0x1C || cmd == 0x1B || byteListTemp.Count > 0)
                {
                    byteListTemp.Add(cmd);
                    byte[] array = byteListTemp.ToArray();

                    // CPI12()
                    if (array.Count() == 3 && array[0] == 0x1B && array[1] == 0x4D)
                        byteListTemp.Clear();
                    // NormalFont(), LargeFont()
                    else if (array.Count() == 3 && array[0] == 0x1B && array[1] == 0x21)
                        byteListTemp.Clear();
                    else if (array.Count() == 3 && array[0] == 0x1C && array[1] == 0x21)
                        byteListTemp.Clear();
                    // Set Font Spacing
                    else if (array.Count() == 3 && array[0] == 0x1B && array[1] == 0x33)
                        byteListTemp.Clear();
                    // Chinese Font Spacing
                    else if (array.Count() == 4 && array[0] == 0x1C && array[1] == 0x53)
                        byteListTemp.Clear();
                }
                // Text
                else
                {
                    if (cmd > 127)
                        chinseBytes.Add(cmd);

                    if (chinseBytes.Count == 2)
                    {
                        text += System.Text.Encoding.GetEncoding("GB18030").GetString(chinseBytes.ToArray());
                        chinseBytes.Clear();
                    }
                    else if (chinseBytes.Count != 1)
                        text += (char)cmd;
                    if (text.Contains("\n\r") || textLength(text) + chinseBytes.Count == this.StringFullWidth)
                    {
                        using (StreamWriter writer =
                            new StreamWriter(fileNameAndPath, true))
                        {
                            writer.WriteLine(text);
                        }
                        text = "";

                    }
                }
            }
        }
        private int _lineSpacing;
        private byte[] buffer;

        public PrintDocument doc = new PrintDocument();
        public static PrintingType EJournalReceipt = PrintingType.NormalPrinting;
        public static string DirectoryLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string ReceiptFileName = "";
    }
}
