using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zhaiqunHeimaTest.Model;
using zhaiqunHeimaTest.Bll;
namespace zhaiqunHeimaTest.UI
{
    /// <summary>
    /// ProcessInsert 的摘要说明
    /// </summary>
    public class ProcessInsert : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BasicInfoBll bll = new BasicInfoBll();
            BasicInfoModel model = new BasicInfoModel();
            model.Name = context.Request["name"];
            model.Gender = context.Request["gender"];
            model.Age= int.Parse(context.Request["age"]);
            model.Email = context.Request["email"];
            if (bll.Insert(model))
            {
                context.Response.Write("ok");
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