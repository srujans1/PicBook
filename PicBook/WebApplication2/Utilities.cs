using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace PicBook
{
    public static class Utilities
    {
        static void DownloadImage(string url,string mid)
        {
            byte[] data;
            using (WebClient client = new WebClient())
            {
                data = client.DownloadData(url);
            }
           string path="/Images/"+mid+"/"+url.GetHashCode()+".jpg";
            if(!File.Exists(path))
                File.WriteAllBytes(path,data);
        }


    }
}