using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zhaiqunHeimaTest.Dal;
using zhaiqunHeimaTest.Model;
namespace zhaiqunHeimaTest.Bll
{
   public  class BasicInfoBll
    {
       BasicInfoDal dal = new BasicInfoDal();
       public bool Insert(BasicInfoModel model)
       {
           return dal.Insert(model)>0;
       }

       public List<BasicInfoModel> SelectByRow(int pagesize, int pageindex, out int pagecount, out int recordcount)
       {
           return dal.SelectByRow(pagesize,pageindex,  out pagecount, out recordcount);
       }

       public bool Delete(int id)
       {
           return dal.Delete(id) > 0;
       }
       public BasicInfoModel SelectModelById(int id)
       {
           return dal.SelectModelById(id);
       }
       public bool Update(BasicInfoModel model)
       {
           return dal.Update(model)>0;
       }
   
   }


}
