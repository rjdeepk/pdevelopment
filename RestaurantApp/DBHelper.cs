using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RestaurantApp
{
    public class DBHelper : SQLiteOpenHelper
    {
        private static string _DatabaseName = "mydatabase.db";
        private const string TableName = "user";
        private const string ColumnName = "username";
        private const string ColumnEmail = "email";
        private const string ColumnPassword = "password";
        private const string ColumnAge = "age";

        public const string CreateUserTableQuery = "CREATE TABLE " +
       TableName + " ( " + ColumnName + " TEXT," + ColumnEmail + " TEXT," + ColumnPassword + " TEXT,"
           + ColumnAge + " TEXT)";  //Step: 1 - 4


        //Review Table
        private const string RTableName = "Review";
        private const string UserName = "username";
        private const string Restname = "restname";
        private const string Review1 = "review";


        public const string CreateUserTableQuery1 = "CREATE TABLE " +
       RTableName + " ( " + UserName + " TEXT," + Restname + " TEXT,"   + Review1 + " TEXT)";
       

        SQLiteDatabase myDBObj; // Step: 1 - 5
        readonly Context myContext; // Step: 1 - 6


        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase;
            myDBObj = ReadableDatabase;// Step:3 create a DB objects
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            Console.WriteLine("Table1");
            db.ExecSQL(CreateUserTableQuery);
            Console.WriteLine("Table2");
            db.ExecSQL(CreateUserTableQuery1);
        }
        //insert values user/password table
        public void InsertValue(string nameValue, string emailValue, string passwordValue, string ageValue)
        {
            //insert into users value( name, email,password,age)


            String insertSQL = "insert into " + TableName + " values (" + "'" + nameValue + "'" + "," + "'" + emailValue + "'" + "," + "'" + passwordValue + "'" + "," + "'" + ageValue + "'" + ");";

            System.Console.WriteLine("Name: " + nameValue + "\nEmail :" + emailValue + "\nPassword:" + passwordValue + "\nAge:" + ageValue);
            myDBObj.ExecSQL(insertSQL);

        }
        //insert values review table

        public void InsertValue1(string username, string restname, string review)
        {
            //insert into users value( name, email,password,age)


            String insertSQL1 = "insert into " + RTableName + " values (" + "'" + UserName + "'" + "," + "'" + Restname + "'" + "," + "'" + Review1 + "'" + ");";

            System.Console.WriteLine("UserName: " + username + "\nRestaurantName :" + restname + "\nReview" + review);
            myDBObj.ExecSQL(insertSQL1);

        }
        //for user login table
        public bool SelectMyValues(String userName, String passWord)
        {

            String sqlQuery = "Select * from " + TableName + " where " + ColumnName + " = " + "'" + userName + "'" + " and " + ColumnPassword + " = " + "'" + passWord + "'" + ";";

            ICursor result = myDBObj.RawQuery(sqlQuery, null);
            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            //for review table
            public bool SelectMyValues1(String username)
            {

                String sqlQuery1 = "Select * from " + RTableName + " where " + UserName + " = " + "'" + username + ";";

                ICursor result1 = myDBObj.RawQuery(sqlQuery1, null);
                if (result1.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }



            }
        //Delete reviews
        public void Deletereview(string user,string rname)
        {
            string dltStm = "Delete from " + RTableName + " where " + UserName + "=" + user + "and" + Restname + "="+ rname + ";";
            Console.WriteLine(dltStm);
            System.Console.WriteLine("My SQL  delete STM \n  \n" + dltStm);
            myDBObj.ExecSQL(dltStm);
        }
        //show reviews
        public List<string> GetReviews()
        {

            List<string> resultr = new List<string>();
            string Query = "select " + UserName + "," + Restname + "," + Review1 + " from " + RTableName + ";";
            System.Console.WriteLine("My SQL  select STM \n  \n" + Query);

            try
            {
                ICursor cursor = myDBObj.RawQuery(Query, new string[] { });

                while (cursor.MoveToNext())
                {
                    var uname = cursor.GetString(cursor.GetColumnIndexOrThrow(UserName));
                    var r = cursor.GetString(cursor.GetColumnIndexOrThrow(Restname));
                    var rr = cursor.GetString(cursor.GetColumnIndexOrThrow(Review1));
                    resultr.Add(uname);
                    resultr.Add(r);
                    resultr.Add(rr);

                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
            }
            return resultr;

        }


        public ICursor Viewdata()
        {
            SQLiteDatabase db = this.GetReadableDatabase();
            String sqlQuery = "Select * from " + RTableName + ";";
            ICursor resultr = myDBObj.RawQuery(sqlQuery, null);

            return resultr;
        }

        private SQLiteDatabase GetReadableDatabase()
        {
            throw new NotImplementedException();
        }

        public ICursor Update(string userName, string passWord)
        {
            String sqlQuery = "Select * from " + TableName + " where " + ColumnName + " = " + "'" + userName + "'" + " and " + ColumnPassword + " = " + "'" + passWord + "'" + ";";
            ICursor result = myDBObj.RawQuery(sqlQuery, null);
            result.MoveToNext();


            var userDB = result.GetString(result.GetColumnIndexOrThrow(ColumnName));
            var emailDB = result.GetString(result.GetColumnIndexOrThrow(ColumnEmail));
            var passDB = result.GetString(result.GetColumnIndexOrThrow(ColumnPassword));
            var ageDB = result.GetString(result.GetColumnIndexOrThrow(ColumnAge));

            return result;


        }

        public void UpdateMyValues(String un, String pw, String email, String age)
        {
            String sqlupQuery = "Update " + TableName + " Set " + ColumnName + "='" + un + "', " + ColumnPassword + "=" + "'" + pw + "', " + ColumnEmail + "='" + email + "', " + ColumnAge + "=' " + age + "';";
            System.Console.WriteLine("Update SQL " + sqlupQuery);
            myDBObj.ExecSQL(sqlupQuery);
        }


        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }
}