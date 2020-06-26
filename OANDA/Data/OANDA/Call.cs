using System;
using System.Collections.Generic;
using System.IO;
using System.Net;


namespace OANDA.Data
{
    public class OANDARestResponse
    {
        public static string Get(string url)
        {
            string restResponse = "";
                  
            var request = WebRequest.CreateHttp(url);
            var accessToken = "c617bb70fc4a9b6865ac98877b42025e-0887628a406a76c6a4bdc9939bd6a4fa";
            request.Headers[HttpRequestHeader.Authorization] = "Bearer " + accessToken;

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
