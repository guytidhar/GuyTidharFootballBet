using System; using System.Data; using System.Text;
public partial class AddBet : System.Web.UI.Page
{
 public string gameOptions="",st="";
 protected void Page_Load(object sender, EventArgs e)
 {
  if(Session["user"]==null){Response.Redirect("Login.aspx");return;}
  LoadGames();
  if(Page.IsPostBack) SaveBet();
 }
 private void LoadGames(){string sql="SELECT Games.GameId,Games.GameDate,A.ClubName AS ClubA,B.ClubName AS ClubB FROM Games INNER JOIN Clubs A ON Games.ClubAId=A.ClubId INNER JOIN Clubs B ON Games.ClubBId=B.ClubId WHERE Games.GameResult=N'-1' ORDER BY Games.GameDate";DataTable dt=MyAdoHelper.ExecuteDataTable(sql);StringBuilder s=new StringBuilder();for(int i=0;i<dt.Rows.Count;i++)s.Append("<option value='"+dt.Rows[i]["GameId"]+"'>"+dt.Rows[i]["ClubA"]+" נגד "+dt.Rows[i]["ClubB"]+" | "+Convert.ToDateTime(dt.Rows[i]["GameDate"]).ToString("dd/MM/yyyy HH:mm")+"</option>");gameOptions=s.ToString();}
 private void SaveBet(){int gameId,betCoins;if(!int.TryParse(Request.Form["gameId"],out gameId)||!int.TryParse(Request.Form["betCoins"],out betCoins)||betCoins<=0){st="נתוני ההימור אינם תקינים";return;}string sqlGame="SELECT * FROM Games WHERE GameId="+gameId;DataTable game=MyAdoHelper.ExecuteDataTable(sqlGame);if(game.Rows.Count==0){st="המשחק לא נמצא";return;}DateTime gameDate=Convert.ToDateTime(game.Rows[0]["GameDate"]);if(gameDate<=DateTime.Now || game.Rows[0]["GameResult"].ToString()!="-1"){st="לא ניתן להמר. המשחק כבר התחיל או הסתיים";return;}int userId=Convert.ToInt32(Session["userId"]);DataTable user=MyAdoHelper.ExecuteDataTable("SELECT Coins FROM Users WHERE UserId="+userId);int coins=Convert.ToInt32(user.Rows[0]["Coins"]);if(betCoins>coins){st="אין מספיק מטבעות לביצוע ההימור";return;}string side=Request.Form["side"]=="B"?"B":"A";int clubId=Convert.ToInt32(game.Rows[0][side=="A"?"ClubAId":"ClubBId"]);string insert="INSERT INTO Bets (UserId,GameId,BetDate,BetCoins,BetClubId,BetResult) VALUES ("+userId+","+gameId+",GETDATE(),"+betCoins+","+clubId+",-1)";MyAdoHelper.DoQuery(insert);MyAdoHelper.DoQuery("UPDATE Users SET Coins=Coins-"+betCoins+" WHERE UserId="+userId);Session["coins"]=(coins-betCoins).ToString();st="ההימור נשמר בהצלחה";}
}