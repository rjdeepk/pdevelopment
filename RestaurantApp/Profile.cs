using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace RestaurantApp
{
    public class Profile : Fragment
    {
        public string listt;
        Activity localContext;
        public Profile(string list1, Activity myContext)
        {
            
            listt = list1;
            localContext = myContext;

        }

        public Profile(string v, Fragment[] items)
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        
        List<Rname1> myUserList = new List<Rname1>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            
            View myView = inflater.Inflate(Resource.Layout.Profile, container, false);
            ListView listview = (ListView)myView.FindViewById(Resource.Id.listView1);
            
            myUserList.Add(new Rname1("Lahoriye", Resource.Drawable.image1, "2", "Drama"));
            myUserList.Add(new Rname1("Manje Bistre", Resource.Drawable.image1, "4", "Comedy"));
            myUserList.Add(new Rname1("Rabb Da Radio", Resource.Drawable.image1, "5", "Drama"));
            myUserList.Add(new Rname1("Carry on Jatta", Resource.Drawable.image1, "3", "Comedy"));
            myUserList.Add(new Rname1("Ra One", Resource.Drawable.image1, "1", "Drama"));
            
            
            
            // Get our button from the layout resource,

            var myAdatper = new GetRname1(localContext, myUserList);

#pragma warning disable CS0618 // Type or member is obsolete
            listview.SetAdapter(myAdatper);

            //EDITED Code 


#pragma warning disable CS0618 // Type or member is obsolete

#pragma warning restore CS0618 // Type or member is obsolete
            listview.ItemClick += myTeamClickMethod;

            void myTeamClickMethod(object sender, AdapterView.ItemClickEventArgs e)
            {
                System.Console.WriteLine("Item clicked");

                var ivalue = e.Position;
                //var myvalue = [ivalue];

                //System.Console.WriteLine("Value is:-" + myvalue);

            }

            return myView;
            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

       
    }
}