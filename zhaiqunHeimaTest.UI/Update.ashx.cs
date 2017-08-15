using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zhaiqunHeimaTest.Bll;
using zhaiqunHeimaTest.Model;
namespace zhaiqunHeimaTest.UI
{
    /// <summary>
    /// Update 的摘要说明
    /// </summary>
    public class Update : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BasicInfoModel model = new BasicInfoModel();
            model.Name = context.Request["txtName"];
            model.Age=int.Parse( context.Request["txtAge"]);
            model.Gender = context.Request["gender"];
            model.Email = context.Request["txtEmail"];
            model.PersonID = int.Parse(context.Request["hidId"]);
            BasicInfoBll bll = new BasicInfoBll();
            if (bll.Update(model))
            {
                context.Response.Redirect("ok");
            }
            else
            {
                context.Response.Write("notok");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}