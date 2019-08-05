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

    public class Review : Fragment
    {
        public String user1;
        EditText RestaurantName;
        EditText reviews;
        TextView user;
        Button reviewBtn;
        Button reviewshowBtn;
        readonly Activity localContext;
        public Review(Activity myContext)
        {
            localContext = myContext;

        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View myView = inflater.Inflate(Resource.Layout.Review1, container, false);
            user = myView.FindViewById<TextView>(Resource.Id.logo);
            RestaurantName = myView.FindViewById<EditText>(Resource.Id.resName);
            reviews = myView.FindViewById<EditText>(Resource.Id.comment);
            reviewBtn = myView.FindViewById<Button>(Resource.Id.rbtn);
            reviewshowBtn = myView.FindViewById<Button>(Resource.Id.r1btn);

            Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(localContext);

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

                        Toast.MakeText(localContext, "Please Enter a Valid! Value", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
                else
                {
                    DBHelper obj = new DBHelper(localContext);
                    obj.InsertValue1(user1, value1, value2);

                    alert.SetMessage(" Review Added successfull");
                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(localContext, "Thanks ", ToastLength.Short).Show();

                        Dialog dialog = alert.Create();

                        dialog.Show();
                        Intent back = new Intent(localContext, typeof(UserTab));
                        StartActivity(back);

                    });
                }
            
            };
            reviewshowBtn.Click += delegate
            {
                Intent newScreen = new Intent(localContext, typeof(Showreview));
                StartActivity(newScreen);
                user.Text = user1;
                var r = RestaurantName.Text;
                var rv = reviews.Text;
                if (r.Equals(" ") || r.Equals("") || rv.Equals(" ") || rv.Equals(""))
                {
                    alert.SetTitle("Error");
                    alert.SetMessage(" Please Enter A Value....");

                    alert.SetPositiveButton("OK", (senderAlert, args) =>
                    {

                        Toast.MakeText(localContext, "Please Enter a Valid! Value", ToastLength.Short).Show();
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();

                }
            }; 

            // Create your application here
            return myView;
        }
    }
}


