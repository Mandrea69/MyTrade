using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace Alphavantage.Data
{
    public class Rest
    {
       
        public static string Get(string url)
        {
            string restResponse = "";

            var request = WebRequest.CreateHttp(url);
                   

            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    restResponse = reader.ReadToEnd().Trim();

                }
            }


            return restResponse;

        }

    }
}
