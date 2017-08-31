using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using connect_to_ue;

namespace ConnectToUE
{
    public static class SQLHelper
    {

        public static string connectionString;
        private const int COMMAND_TIMEOUT = 2000;

        static SQLHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectToUE"].ConnectionString;
        }

        internal static DataTable Generate_my_channels(object id_user)
        {
            throw new NotImplementedException();
        }

        private static DataTable ExecuteStoredProcedure(string procedureName, params SqlParameter[] parameterList)
        {
            DataTable result = new DataTable();

            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.CommandTimeout = COMMAND_TIMEOUT;

            if (parameterList != null && parameterList.Length != 0)
            {
                cmd.Parameters.AddRange(parameterList);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                conn.Open();

                da.Fill(result);

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("An error occured while connecting to the database.");

                string parameters = string.Empty;

                foreach (SqlParameter sqlParameter in parameterList)
                {
                    parameters += sqlParameter.ParameterName + "=" + sqlParameter.Value.ToString() + ",";
                }
                if (parameters.Length > 0)
                    parameters = parameters.Substring(0, parameters.Length - 1);

                return null;
            }
            finally
            {
                // release resources
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                da.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private static DataSet ExecuteStoredProcedureToDataSet(string procedureName, params SqlParameter[] parameterList)
        {
            DataSet result = new DataSet();

            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.CommandTimeout = COMMAND_TIMEOUT;

            if (parameterList != null && parameterList.Length != 0)
            {
                cmd.Parameters.AddRange(parameterList);
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            try
            {
                conn.Open();

                da.Fill(result);

                return result;
            }
            catch (Exception ex)
            {
                string parameters = string.Empty;

                foreach (SqlParameter sqlParameter in parameterList)
                {
                    parameters += sqlParameter.ParameterName + "=" + sqlParameter.Value.ToString() + ",";
                }
                if (parameters.Length > 0)
                    parameters = parameters.Substring(0, parameters.Length - 1);


                return null;
            }
            finally
            {
                // release resources
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                da.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
        }

        private static object ExecuteCommandText(string text)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = text;

            try
            {
                conn.Open();

                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // release resources
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                cmd.Dispose();
                conn.Dispose();
            }
        }

        private static object ExecuteScalarFunction(string functionName, params object[] parameterList)
        {
            return ExecuteCommandText(GetFunctionQueryString(functionName, parameterList));
        }

        private static string GetFunctionQueryString(string function, object[] parameterList)
        {
            StringBuilder query = new StringBuilder("SELECT dbo.");
            query.Append(function);
            query.Append("(");

            foreach (object parameter in parameterList)
            {
                query.Append(parameter.ToString());
                if (parameterList[parameterList.Length - 1] != parameter)
                    query.Append(",");
            }

            query.Append(")");

            return query.ToString();
        }

        public static DataSet VerifyUser(string email , string password)
        {
            DataSet ds = ExecuteStoredProcedureToDataSet("Verificare_Utilizator", new SqlParameter[] {
                new SqlParameter("email",email),
                new SqlParameter("parola",password) });

            return ds;
        }

        public static DataTable GetChannels()
        {
            DataTable dt = ExecuteStoredProcedure("Selectare_Canale");
            return dt; 
        }

        public static DataTable InsertUser(string email, string password , int user_type)
        {
            DataTable dt = ExecuteStoredProcedure("Inserare_Utilizator", new SqlParameter[] {
                new SqlParameter("email",email),
                new SqlParameter("parola",password),
                new SqlParameter("tip_utilizator",user_type)
            });

            return dt;
        }

        public static DataTable InsertPreferences(int id_user, int id_channel)
        {
            DataTable dt = ExecuteStoredProcedure("Inserare_Preferinte", new SqlParameter[] {
                new SqlParameter("UtilizatorID",id_user),
                new SqlParameter("CanalID",id_channel)
                });
            return dt;
        }

        public static DataTable Show_Channels( )
        {
            DataTable dt = ExecuteStoredProcedure("Selectare_Canale");
            return dt;
        }

        public static DataTable Generate_my_channels(int id_user)
        {
            DataTable dt = ExecuteStoredProcedure("Generare_canale_preferate", new SqlParameter[] {
                new SqlParameter("UtilizatorID",id_user)
                });
            return dt;
        }

        public static DataTable Show_Articles ()
        {
            DataTable dt = ExecuteStoredProcedure("Selectare_Articole");
            return dt;
        }

        public static int giveNumegetID(string Nume)
        {
            DataTable dt = ExecuteStoredProcedure("giveNumegetID", new SqlParameter[] {
                new SqlParameter("canal_nume",Nume)
                });

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static DataTable Show_Curstom_Articles(int channelID)
        {
            DataTable dt = ExecuteStoredProcedure("Selectare_Articole_cu_canal", new SqlParameter[] {
                new SqlParameter("mycanal",channelID)
                });
            return dt;
        }

        public static int giveTipUtilizatorgetID(string tip_utilizator_name)
        {
            DataTable dt = ExecuteStoredProcedure("giveTipUtilizatorgetID", new SqlParameter[] {
                new SqlParameter("tip_utilizator_name",tip_utilizator_name)
                });
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static string giveIDgetTipUtilizator(int ID)
        {
            DataTable dt = ExecuteStoredProcedure("giveIDgetTipUtilizator", new SqlParameter[] {
                new SqlParameter("tip_utilizator_ID",ID)
                });
            return dt.Rows[0][0].ToString();
        }

        public static int insertArticle(string title, string content, string author, int authorId)
        {
            //System.Diagnostics.Debug.WriteLine(((User)Session["user"]).Email);

            DateTime publishDate = System.DateTime.Now;

            DataTable dt = ExecuteStoredProcedure("insertArticle", new SqlParameter[] {
                new SqlParameter("title",title),
                new SqlParameter("content",content),
                new SqlParameter("author",author),
                new SqlParameter("publishDate",publishDate),
                new SqlParameter("authorId",authorId)
            });

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static void deleteAllChannelsFromArticle(int articleId)
        {
            DataTable dt = ExecuteStoredProcedure("deleteAllChannelsFromArticle", new SqlParameter[] {
                new SqlParameter("articleId",articleId)
            });
        }

        public static void addChannelToArticle(int channelId, int articleId)
        {
            DataTable dt = ExecuteStoredProcedure("addChannelToArticle", new SqlParameter[] {
                new SqlParameter("channelId",channelId),
                new SqlParameter("articleId",articleId)
            });
        }

        public static int giveEmailgetID (string email)
        {
            DataTable dt = ExecuteStoredProcedure("giveEmailgetID", new SqlParameter[] {
                new SqlParameter("email",email)
            });

            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public static bool channelBelongtoUser(int channelId, int userId)
        {
            DataTable dt = ExecuteStoredProcedure("channelBelongtoUser", new SqlParameter[] {
                new SqlParameter("channelId",channelId),
                new SqlParameter("userId",userId)
            });

            if (dt.Rows.Count != 0)
                return true;
            return false;
        }

        public static void deleteAllChannelsFromUser(int userId)
        {
            DataTable dt = ExecuteStoredProcedure("deleteAllChannelsFromUser", new SqlParameter[] {
                new SqlParameter("userId",userId)
            });
        }

        public static string GetHasedPasswdForUser(string user)
        {
            DataTable dt = ExecuteStoredProcedure("GetHasedPasswdForUser", new SqlParameter[] {
                new SqlParameter("user", user)
            });



            if (dt.Rows.Count != 0)
                return dt.Rows[0][0].ToString();
            else return null;

        }

        public static DataTable GetAllDataForUser(string user)
        {
            DataTable dt = ExecuteStoredProcedure("GetAllDataForUser", new SqlParameter[] {
                new SqlParameter("user", user)
            });
            return dt;

        }

    }
}