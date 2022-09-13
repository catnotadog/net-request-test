using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Media;

namespace net_request_test
{
    class Program
    {
        static string url;
        static void request()
        {
            
            if (System.IO.File.Exists("url.txt"))
            {
                url = System.IO.File.ReadAllText("url.txt");
                if (url == "https://pastebin.com/raw/4KL0BtWb")
                {
                    Console.WriteLine("Using default url, press any key to continue.");
                    Console.ReadLine();
                } else
                {
                    Console.WriteLine("Press any key to select random line");
                    Console.ReadLine();
                }
            } else
            {
                Console.WriteLine("Writing default url to url.txt, press any key to continue");
                url = "https://pastebin.com/raw/4KL0BtWb";
                System.IO.File.WriteAllText("url.txt", url);
                Console.ReadLine();
            }
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            System.IO.File.WriteAllText("response.txt", responseFromServer);
        }
        static void Main(string[] args)
        {
            if (System.IO.File.Exists("response.txt"))
            {
                Console.WriteLine("Would you like to keep the previously grabbed list? (True/False)");
                string keep = Console.ReadLine();
                bool keep2;
                Boolean.TryParse(keep, out keep2);
                if (!keep2)
                {
                    System.IO.File.Delete("response.txt");
                    Console.Clear();
                }
            }
            if (!System.IO.File.Exists("response.txt"))
            {
                request();
                Console.Clear();

            }
            Random rnd = new Random();
            Console.WriteLine(System.IO.File.ReadAllLines("response.txt")[rnd.Next(0, System.IO.File.ReadAllLines("response.txt").Length)]);
            System.Media.SystemSounds.Beep.Play();
            Console.WriteLine("Made by catnotadog#0001 to learn more c#\npress any key to continue");
            Console.ReadLine();
        }
    }
}
