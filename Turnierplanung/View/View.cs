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
        public void leseTextEin(string text)
        {
            Text = text;
        }

        public string gebeTextAus()
        {
            Console.WriteLine(Text);
            return Text;
        }
        #endregion
    }
}