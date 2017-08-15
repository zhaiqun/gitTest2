using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zhaiqunHeimaTest.Bll;
using zhaiqunHeimaTest.Model;
namespace zhaiqunHeimaTest.UI
{
    /// <summary>
    /// ProcessDelete 的摘要说明
    /// </summary>
    public class ProcessDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BasicInfoBll bll = new BasicInfoBll();
            int id = int.Parse(context.Request["personId"]);
            if (bll.Delete(id))
            {
                context.Response.Redirect("List.aspx");
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