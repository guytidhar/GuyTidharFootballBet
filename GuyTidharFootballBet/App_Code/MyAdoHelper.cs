using System; using System.Configuration; using System.Data; using System.Data.SqlClient;
public class MyAdoHelper {
 private static string ConnectionString(){return ConfigurationManager.ConnectionStrings["FootballBetConnectionString"].ConnectionString;}
 public static DataTable ExecuteDataTable(string sql){DataTable t=new DataTable(); using(SqlConnection c=new SqlConnection(ConnectionString())) using(SqlDataAdapter a=new SqlDataAdapter(sql,c)){a.Fill(t);} return t;}
 public static bool IsExist(string sql){return ExecuteDataTable(sql).Rows.Count>0;}
 public static void DoQuery(string sql){using(SqlConnection c=new SqlConnection(ConnectionString())) using(SqlCommand cmd=new SqlCommand(sql,c)){c.Open();cmd.ExecuteNonQuery();}}
 public static void DoQuery(string dbName,string sql){DoQuery(sql);}
 public static string FixText(string value){if(value==null)return "";return value.Trim().Replace("'","''");}
}