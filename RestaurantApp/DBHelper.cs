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



        SQLiteDatabase myDBObj; // Step: 1 - 5
        Context myContext; // Step: 1 - 6


        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase; // Step:3 create a DB objects
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(CreateUserTableQuery);
        }
        public void insertValue(string nameValue, string emailValue, string passwordValue, string ageValue)
        {
            //insert into users value( name, email,password,age)


            String insertSQL = "insert into " + TableName + " values (" + "'" + nameValue + "'" + "," + "'" + emailValue + "'" + "," + "'" + passwordValue + "'" + "," + "'" + ageValue + "'" + ");";

            System.Console.WriteLine("Name: " + nameValue + "\nEmail :" + emailValue + "\nPassword:" + passwordValue + "\nAge:" + ageValue);
            myDBObj.ExecSQL(insertSQL);

        }
        public bool selectMyValues(String userName, String passWord)
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

        public void updateMyValues(String un, String pw, String email, String age)
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