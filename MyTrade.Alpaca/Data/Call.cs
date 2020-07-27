using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MyTrade.Alpaca.Data
{
    public class Call
    {
        public static string Get(string url)
        {
            string restResponse = "";

            var request = WebRequest.CreateHttp(url);
          
            request.Headers["APCA-API-KEY-ID"] = "PKXG4CYUCYA8GJLTOLIU";
            request.Headers["APCA-API-SECRET-KEY"] = "eXM0vVIZReeVXb2q91yqthsmlqCt21ODnmUGOr61";

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
