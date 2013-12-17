using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PicBook.Models;

namespace DAL
{
      public static class PicBookRepository
    {
        
        public static IEnumerable<Pin> GetPins(string bid)
        {
            List<Pin> objList;
            objList = new List<Pin>();
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            // Provide the query string with a parameter placeholder. 
            string queryString = "SELECT * from pins where bid =" + bid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       
                            string pid = reader[0].ToString();
                            string url = reader["pin_url"].ToString();
                            string descrip = reader["descrip"].ToString();
                            string original_pid = reader["original_pid"].ToString();
                        string hashtag="";
                            IEnumerable<string> hashtagList = GetHashtag(pid);
                            foreach (string s in hashtagList)
                                hashtag = hashtag+"#"+s;
                            objList.Add(new Pin() { pid = pid, Url = url, Description = descrip, original_pid=original_pid });
                      
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }

            }
          
            return objList;
        }

        public static IEnumerable<Board> GetBoards(string mid)
        {
            List<Board> objList= new List<Board>();
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            
            // Provide the query string with a parameter placeholder. 
            string queryString = "SELECT * from board where mid =" + mid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       
                        objList.Add(new Board() { thumbnail="Images/board.png", bid=reader[0].ToString(), mid= reader[1].ToString(), bname= reader[2].ToString(), permission=reader[3].ToString(), descrip=reader[4].ToString() });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }

            }

            return objList;
        }

        public static Pin GetPin(string pid)
        {
            Pin pinObj = new Pin();
           
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            
            // Provide the query string with a parameter placeholder. 
            string queryString = "SELECT * from pins where pid =" + pid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        
                            string ppid = reader[0].ToString();
                            string url = reader["pin_url"].ToString();
                            string descrip = reader["descrip"].ToString();
                            string original_pid = reader["original_pid"].ToString();
                            string hashtag = "";
                            IEnumerable<string> hashtagList = GetHashtag(pid);
                            foreach (string s in hashtagList)
                                hashtag = hashtag + "#" + s;
                            pinObj.pid = ppid;
                        pinObj.Url = url;
                        pinObj.Description = descrip ;
                        pinObj.Hashtag = hashtag;
                        pinObj.original_pid = original_pid;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }

            }

            return pinObj;
        }

        public static IEnumerable<Comment> GetComments(string pid)
        {
            List<Comment> comments = new List<Comment>();

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

            // Provide the query string with a parameter placeholder. 
            string queryString = "SELECT * from comments where pid =" + pid + " order by time_created";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Comment obj = new Comment();
                        string mid = reader["mid"].ToString();
                        string ppid = reader["pid"].ToString();
                        string comment = reader["comment"].ToString();
                        string mname = GetUserName(mid);
                        obj.pid = ppid;
                        obj.mid = mid;
                        obj.comment = comment;
                        obj.mname = mname;

                        comments.Add(obj);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }

            }

            return comments;
        }

        public static Like GetLikes(string pid)
        {
            Like obj = new Like();

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            string original_pid = GetPin(pid).original_pid;
            // Provide the query string with a parameter placeholder. 
            string queryString = "select COUNT(*) from likes where pid ="+original_pid+" group by pid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    object temp = command.ExecuteScalar();
                    obj.count = (temp == null ? "0" : temp.ToString());
                    obj.pid = pid;
                    
                }
                catch (Exception ex)
                {

                }

            }

            return obj;
        }

        public static bool HasLiked(string mid, string pid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            bool retVal = false;
            string original_pid = GetPin(pid).original_pid;
            // Provide the query string with a parameter placeholder. 
            string queryString = "select COUNT(*) from likes where pid =" + original_pid + " and like_mid=" + mid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                   retVal= command.ExecuteScalar().ToString().Equals("1");
                    

                }
                catch (Exception ex)
                {

                }

            }
            return retVal;
        }

        public static bool IsOwnerOfBoard(string mid, string bid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            bool retVal = false;
           // string original_pid = GetPin(pid).original_pid;
            // Provide the query string with a parameter placeholder. 
            string queryString = "select COUNT(*) from board where bid =" + bid + " and mid=" + mid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    retVal = command.ExecuteScalar().ToString().Equals("1");


                }
                catch (Exception ex)
                {

                }

            }

            return retVal;
        }

        public static bool IsFollowingBoard(string mid, string bid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            bool retVal = false;
            // string original_pid = GetPin(pid).original_pid;
            // Provide the query string with a parameter placeholder. 
            string queryString = "select COUNT(*) from follows where bid =" + bid + " and mid=" + mid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    retVal = command.ExecuteScalar().ToString().Equals("1");


                }
                catch (Exception ex)
                {

                }

            }

            return retVal;
        }



        public static bool ModifyLike(string mid, string pid, string flag)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString="";
           if (flag.Equals("like"))
               queryString = "LikePin";
           else
               queryString = "UnLikePin";
           string original_pid = GetPin(pid).original_pid;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@pid", SqlDbType.Int);
                command.Parameters.Add("@like_mid", SqlDbType.Int);
                command.Parameters["@pid"].Value = Convert.ToInt32(original_pid);
                command.Parameters["@like_mid"].Value = Convert.ToInt32(mid);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        
        }

        public static bool AddComment(string mid, string pid, string comment)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            string queryString = "";
            queryString = "CommentPin";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@mid", SqlDbType.Int);
                command.Parameters.Add("@pid", SqlDbType.Int);
                command.Parameters.Add("@comment", SqlDbType.Text);
                command.Parameters["@pid"].Value = Convert.ToInt32(pid);
                command.Parameters["@mid"].Value = Convert.ToInt32(mid);
                command.Parameters["@comment"].Value = comment;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }

        public static bool AddBoard(string mid, string bname, string descrip, string permission)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            string queryString = "";
            queryString = "CreateBoard";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@mid", SqlDbType.Int);
                command.Parameters.Add("@board_name", SqlDbType.VarChar,25);
                command.Parameters.Add("@discrip", SqlDbType.Text);
                command.Parameters.Add("@permission", SqlDbType.VarChar, 1);
                command.Parameters["@board_name"].Value = bname;
                command.Parameters["@mid"].Value = Convert.ToInt32(mid);
                command.Parameters["@discrip"].Value = descrip;
                command.Parameters["@permission"].Value = permission;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }

        public static bool AddToFollowStream(string fs_id, string bid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            string queryString = "";
            queryString = "AddToFollowStream";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@fs_id", SqlDbType.Int);
                command.Parameters.Add("@bid", SqlDbType.Int);

                command.Parameters["@fs_id"].Value = Convert.ToInt32(fs_id);
                command.Parameters["@bid"].Value = Convert.ToInt32(bid);
               
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }

        public static bool PinTag(string pid, string tagname)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            string queryString = "";
            queryString = "PinTag";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@pid", SqlDbType.Int);
                command.Parameters.Add("@tagname", SqlDbType.VarChar, 50);
                command.Parameters["@pid"].Value =Convert.ToInt32( pid);
                command.Parameters["@tagname"].Value =tagname;
                
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return true;
        }

        public static string AddPin(string mid,string bid,string pin_url,string source_url,string descrip, HttpServerUtility obj)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            string queryString = "";
            string pid = "";
            queryString = "PinPicture";
            SqlParameter newpid = new SqlParameter("@newpid", SqlDbType.Int) { Direction = ParameterDirection.Output };
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.Add("@bid", SqlDbType.Int);
                command.Parameters.Add("@pin_url", SqlDbType.Text);
                command.Parameters.Add("@source_url", SqlDbType.Text);
                command.Parameters.Add("@descrip", SqlDbType.Text);
                command.Parameters.Add(newpid);
                command.Parameters["@bid"].Value = bid;
                command.Parameters["@pin_url"].Value = pin_url;
                command.Parameters["@source_url"].Value = source_url;
                command.Parameters["@descrip"].Value = descrip;
            
                
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return null;
                }

            }
            
            return newpid.Value.ToString();
        }
        
       public static string GetPid(string username, string password)
        {
            object mid=new object();

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

            // Provide the query string with a parameter placeholder. 
            string queryString = "SELECT mid from member where email ='" + username +"' and pswd ='"+password+"'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.  
                // Create and execute the DataReader, writing the result 
                // set to the console window. 
                try
                {
                    connection.Open();
                    mid = command.ExecuteScalar();
                }
                catch (Exception ex)
                {

                }

            }

            if (mid == null)
                return "";
            return mid.ToString();
        }

       public static bool CreateUser(string username, string first_name, string middle_name, string last_name, string pswd, string email)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "CreateAccount";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@username", SqlDbType.VarChar,25);
               command.Parameters.Add("@first_name", SqlDbType.VarChar,50);
               command.Parameters.Add("@middle_name", SqlDbType.VarChar,50);
               command.Parameters.Add("@last_name", SqlDbType.VarChar, 50);
               command.Parameters.Add("@pswd", SqlDbType.VarChar);
               command.Parameters.Add("@email", SqlDbType.VarChar, 30);
               command.Parameters["@username"].Value = username;
               command.Parameters["@first_name"].Value = first_name;
               command.Parameters["@middle_name"].Value = middle_name;
               command.Parameters["@last_name"].Value = last_name;
               command.Parameters["@pswd"].Value = pswd;
               command.Parameters["@email"].Value = email;
               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       public static bool SendFriendRequest(string mid, string friend_mid, string status)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "SendFriendRequest";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@mid", SqlDbType.Int);
               command.Parameters.Add("@friend_mid", SqlDbType.Int);
               command.Parameters.Add("@status", SqlDbType.VarChar, 1);
               command.Parameters["@mid"].Value = Convert.ToInt32(mid);
               command.Parameters["@friend_mid"].Value = Convert.ToInt32(friend_mid);
               command.Parameters["@status"].Value = status;
               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       public static bool UpdateFriendRequest(string mid, string friend_mid, string status)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "UpdateFriendRequest";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@mid", SqlDbType.Int);
               command.Parameters.Add("@friend_mid", SqlDbType.Int);
               command.Parameters.Add("@status", SqlDbType.VarChar, 1);
               command.Parameters["@mid"].Value = Convert.ToInt32(friend_mid);
               command.Parameters["@friend_mid"].Value = Convert.ToInt32(mid);
               command.Parameters["@status"].Value=status;
               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       public static bool RepinPicture(string bid, string pid, string descrip)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           string original_pid = GetPin(pid).original_pid;
           queryString = "RepinPicture";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@bid", SqlDbType.Int);
               command.Parameters.Add("@original_pid", SqlDbType.Int);
               command.Parameters.Add("@descrip", SqlDbType.Text);

               command.Parameters["@bid"].Value = Convert.ToInt32(bid);
               command.Parameters["@original_pid"].Value = Convert.ToInt32(original_pid);
               command.Parameters["@descrip"].Value=descrip;

               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       public static bool CreateFollowStreamBoard(string mid, string fs_name)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "CreateFollowStream";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@mid", SqlDbType.Int);
               command.Parameters.Add("@fsname", SqlDbType.VarChar,50);
               command.Parameters["@mid"].Value=mid;
               command.Parameters["@fsname"].Value = fs_name;
               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       public static IEnumerable<Friend> GetFriends(string mid)
       {
           List<Friend> objList = new List<Friend>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           // Provide the query string with a parameter placeholder. 
           string queryString = "select mid,username from member where mid in (select friend_mid from friends where mid ="+mid+" and status='y' union (select mid from friends where friend_mid="+mid+" and status = 'y'))";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);
               SqlDataReader dr ;
               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   dr = command.ExecuteReader();
                   while (dr.Read())
                   {
                       Friend obj = new Friend(){ mid=dr[0].ToString(), fname=dr[1].ToString() };
                       objList.Add(obj);
                   }
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
       }

       public static IEnumerable<Friend> GetPFriends(string mid)
       {
           List<Friend> objList = new List<Friend>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           // Provide the query string with a parameter placeholder. 
           string queryString = "select mid,username from member where mid in (select mid from friends where friend_mid =" + mid + " and status='p')";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);
               SqlDataReader dr;
               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   dr = command.ExecuteReader();
                   while (dr.Read())
                   {
                       Friend obj = new Friend() { mid = dr[0].ToString(), fname = dr[1].ToString() };
                       objList.Add(obj);
                   }
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
       }

       public static string GetUserName(string mid)
       {
           string username = "";

           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "SELECT username from member where mid ='"+ mid + "'";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   username = (string)(command.ExecuteScalar());
               }
               catch (Exception ex)
               {

               }

           }

           if (username   == null)
               return "";
           return username.ToString();
        
           
       }

       internal static string GetBoardName(string bid)
       {
           string boardname = "";

           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "SELECT board_name from board where bid ='" + bid + "'";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   boardname = (string)(command.ExecuteScalar());
               }
               catch (Exception ex)
               {

               }

           }

           if (boardname == null)
               return "";
           return boardname.ToString();
       }

       internal static List<string> GetHashtag(string pid)
       {
           List<string> hashtags = new List<string>();

           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           //string original_pid = GetPin(pid).original_pid;
           // Provide the query string with a parameter placeholder. 
           string queryString = "select tags.tag_name from pins, pintags, tags where pins.original_pid=pintags.pid and pintags.tid=tags.tid and pins.pid=" + pid;
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);
               SqlDataReader dr;
               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   dr = command.ExecuteReader();
                   while (dr.Read())
                   {
                       hashtags.Add(dr[0].ToString());
                   }
                  
               }
               catch (Exception ex)
               {
                   return null;
               }

           }


           return hashtags;
       }

       internal static Member GetUserProfile(string mid)
       {
           Member user=new Member();

           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "SELECT * from member where mid ='" + mid + "'";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);
               SqlDataReader dr;
               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   dr = command.ExecuteReader();
                   while (dr.Read())
                   {
                       user.fname = dr["first_name"].ToString();
                       user.mname = dr["middle_name"].ToString();
                       user.lname = dr["last_name"].ToString();
                       user.pswd = dr["pswd"].ToString();
                   }
               }
               catch (Exception ex)
               {
                   return null;
               }

           }

           return user;
       }



       internal static bool UpdateProfile(string mid, string fname, string mname, string lname, string pswd)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "UpdateProfile";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@mid", SqlDbType.Int);
               command.Parameters.Add("@firstname", SqlDbType.VarChar, 50);
               command.Parameters.Add("@middle_name", SqlDbType.VarChar, 50);
               command.Parameters.Add("@last_name", SqlDbType.VarChar, 50);
               command.Parameters.Add("@pswd", SqlDbType.VarChar);
               command.Parameters["@mid"].Value = Convert.ToInt32(mid);
               command.Parameters["@firstname"].Value = fname;
               command.Parameters["@middle_name"].Value = mname;
               command.Parameters["@last_name"].Value = lname;
               command.Parameters["@pswd"].Value = pswd;

               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       internal static IEnumerable<Board> GetFollowingBoards(string mid)
       {
           List<Board> objList = new List<Board>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "SELECT * from board where bid in(select bid from follows where mid=" + mid+")";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   while (reader.Read())
                   {

                       objList.Add(new Board() { thumbnail = "Images/board.png", bid = reader[0].ToString(), mid = reader[1].ToString(), bname = reader[2].ToString(), permission = reader[3].ToString(), descrip = reader[4].ToString() });
                   }
                   reader.Close();
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
        
       }

       internal static bool FollowBoard(string mid, string bid , string commandname)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           if (commandname.Equals("Follow"))
               queryString = "FollowBoard";
           else
               queryString = "UnFollowBoard";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@mid", SqlDbType.Int);
               command.Parameters.Add("@bid", SqlDbType.Int);
               command.Parameters["@mid"].Value = Convert.ToInt32(mid);
               command.Parameters["@bid"].Value = Convert.ToInt32(bid); ;
              
               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       internal static IEnumerable<FwStream> GetFollowStreams(string mid)
       {
           List<FwStream> objList = new List<FwStream>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "SELECT * from followstream where mid="+mid;
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   while (reader.Read())
                   {

                       objList.Add(new FwStream() { thumbnail = "Images/stream.jpeg", fsid = reader[0].ToString(), fsname = reader[1].ToString() });
                   }
                   reader.Close();
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
       }

       internal static IEnumerable<Pin> GetFSPins(string fsid)
       {
           List<Pin> objList;
           objList = new List<Pin>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           // Provide the query string with a parameter placeholder. 
           string queryString = "SELECT * from pins where bid in (select bid from followstreamboards where fsid=" + fsid+")";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   while (reader.Read())
                   {

                       string pid = reader[0].ToString();
                       string url = reader["pin_url"].ToString();
                       string descrip = reader["descrip"].ToString();
                       string original_pid = reader["original_pid"].ToString();
                       string hashtag = "";
                       IEnumerable<string> hashtagList = GetHashtag(pid);
                       foreach (string s in hashtagList)
                           hashtag = hashtag + "#" + s;
                       objList.Add(new Pin() { pid = pid, Url = url, Description = descrip, original_pid = original_pid });

                   }
                   reader.Close();
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
       }

       internal static string GetFSBoardName(string fsid)
       {
           string boardname = "";

           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "SELECT fsname from followstream where fsid ='" + fsid + "'";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   boardname = (string)(command.ExecuteScalar());
               }
               catch (Exception ex)
               {

               }

           }

           if (boardname == null)
               return "";
           return boardname.ToString();
       }

       internal static IEnumerable<Board> GetFBoards(string mid)
       {
           List<Board> objList;
           objList = new List<Board>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           // Provide the query string with a parameter placeholder. 
           string queryString = "select bid,board_name from board where bid in( select bid from follows where mid=" + mid+")" ;
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   while (reader.Read())
                   {

                       string bid = reader[0].ToString();
                       string bname = reader[1].ToString();
                       
                       
                       objList.Add(new Board() { bname = bname, bid=bid});

                   }
                   reader.Close();
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
       }



       internal static IEnumerable<PicBook.Models.Friend> GetMemberSearchResult(string searchStr)
       {
           List<Friend> users = new List<Friend>();

           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "select * from member where email = '"+searchStr+"' union (select * from member where username like '%"+searchStr+"%')";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);
               SqlDataReader dr;
               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   dr = command.ExecuteReader();
                   while (dr.Read())
                   {
                       Friend user = new Friend();
                       user.fname = dr["username"].ToString();
                       user.mid = dr["mid"].ToString();
                       users.Add(user);
                   }
               }
               catch (Exception ex)
               {
                   return null;
               }

           }

           return users;
       }

       internal static IEnumerable<PicBook.Models.Pin> GetPinSearchResult(string searchStr)
       {

           List<Pin> objList;
           objList = new List<Pin>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           // Provide the query string with a parameter placeholder. 
           string queryString = "select * from pins where pid in (select pid from pintags where tid in (select tid from tags where tag_name like '%"+searchStr+"%'))";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   while (reader.Read())
                   {

                       string pid = reader[0].ToString();
                       string url = reader["pin_url"].ToString();
                       string descrip = reader["descrip"].ToString();
                       string original_pid = reader["original_pid"].ToString();
                       string hashtag = "";
                       IEnumerable<string> hashtagList = GetHashtag(pid);
                       foreach (string s in hashtagList)
                           hashtag = hashtag + "#" + s;
                       objList.Add(new Pin() { pid = pid, Url = url, Description = descrip, original_pid = original_pid });

                   }
                   reader.Close();
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
        
       }

       internal static IEnumerable<PicBook.Models.Board> GetBoardSearchResult(string searchStr)
       {
           List<Board> objList = new List<Board>();
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

           // Provide the query string with a parameter placeholder. 
           string queryString = "select * from board where board_name like '%"+searchStr+"%'";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   while (reader.Read())
                   {

                       objList.Add(new Board() { thumbnail = "Images/board.png", bid = reader[0].ToString(), mid = reader[1].ToString(), bname = reader[2].ToString(), permission = reader[3].ToString(), descrip = reader[4].ToString() });
                   }
                   reader.Close();
               }
               catch (Exception ex)
               {

               }

           }

           return objList;
       
       }



       internal static bool DeleteBoard(string p, string bid)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "DeleteBoard";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@bid", SqlDbType.Int);
               command.Parameters["@bid"].Value = Convert.ToInt32(bid); ;

               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       internal static bool DeleteFriend(string mid, string friend_mid)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "Unfriend";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@mid", SqlDbType.Int);
               command.Parameters.Add("@friend_mid", SqlDbType.Int);
               command.Parameters["@mid"].Value = Convert.ToInt32(friend_mid);
               command.Parameters["@friend_mid"].Value = Convert.ToInt32(mid);
               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }

       internal static bool IsOwnerOfPin(string mid, string pid)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           bool retVal = false;
           // string original_pid = GetPin(pid).original_pid;
           // Provide the query string with a parameter placeholder. 
           string queryString = "select COUNT(*) from pins where pid =" + pid + " and bid in (select bid from board where mid=" + mid + ")";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               // Create the Command and Parameter objects.
               SqlCommand command = new SqlCommand(queryString, connection);

               // Open the connection in a try/catch block.  
               // Create and execute the DataReader, writing the result 
               // set to the console window. 
               try
               {
                   connection.Open();
                   retVal = command.ExecuteScalar().ToString().Equals("1");


               }
               catch (Exception ex)
               {

               }

           }

           return retVal;
       }

       internal static bool DeletePin(string p, string pid)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString = "";
           queryString = "DeletePicture";
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               SqlCommand command = new SqlCommand(queryString, connection);
               command.CommandType = System.Data.CommandType.StoredProcedure;
               command.Parameters.Add("@pid", SqlDbType.Int);
               command.Parameters["@pid"].Value = Convert.ToInt32(pid); ;

               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();

               }
               catch (Exception ex)
               {
                   return false;
               }

           }
           return true;
       }
    }
}