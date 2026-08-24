using System; using System.Data;
public partial class Login : System.Web.UI.Page
{
 public string st="";
 protected void Page_Load(object sender, EventArgs e)
 {
  if (Page.IsPostBack)
  {
   string userName=MyAdoHelper.FixText(Request.Form["userName"]);
   string password=MyAdoHelper.FixText(Request.Form["password"]);
   if(userName=="" || password=="") { st="יש למלא שם משתמש וסיסמה"; return; }
   string sql="SELECT * FROM Users WHERE UserName=N'"+userName+"' AND Password=N'"+password+"'";
   DataTable dt=MyAdoHelper.ExecuteDataTable(sql);
   if(dt.Rows.Count==0) st="שם המשתמש או הסיסמה אינם נכונים";
   else
   {
    Session["user"]="ok"; Session["userId"]=dt.Rows[0]["UserId"].ToString(); Session["userName"]=dt.Rows[0]["UserName"].ToString();
    Session["nickName"]=dt.Rows[0]["NickName"].ToString(); Session["userType"]=dt.Rows[0]["UserType"].ToString(); Session["coins"]=dt.Rows[0]["Coins"].ToString();
    Response.Redirect("Home.aspx");
   }
  }
 }
}