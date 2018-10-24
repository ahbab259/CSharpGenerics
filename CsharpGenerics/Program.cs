using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.Script.Serialization;


namespace CsharpGenerics
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string jsonDataFromURL = DataFromAPI<int>.getFromUrl(3);

            Console.WriteLine(jsonDataFromURL);
            Console.Read();
        }
    }

    public class DataFromAPI<T>
    {
        public static string getFromUrl(T userId)
        {

            using (WebClient wc = new WebClient())
            {
                string url = wc.DownloadString($"https://reqres.in/api/users/{userId}");
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                RootObject rootObject = (RootObject)javaScriptSerializer
                    .Deserialize(url, typeof(RootObject));


                return "Id: " + rootObject.data.id + "\nFirst Name: "
                    + rootObject.data.first_name + "\nLast Name: "
                    + rootObject.data.last_name;

            }   
        }
    }
}
