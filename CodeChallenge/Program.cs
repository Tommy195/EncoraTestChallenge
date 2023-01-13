using System;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

class MainClass
{

    static void Main()
    {

        //var request = WebRequest.Create("https://coderbyte.com/api/challenges/json/age-counting");
        //var response = request.GetResponse();

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");
        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            var data = (string)reader.ReadToEnd();
            var newData = Regex.Replace(data, @"^N\/A+", "");
            newData = Regex.Replace(newData, @"-", "");

            Console.WriteLine(newData);

        }
    }


    public class Rootobject
    {
        public Name name { get; set; }
        public int age { get; set; }
        public string DOB { get; set; }
        public string[] hobbies { get; set; }
        public Education education { get; set; }
    }

    public class Name
    {
        public string first { get; set; }
        public string middle { get; set; }
        public string last { get; set; }
    }

    public class Education
    {
        public string highschool { get; set; }
        public string college { get; set; }
    }

}
