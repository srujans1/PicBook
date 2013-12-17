using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PicBook.Models
{
    public class Pin
    {
        public string pid { get; set; }
        public string original_pid { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Hashtag { get; set; }
    }

    public class Board
    {
        public string bid { get; set; }
        public string mid { get; set; }
        public string bname { get; set; }
        public string permission { get; set; }
        public string descrip { get; set; }
        public string thumbnail { get; set; }
    }

    public class Comment
    {
        public string mid { get; set; }
        public string pid { get; set; }
        public string mname { get; set; }
        public string comment { get; set; }

    }

    public class Like
    {
        public string pid { get; set; }
        public string count { get; set; }
    }

    public class Friend
    {
       public string mid { get; set; }
        public string fname { get; set; }
    }

    public class Member
    {

        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string pswd { get; set; }
        
    
    }

    public class FwStream
    {
        public string fsid { get; set; }
        public string fsname { get; set; }
        public string thumbnail { get; set; }
        public string descrip { get; set; }
      

    }
}