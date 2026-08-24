# FootballBetProject - גרסה 1

פרויקט ASP.NET Web Forms לימודי בעברית. האתר משתמש במטבעות וירטואליים בלבד.

## פתיחה ב-Visual Studio 2022
1. התקינו workload בשם **ASP.NET and web development**.
2. פתחו Visual Studio ובחרו `File > Open > Web Site`.
3. בחרו את תיקיית `FootballBetProject`.
4. בתיקיית `App_Data` צרו `SQL Server Database` בשם `FootballBetDB.mdf`.
5. פתחו את מסד הנתונים דרך `Server Explorer`.
6. לחצו `New Query`, העתיקו את `Database/CreateDatabase.sql` והריצו.
7. הגדירו את `Default.aspx` כדף התחלה והריצו עם IIS Express.

## כניסות לבדיקה
- מנהל: `admin` / `admin123`
- משתמש: `david` / `1234`

## חשוב
קובץ MDF הוא קובץ בינארי של SQL Server LocalDB. יש ליצור אותו ב-Windows/Visual Studio לפי שלבים 4-6. כל המבנה והנתונים נמצאים בסקריפט SQL המצורף.

## מבנה עיקרי
- `App_Code/MyAdoHelper.cs`: עבודה מול MDF
- `MasterPage.master`: מבנה אחיד ותפריט דינמי
- `Register.aspx`: הרשמה ו-JavaScript
- `Login.aspx`: כניסה, DataTable ו-Session
- `Games.aspx`: שליפת משחקים
- `AddBet.aspx`: הוספת הימור ובדיקות תקינות
- `MyBets.aspx`: הימורי המשתמש
- `AdminUsers.aspx`: מנהל בלבד
- `Database/CreateDatabase.sql`: ארבע טבלאות ונתוני התחלה

## הערת לימוד
השאילתות נבנו בשרשור מחרוזות כדי להישאר קרובות לדוגמאות הכיתה. `FixText` מחליף גרש בגרש כפול. בפרויקט מקצועי משתמשים בפרמטרים, אך שינוי כזה יבוצע רק אם המורה מאשר שנלמד.
