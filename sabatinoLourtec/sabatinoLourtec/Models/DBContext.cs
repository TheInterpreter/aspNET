using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace sabatinoLourtec.Models
{
    public class DBContext
    {
        SqlConnection cn;
        DataSet ds;
        public DBContext(string ConnectionString)
        {
            cn = new SqlConnection(ConnectionString);
        }
        public List<Dictionary<string, object>> GetList(string Query)
        {
            try
            {
                ds = new DataSet();
                cn.Open();
                SqlCommand cm = new SqlCommand(Query, cn);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(ds);
                cn.Close();
                DataTable table = ds.Tables[0];
                List<Dictionary<string, object>> Result = table.AsEnumerable().Select(dr =>
                {
                    var dic = new Dictionary<string, object>();
                    dr.ItemArray.Aggregate(-1, (int i, object v) =>
                    {
                        i += 1; dic.Add(table.Columns[i].ColumnName, v);
                        return i;
                    });
                    return dic;
                }).ToList();
                return Result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

    }
}

