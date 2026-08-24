using System;
public partial class Register : System.Web.UI.Page
{
 public string st="";
 protected void Page_Load(object sender, EventArgs e)
 {
  if(Page.IsPostBack)
  {
   string first=MyAdoHelper.FixText(Request.Form["firstName"]), last=MyAdoHelper.FixText(Request.Form["lastName"]), user=MyAdoHelper.FixText(Request.Form["userName"]), pass=MyAdoHelper.FixText(Request.Form["password"]), nick=MyAdoHelper.FixText(Request.Form["nickName"]);
   if(first.Length<2 || last.Length<2 || user.Length<4 || pass.Length<4 || nick.Length<2){st="הנתונים לא תקינים";return;}
   string check="SELECT * FROM Users WHERE UserName=N'"+user+"'";
   if(MyAdoHelper.IsExist(check)){st="שם המשתמש כבר קיים במערכת";return;}
   string sql="INSERT INTO Users (FirstName,LastName,UserName,Password,NickName,UserType,Coins) VALUES (N'"+first+"',N'"+last+"',N'"+user+"',N'"+pass+"',N'"+nick+"',N'User',1000)";
   MyAdoHelper.DoQuery(sql); Response.Redirect("Login.aspx");
  }
 }
}