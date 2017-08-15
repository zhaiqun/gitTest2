using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using zhaiqunHeimaTest.Bll;
using zhaiqunHeimaTest.Model;
using zhaiqunHeimaTest.Utility;
namespace zhaiqunHeimaTest.UI
{
    public partial class List : System.Web.UI.Page
    {
        protected string nav;
        BasicInfoBll bll = new BasicInfoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            int pageindex = Context.Request["pageindex"] == null ? 1 : Convert.ToInt32(Context.Request["pageindex"]);
            int pagesize =5;
            int recordcount;
            int pagecount;
            List<BasicInfoModel> ls = bll.SelectByRow(pagesize, pageindex, out pagecount, out recordcount);
            this.Repeater1.DataSource = ls;
            this.DataBind();
            this.nav = PagerHelper.strPage(recordcount, pagesize, pagecount, pageindex, "List.aspx?pageindex=");
        }
    }
}