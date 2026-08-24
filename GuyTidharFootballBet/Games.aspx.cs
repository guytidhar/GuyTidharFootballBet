using System; using System.Data; using System.Text;
public partial class Games : System.Web.UI.Page
{
 public string gamesHtml="";
 protected void Page_Load(object sender, EventArgs e)
 {
  if(Session["user"]==null){Response.Redirect("Login.aspx");return;}
  string sql="SELECT Games.GameId,Games.GameDate,Games.League,Games.GameResult,A.ClubName AS ClubA,B.ClubName AS ClubB FROM Games INNER JOIN Clubs A ON Games.ClubAId=A.ClubId INNER JOIN Clubs B ON Games.ClubBId=B.ClubId ORDER BY Games.GameDate";
  DataTable dt=MyAdoHelper.ExecuteDataTable(sql); StringBuilder s=new StringBuilder();
  for(int i=0;i<dt.Rows.Count;i++){string league=dt.Rows[i]["League"].ToString(); string img=league=="England"?"Images/england.svg":"Images/spain.svg"; string result=dt.Rows[i]["GameResult"].ToString(); if(result=="-1") result="טרם התקיים"; s.Append("<div class='card'><img src='"+img+"' alt='ליגה'/><h2>"+dt.Rows[i]["ClubA"]+" נגד "+dt.Rows[i]["ClubB"]+"</h2><p>ליגה: "+league+"</p><p>תאריך: "+Convert.ToDateTime(dt.Rows[i]["GameDate"]).ToString("dd/MM/yyyy HH:mm")+"</p><p>תוצאה: "+result+"</p><p>משחק בין שתי קבוצות מהליגה "+league+".</p></div>");}
  gamesHtml=s.ToString();
 }
}