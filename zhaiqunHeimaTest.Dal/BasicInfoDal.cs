using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhaiqunHeimaTest.Model;
using System.Data;
using System.Data.SqlClient;
namespace zhaiqunHeimaTest.Dal
{
   public class BasicInfoDal
    {

       public int Update(BasicInfoModel model)
       {
           string sql = "update BasicInfo set Name=@name,Gender=@gender,Age=@age,Email=@email  where PersonID=@id";
           SqlParameter[] p = new SqlParameter[]{
            new SqlParameter("@name",SqlDbType.NVarChar,100){Value=model.Name},
            new SqlParameter("@gender",SqlDbType.NChar,1){Value=model.Gender},
            new SqlParameter("@age",SqlDbType.Int){Value=model.Age},
            new SqlParameter("@email",SqlDbType.NVarChar,50){Value=model.Email},
          new SqlParameter("@id",SqlDbType.Int){Value=model.PersonID}
            };
           return SqlHelper.ExecuteNoneQuery(sql,CommandType.Text,p);
       }

       public BasicInfoModel SelectModelById(int id)
       {
           BasicInfoModel model = new BasicInfoModel();
           string sql = "select * from BasicInfo where PersonID=@id";
           SqlParameter p = new SqlParameter("@id", SqlDbType.Int) { Value = id };
           using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, p))
           {
               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       //PersonID, Name, Gender, Age, Email
                       model = new BasicInfoModel();
                       model.PersonID = reader.GetInt32(0);
                       model.Name = reader.GetString(1);
                       model.Gender = reader.GetString(2);
                       model.Age = reader.GetInt32(3);
                       model.Email = reader.GetString(4);

                   }
               }
           }
           return model;
       }

       public int Delete(int id)
       {
           string sql = "delete from BasicInfo where PersonID=@id ";
           SqlParameter p = new SqlParameter("@id", SqlDbType.Int) { Value=id};
           return SqlHelper.ExecuteNoneQuery(sql, CommandType.Text, p);
       }
        public int Insert(BasicInfoModel model)
        {
            string sql = "insert into BasicInfo values(@name,@gender,@age,@email)";
            SqlParameter[] p = new SqlParameter[]{
            new SqlParameter("@name",SqlDbType.NVarChar,100){Value=model.Name},
            new SqlParameter("@gender",SqlDbType.NChar,1){Value=model.Gender},
            new SqlParameter("@age",SqlDbType.Int){Value=model.Age},
            new SqlParameter("@email",SqlDbType.NVarChar,50){Value=model.Email}
            };
            return SqlHelper.ExecuteNoneQuery(sql,CommandType.Text,p);
        }


        public List<BasicInfoModel> SelectByRow(int pagesize, int pageindex,out int pagecount,out int recordcount )
        { 
                    // @pagesize int,
                    //@pageindex int,
                    //@pagecount int output,
                    //@recordcount int output
            List<BasicInfoModel> ls = new List<BasicInfoModel>();
            string sql = "usp_basicInfoByRow";
            SqlParameter[] p = new SqlParameter[]{
            new SqlParameter("@pagesize",SqlDbType.Int){Value=pagesize},
            new SqlParameter("@pageindex",SqlDbType.Int){Value=pageindex},
             new SqlParameter("@pagecount",SqlDbType.Int){Direction=ParameterDirection.Output},
             new SqlParameter("@recordcount",SqlDbType.Int){Direction=ParameterDirection.Output},
            };
            using (SqlDataReader  reader=SqlHelper.ExecuteReader(sql,CommandType.StoredProcedure,p))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //PersonID, Name, Gender, Age, Email
                        BasicInfoModel model = new BasicInfoModel();
                        model.PersonID = reader.GetInt32(0);
                        model.Name = reader.GetString(1);
                        model.Gender = reader.GetString(2);
                        model.Age = reader.GetInt32(3);
                        model.Email = reader.GetString(4);
                        ls.Add(model);
                    }
                }
            }
            pagecount = (int)p[2].Value;
            recordcount = (int)p[3].Value;
            return ls;
        }
    }
}
