using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace RatIt
{
    [Activity(Label = "RatIt", MainLauncher = true, Icon = "@drawable/mudardepois")]
    public class MainActivity : Activity
    {

        private Button btnLogin;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnLogin = FindViewById<Button>(Resource.Id.imageButton1);

            btnLogin.SetOnClickListener(this);
        }

        public void onClick(View v)
        {
            Intent intent = new Intent(this, LogIn.class);
            startActivity(intent);
        }
    }
}