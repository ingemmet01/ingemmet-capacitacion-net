using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace Ingemmet.FirmaDocumento.Infrastructure.Helpers
{
    public class LetterAvatar
    {
        private List<string> _colours;

        public LetterAvatar()
        {
            _colours = new List<string> {
                "1ABC9C", "2ECC71", "3498DB", "9B59B6", "34495E", "16A085", "27AE60", "2980B9", "8E44AD", "2C3E50",
                "F1C40F", "E67E22", "E74C3C", "ECF0F1", "95A5A6", "F39C12", "D35400", "C0392B", "BDC3C7", "7F8C8D"
            };
        }

        public byte[] Generate(string name, short? size = 60)
        {
            name = !string.IsNullOrEmpty(name) ? name : string.Empty;

            string[] nameSplit = { };

            if (name.Length > 2)
                nameSplit = name.ToUpper().Split(' ');
            else
                nameSplit = name.Select(x => x.ToString()).ToArray();

            if (nameSplit.Length == 1)
                return Generate((!string.IsNullOrEmpty(nameSplit[0]) ? nameSplit[0] : "?"), "", (short)size);
            else
                return Generate(nameSplit[0], nameSplit[1], (short)size);
        }

        public byte[] Generate(string firstName, string lastName, short size)
        {
            var avatarString = string.Format("{0}{1}", firstName[0], lastName[0]).ToUpper();

            var randomIndex = new Random().Next(0, _colours.Count - 1);
            var bgColour = _colours[randomIndex];

            var bmp = new Bitmap(size, size);
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            var font = new Font("Arial", (int)(size / 3), FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bmp);

            graphics.Clear((Color)new ColorConverter().ConvertFromString("#" + bgColour));
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.DrawString(avatarString, font, new SolidBrush(Color.WhiteSmoke), new RectangleF(0, 0, size, size), sf);
            graphics.Flush();

            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }
    }
}
