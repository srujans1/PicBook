using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace PicBookUtitilies
{
    public static class Utilities
    {
        public static string DownloadImage(string url,string mid, HttpServerUtility obj)
        {
            byte[] data;
            string path="";
            using (WebClient client = new WebClient())
            {
                data = client.DownloadData(url);
            }
            if (data == null)
                return null;
            path = "Images/"+mid+"_"+ url.GetHashCode() + ".jpg";
                if (!File.Exists(obj.MapPath(path)))
                    File.WriteAllBytes(obj.MapPath(path), data);
            
            return path;
        }


    }
}