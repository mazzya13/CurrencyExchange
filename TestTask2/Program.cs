using System;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace TestTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load("http://www.cbr.ru/scripts/XML_daily.asp");
            foreach (XElement Element in xdoc.Element("ValCurs").Elements("Valute"))
            {
                XAttribute ID = Element.Attribute("ID");
                XElement Code = Element.Element("CharCode");
                XElement Nominal = Element.Element("Nominal");
                XElement Value = Element.Element("Value");

                int IDs = int.Parse(Regex.Replace(ID.Value, @"\D", ""));


                if (ID != null && Code != null && Nominal != null && Value != null && IDs == 01200 )
                {
                    decimal ValueHK = decimal.Parse(Value.Value);
                    decimal NominalHk = decimal.Parse(Nominal.Value);
                    ValueHK /= NominalHk;
                    Console.WriteLine($"Курс Гонконского Доллара к Рублю равен: {ValueHK} - 1");
                }
            }

                Console.ReadKey();

        }
    }
}
