using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;

namespace kalkulačka
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        //layouts
        RelativeLayout calculateLayout;
        RelativeLayout aboutLayout;
        TableLayout tableLayout;

        //text
        TextView textMessage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            calculateLayout = FindViewById<RelativeLayout>(Resource.Id.calculateLayout);
            aboutLayout = FindViewById<RelativeLayout>(Resource.Id.aboutLayout);
            tableLayout = FindViewById<TableLayout>(Resource.Id.tableLayout);
            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_calculate:
                    textMessage.SetText(Resource.String.title_home);

                    //leyout control
                    calculateLayout.Visibility = ViewStates.Visible;  
                    tableLayout.Visibility = ViewStates.Invisible;
                    aboutLayout.Visibility = ViewStates.Invisible;
                    return true;
                case Resource.Id.navigation_about:
                    textMessage.SetText(Resource.String.title_about);

                    //leyout control
                    calculateLayout.Visibility = ViewStates.Invisible;
                    tableLayout.Visibility = ViewStates.Invisible;
                    aboutLayout.Visibility = ViewStates.Visible;
                    return true;
                case Resource.Id.navigation_table:
                    textMessage.SetText(Resource.String.title_table);

                    //leyout control
                     calculateLayout.Visibility = ViewStates.Invisible;
                     tableLayout.Visibility = ViewStates.Visible;
                    aboutLayout.Visibility = ViewStates.Invisible;
                    return true;
                case Resource.Id.navigation_feedback:
                    textMessage.SetText(Resource.String.title_feedback);

                    //leyout control
                    calculateLayout.Visibility = ViewStates.Invisible;
                    tableLayout.Visibility = ViewStates.Invisible;
                    aboutLayout.Visibility = ViewStates.Invisible;
                    return true;
                case Resource.Id.navigation_myItens:
                    textMessage.SetText(Resource.String.title_myItems);

                    //leyout control
                     calculateLayout.Visibility = ViewStates.Invisible;
                     tableLayout.Visibility = ViewStates.Invisible;
                    aboutLayout.Visibility = ViewStates.Invisible;
                    return true;
  //              case Resource.Id.navigation_notifications:
  //                  textMessage.SetText(Resource.String.title_notifications);
  //                  return true;
            }
            return false;
        }
    }
}

