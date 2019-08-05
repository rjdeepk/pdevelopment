using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RestaurantApp
{
    [Activity(Label = "Review")]
    public class Review : Activity
    {
        String user1;
        EditText RestaurantName;
        EditText reviews;
        TextView user;
        Button reviewBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Review1);
            user = FindViewById<TextView>(Resource.Id.logo);
            RestaurantName = FindViewById<EditText>(Resource.Id.resName);
            reviews = FindViewById<EditText>(Resource.Id.comment);
            reviewBtn = FindViewById<Button>(Resource.Id.rbtn);
            DBHelper obj = new DBHelper(this);
            user1 = Intent.GetStringExtra("userName");
            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);



            reviewBtn.Click += delegate
            {
                user.Text = user1;
                var value1 = RestaurantName.Text;
                var value2 = reviews.Text;
                if (value1.Equals(" ") || value1.Equals("") || value2.Equals(" ") || value2.Equals(""))
                {
                    alert.SetTitle("Error");
                    alert.SetMessage(" Please Enter A Value....");

                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(this, "Please Enter a Valid! Value", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();


                    dialog.Show();




                }
                else
                {
                    obj.InsertValue1(user1, value1, value2);

                    alert.SetMessage(" Review Added successfull");
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(this, "well done ", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();

                    dialog.Show();
                    Intent back = new Intent(this, typeof(MainActivity));
                    StartActivity(back);

                };

                // Create your application here

            };
} } }