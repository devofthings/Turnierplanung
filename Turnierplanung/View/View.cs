using System;

namespace Turnierplanung
{
    public class View
    {
        #region Attribute
        private string _standardText;
        #endregion

        #region Propertys
        public string Text { get => _standardText; set => _standardText = value; }
        #endregion

        #region Konstruktoren
        public View()
        {
            Text = "Hallo Welt!";
        }
        public View(string neuerStandardText)
        {
            Text = neuerStandardText;
        }
        #endregion

        #region Worker
        public void LeseTextEin(string text)
        {
            Text = text;
        }

        public string GebeTextAus()
        {
            Console.WriteLine(Text);
            return Text;
        }

        public void GebeTextDirektAus(string text)
        {
            Console.WriteLine(text);
        }
        #endregion
    }
}