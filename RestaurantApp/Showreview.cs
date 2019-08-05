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
    [Activity(Label = "Showreview")]
    public class Showreview : Activity
    {
        ListView list;
        SearchView search;
        List<string> myArray = new List<string>();
        ArrayAdapter myadp;
        DBHelper ob;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Showreview);
            list = FindViewById<ListView>(Resource.Id.rlistView1);
            search = FindViewById<SearchView>(Resource.Id.searchView1);

            ob = new DBHelper(this);
            myArray = ob.GetReviews();
            myadp = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, myArray);
            list.Adapter = myadp;


            //search
            search.QueryTextChange += Mysearch;
        }


        public void Mysearch(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var srch = e.NewText;
            System.Console.WriteLine("Search is:-" + srch);
        }


        // Create your application here
    }
}
