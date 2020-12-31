using System.Data.SqlClient;

namespace BookMS
{
    class Dao
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string src = @"Data Source =LAPTOP-57K31JSB\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True";//数据库连接字符串
            sc = new SqlConnection(src);
            sc.Open();
            return sc;//返回数据库连接对象
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;//返回数据库操作对象
        }
        public int Execute(string sql)//更新
        {
            return command(sql).ExecuteNonQuery();
        }
        public SqlDataReader read(string sql)//读取
        {
            return command(sql).ExecuteReader();
        }
        public void DaoClose()
        {
            sc.Close();//关闭数据库连接
        }
    }
}
