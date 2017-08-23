using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

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
                new SqlParameter("tip_utilizator",user_type) });

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

    }
}