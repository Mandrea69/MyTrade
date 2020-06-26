using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace OANDA.Data
{
    public class IEXRestResponse
    {
     
        public static string Get(string url)
        {
            string restResponse = "";

            var request = WebRequest.CreateHttp(url);
            //var accessToken = "pk_00f25b7de71b4afcb414bf6356a8170c";
            

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
