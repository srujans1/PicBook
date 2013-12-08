using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class Pin
    {
        public string pid { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
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
        public string comment { get; set; }
       
    }

    public class Like
    {
        public string pid { get; set; }
        public string count { get; set; }
    }

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
                            objList.Add(new Pin() { pid = pid, Url = url, Description = descrip });
                      
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
                       
                        objList.Add(new Board() { thumbnail="Images/board.jpg", bid=reader[0].ToString(), mid= reader[1].ToString(), bname= reader[2].ToString(), permission=reader[3].ToString(), descrip=reader[4].ToString() });
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
                            pinObj.pid = ppid;
                        pinObj.Url = url;
                        pinObj.Description = descrip ;
                        
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
                        obj.pid = ppid;
                        obj.mid = mid;
                        obj.comment = comment;
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

            // Provide the query string with a parameter placeholder. 
            string queryString = "select COUNT(*) from likes where pid ="+pid+" group by pid";
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
                    obj.count = command.ExecuteScalar().ToString();
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
            // Provide the query string with a parameter placeholder. 
            string queryString = "select COUNT(*) from likes where pid="+pid+" and like_mid="+mid;
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

        public static bool ModifyLike(string mid, string pid, string flag)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
           string queryString="";
           if (flag.Equals("like"))
               queryString = "LikePin";
           else
               queryString = "UnLikePin";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("@pid", SqlDbType.Int);
                command.Parameters.Add("@like_mid", SqlDbType.Int);
                command.Parameters["@pid"].Value = Convert.ToInt32(pid);
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
    }
}