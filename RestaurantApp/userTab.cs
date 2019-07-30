using Android.App;
using Android.OS;

namespace RestaurantApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class userTab : Activity
    {
        Fragment[] _fragmentsArray;
        //private readonly Fragment myContext;

        //string name = "Welcome To my App";



        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.usertab);


            _fragmentsArray = new Fragment[]
            {
            new Home( "Mike","21"),
           // new Home("list1",myContext)
            };


            AddTabToActionBar("Home"); //First Tab
            AddTabToActionBar("Profile"); //First Tab


        }

        private void AddTabToActionBar(string tabTitle)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
#pragma warning restore CS0618 // Type or member is obsolete
            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }

        private void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs tabEventArgs)
        {
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout11, frag);
        }


    }
}