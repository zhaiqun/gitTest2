using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zhaiqunHeimaTest.Bll;
using zhaiqunHeimaTest.Model;
using System.Web.Script.Serialization;
namespace zhaiqunHeimaTest.UI
{
    /// <summary>
    /// SelectModelById 的摘要说明
    /// </summary>
    public class SelectModelById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BasicInfoBll bll = new BasicInfoBll();
            int id = int.Parse(context.Request["personId"]);
            BasicInfoModel model = bll.SelectModelById(id);
            JavaScriptSerializer jss = new JavaScriptSerializer();
           
            if (model!=null)
            {
                string jsonData = jss.Serialize(model);
                context.Response.Write(jsonData);
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