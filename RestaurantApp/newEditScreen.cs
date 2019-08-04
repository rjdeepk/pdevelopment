using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace RestaurantApp
{
    [Activity(Label = "newEditScreen")]
    public class NewEditScreen : Activity
    {
        String u;
        String p;

        EditText user;
        EditText pass;
        EditText email;
        EditText age;
        DBHelper ob;
        ICursor ic;
        Button editb;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Create your application here
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.newscreen);
            user = FindViewById<EditText>(Resource.Id.userRegister);
            pass = FindViewById<EditText>(Resource.Id.userPassword);
            email = FindViewById<EditText>(Resource.Id.userEmail);
            age = FindViewById<EditText>(Resource.Id.userAge);
            editb = FindViewById<Button>(Resource.Id.submitBtn);
            ob = new DBHelper(this);
            u = Intent.GetStringExtra("userName");
            p = Intent.GetStringExtra("userPassword");




            user.Text = u;
            pass.Text = p;


            user.Enabled = false;
            pass.Enabled = false;
            email.Enabled = false;
            age.Enabled = false;
            ic = ob.Update(user.Text, pass.Text);
            email.Text = ic.GetString(ic.GetColumnIndex("email"));
            age.Text = ic.GetString(ic.GetColumnIndex("age"));

            editb.Click += delegate
            {
                user.Enabled = true;
                pass.Enabled = true;
                email.Enabled = true;
                age.Enabled = true;
                editb.Text = "Save";
                editb.Click += delegate
                {
                    ob.updateMyValues(user.Text, pass.Text, email.Text, age.Text);
                    Intent newSc = new Intent(this, typeof(MainActivity));
                    StartActivity(newSc);
                };


            };
        }
    }
}