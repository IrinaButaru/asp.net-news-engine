using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;


public class DbConnection
{
    private static object m_lock = new object();
    private object m_connectionLock = new object();
    private static DbConnection m_instance;
    private SqlConnection m_connection;
    //design Pattern Singletone
    public static DbConnection Instance
    {
        get
        {
            if (m_instance == null)
            {
                //thread safe
                lock (m_lock)
                {
                    if (m_instance == null)
                    {
                        m_instance = new DbConnection();
                    }
                }
            }
            return m_instance;
        }
    }

    private DbConnection()
    {
        m_connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    }

    public void ExecuteNonQueryProcedure(string i_procedureName, params KeyValuePair<string, object>[] i_parameters)
    {
        if (m_connection == null)
            throw new Exception("Invalid connection!");
        lock (m_connectionLock)
        {
            try
            {
                m_connection.Open();
                SqlCommand sqlCmd = new SqlCommand(string.Format("dbo.{0}", i_procedureName), m_connection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (var param in i_parameters)
                {
                    sqlCmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }
                sqlCmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                m_connection.Close();
            }
        }
    }

    public string ExecuteScalarProcedure(string i_procedureName, params KeyValuePair<string, object>[] i_parameters)
    {
        if (m_connection == null)
            throw new Exception("Invalid connection!");
        lock (m_connectionLock)
        {
            string result = string.Empty;
            try
            {
                m_connection.Open();
                SqlCommand sqlCmd = new SqlCommand(string.Format("dbo.{0}", i_procedureName), m_connection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (var param in i_parameters)
                {
                    sqlCmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }
                object obj = sqlCmd.ExecuteScalar();
                if (obj is int)
                {
                    result = ((int)obj).ToString();
                }
                if (obj is string)
                {
                    result = obj as string;
                }
            }
            catch
            { }
            finally
            {
                m_connection.Close();
            }
            return result;
        }
    }
    public SqlDataReader ExecuteProcedure(string i_procedureName, params KeyValuePair<string, object>[] i_parameters)
    {
        if (m_connection == null)
            throw new Exception("Invalid connection!");
        lock (m_connectionLock)
        {
            SqlDataReader result = null;
            try
            {
                m_connection.Close();
                m_connection.Open();
                SqlCommand sqlCmd = new SqlCommand(string.Format("dbo.{0}", i_procedureName), m_connection);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (var param in i_parameters)
                {
                    sqlCmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }
                result = sqlCmd.ExecuteReader();

            }
            catch
            { }
            return result;
        }
    }
    public void CloseConnection()
    {
        m_connection.Close();
    }
}