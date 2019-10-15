using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;

namespace ADO.NET
{
    
    class Program
    {

        private DbConnection GetDatabaseConnection (string name)
        {
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];
            DbProviderFactory factory = DbProviderFactories.GetFactory
                (settings.ProviderName);
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = settings.ConnectionString;
            return conn;
        }
        static void ExecuteNonQuery()
        {
            string select = "UPDATE DimArea " +
                         "SET AreaName='海珠区'" +
                         "WHERE ProvinceName='广东省'";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            int rowsReturned = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} rows returned.", rowsReturned);
            conn.Close();
        }
        static void ExecuteReader()
        {
            string select = "SELECT AreaID,AreaName FROM DimArea";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("AreaID:{0,-20} AreaName:{1}", 
                    reader[0], reader[1]);
            }
        }
        static void ExecuteScalar()
        {
            string select = "SELECT COUNT(*) FROM DimArea";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            object o = cmd.ExecuteScalar();
            Console.WriteLine(o);
        }
        static void ExecuteXmlReader()
        {
            string select = "SELECT AreaID,AreaName " +
                "FROM DimArea FOR XML AUTO";
            SqlConnection conn = new SqlConnection(GetDatabaseConnection());
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            XmlReader xr = cmd.ExecuteXmlReader();
            xr.Read();
            string data;
            do
            {
                data = xr.ReadOuterXml();
                if (!string.IsNullOrEmpty(data))
                    Console.WriteLine(data);
            } while (!string.IsNullOrEmpty(data));
            conn.Close();
        }
        static void Main(string[] args)
        {
            string source = "server=(local);" +
                "integrated security=SSPI;" +
                "database=BIDWemo";
            string select = "SELECT AreaName from DimArea";
            
            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            Console.Read();
            conn.Close();
            
        }
    }
}
