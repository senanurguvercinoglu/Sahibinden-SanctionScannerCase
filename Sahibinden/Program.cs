using System;
using HtmlAgilityPack;
using System.Text;
using System.Linq;
using System.IO;

namespace Sahibinden
{
    class Program
    {
        static void Main(string[] args)
        {
            //scraping with HtmlAgilityPack from website url
            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = website.Load("https://www.sahibinden.com/");
            //the expected part of the website which is "anasayfa vitrini" 
            var datalist= document.DocumentNode.SelectNodes("//div[@class = 'uiBox showcase']").ToList();
         
            foreach (var content in datalist)
            {
               //saving output info to the txt file which name is Sahibinden.txts
             
                FileStream fs = new FileStream("test.txt", FileMode.Create);
                // First, save the standard output.
                TextWriter tmp = Console.Out;
                StreamWriter sw = new StreamWriter(fs);
                Console.SetOut(sw);
                Console.WriteLine(content.InnerText);
                Console.SetOut(tmp);
                Console.WriteLine(content.InnerText);
                sw.Close();
            }
           
            Console.Read();
          
        }
    }
}
