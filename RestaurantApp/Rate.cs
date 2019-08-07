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
    [Activity(Label = "Rate")]
    public class Rate : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Rate);
            // Create your application here
            var ratingBar = FindViewById<RatingBar>(Resource.Id.star);
            ratingBar.NumStars = 5;
            var subBtn = FindViewById<Button>(Resource.Id.sbBtn);
            var txtRate = FindViewById<TextView>(Resource.Id.ratStar);

            txtRate.Text = "Rate: ";
            subBtn.Click += (s, e) =>
            {
                string ratingvalue = ratingBar.Rating.ToString();
                txtRate.Text = "Rate: " + ratingvalue;

            };
        }
    }
       
}