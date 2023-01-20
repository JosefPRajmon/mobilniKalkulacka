using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using Java.Lang;
using Javax.Security.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection.Emit;
using System.Xml;
using System.Xml.Serialization;

namespace kalkulačka
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        //layouts
        RelativeLayout calculateLayout;
        RelativeLayout aboutLayout;
        RelativeLayout noteLayout;
        RelativeLayout savedNodesLayout;
        RelativeLayout feedbackLayout;

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
            noteLayout = FindViewById<RelativeLayout>(Resource.Id.notesLayout);
            savedNodesLayout = FindViewById<RelativeLayout>(Resource.Id.saveNodeLayout);
            feedbackLayout = FindViewById<RelativeLayout>(Resource.Id.feedbackLayout);


            tableLayout = FindViewById<TableLayout>(Resource.Id.tableLayout);
            //calculate
            FindViewById<Button>(Resource.Id.calculateButton).Click += delegate { Calculate(); };
            //feedback
            FindViewById<Button>(Resource.Id.feedbackButton).Click += delegate { submitButton_Click(); };
            //add note
            FindViewById<Button>(Resource.Id.saveNoteButton).Click += delegate {

                
            };


            textMessage = FindViewById<TextView>(Resource.Id.message);

            

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        private async void submitButton_Click()
        {
            try
            {

                string title = FindViewById<TextView>(Resource.Id.tittleValue).Text;
                string feedback = FindViewById<TextView>(Resource.Id.feedbackvalue).Text;
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
        {
           { "title", title },
           { "feedback", feedback }
        };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync("https://pepa.uvminteractive.com/feedback/save", content);

                    var responseString = await response.Content.ReadAsStringAsync();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        //calculate
        void Calculate()
        {
            double timeNumValue = Convert.ToDouble(FindViewById<TextView>(Resource.Id.timeValue).Text);
            double distanceNumValue = Convert.ToDouble(FindViewById<TextView>(Resource.Id.distanceValue).Text);
            double speedNumValue = Convert.ToDouble(FindViewById<TextView>(Resource.Id.speedValue).Text);

            TextView timeInput = FindViewById<TextView>(Resource.Id.timeValue);
            TextView distanceInput = FindViewById<TextView>(Resource.Id.distanceValue);
            TextView speedInput = FindViewById<TextView>(Resource.Id.speedValue);


            //check only 2 input hawe value
            if (timeInput.Text.Length >= 1 & distanceInput.Text.Length >= 1 &
                speedInput.Text.Length >= 1)
            {
                FindViewById<TextView>(Resource.Id.calculateError).Text = "Zadejte prosím jen dvě hodnoty.";
            }
            else {
                FindViewById<TextView>(Resource.Id.calculateError).Text = "";
                //check inputs and choose numeric operation
                if (timeInput.Text.Length >= 1 & distanceInput.Text.Length >= 1)
                {
                    speedInput.Text = $"{distanceNumValue / timeNumValue}";
                }
                else if (distanceInput.Text.Length >= 1 & speedInput.Text.Length >= 1) {
                    timeInput.Text = $"{distanceNumValue / speedNumValue}";
                }
                else
                {
                    distanceInput.Text = $"{speedNumValue * timeNumValue}";
                }
            }



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
                    noteLayout.Visibility = ViewStates.Invisible;
                    feedbackLayout.Visibility = ViewStates.Invisible;
                    return true;
                case Resource.Id.navigation_about:
                    textMessage.SetText(Resource.String.title_about);

                    //leyout control
                    calculateLayout.Visibility = ViewStates.Invisible;
                    tableLayout.Visibility = ViewStates.Invisible;
                    noteLayout.Visibility = ViewStates.Invisible;
                    aboutLayout.Visibility = ViewStates.Visible;
                    feedbackLayout.Visibility = ViewStates.Invisible;
                    return true;
                case Resource.Id.navigation_table:
                    textMessage.SetText(Resource.String.title_table);

                    //leyout control
                     calculateLayout.Visibility = ViewStates.Invisible;
                     tableLayout.Visibility = ViewStates.Visible;
                     aboutLayout.Visibility = ViewStates.Invisible;
                     noteLayout.Visibility = ViewStates.Invisible;
                     feedbackLayout.Visibility = ViewStates.Invisible;
                    return true;
                case Resource.Id.navigation_feedback:
                    textMessage.SetText(Resource.String.title_feedback);

                    //leyout control
                    calculateLayout.Visibility = ViewStates.Invisible;
                    tableLayout.Visibility = ViewStates.Invisible;
                    aboutLayout.Visibility = ViewStates.Invisible;
                    noteLayout.Visibility = ViewStates.Invisible;
                    feedbackLayout.Visibility = ViewStates.Visible;
                    return true;
                case Resource.Id.navigation_myItens:
                    textMessage.SetText(Resource.String.title_myItems);

                    //leyout control
                     calculateLayout.Visibility = ViewStates.Invisible;
                     tableLayout.Visibility = ViewStates.Invisible;
                     aboutLayout.Visibility = ViewStates.Invisible;
                     noteLayout.Visibility = ViewStates.Visible;
                     feedbackLayout.Visibility = ViewStates.Invisible;
                    return true;
  //              case Resource.Id.navigation_notifications:
  //                  textMessage.SetText(Resource.String.title_notifications);
  //                  return true;
            }
            
            return false;
            
        }

    }
}

