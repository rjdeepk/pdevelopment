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
    [Activity(Label = "Rating")]
    public class Rating : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.rating);
            var ratingBar = FindViewById<RatingBar>(Resource.Id.star);
            ratingBar.NumStars = 5;
            var subBtn = FindViewById<Button>(Resource.Id.sBtn);
            var txtRate = FindViewById<TextView>(Resource.Id.rStar);

            txtRate.Text = "Rate: ";
            subBtn.Click += (s, e) => {
                string ratingvalue = ratingBar.Rating.ToString();
                txtRate.Text = "Rate: " + ratingvalue;

            };


        }
    }
}