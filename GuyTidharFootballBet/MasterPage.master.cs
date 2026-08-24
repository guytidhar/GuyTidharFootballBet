using System;
public partial class MasterPage : System.Web.UI.MasterPage
{
    public string DynamicMenu = "";
    public string TopUserText = "שלום אורח";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            DynamicMenu = "<a href='Login.aspx'>כניסה</a><a href='Register.aspx'>הרשמה</a>";
        }
        else
        {
            TopUserText = "שלום " + Session["nickName"] + " | מטבעות: " + Session["coins"];
            DynamicMenu = "<a href='Games.aspx'>משחקים</a><a href='AddBet.aspx'>ביצוע הימור</a><a href='MyBets.aspx'>ההימורים שלי</a>";
            if (Session["userType"] != null && Session["userType"].ToString() == "Admin")
                DynamicMenu += "<a href='AdminUsers.aspx'>ניהול משתמשים</a>";
            DynamicMenu += "<a href='Logout.aspx'>יציאה</a>";
        }
    }
}