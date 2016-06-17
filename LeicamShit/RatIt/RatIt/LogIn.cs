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

namespace RatIt
{
    [Activity(Label = "RatIt")]
       class LogIn : Activity
    {
        private Button btnRegistar;
        private Button btnLogar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LogIn);
            btnLogar = FindViewById<Button>(Resource.Id.btnLogIN);
            btnRegistar = FindViewById<Button>(Resource.Id.btnSignUP);
            btnRegistar.Click += BtnRegitar_Click;
            btnLogar.Click += BtnLogar_Click;
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuPrem));
            this.StartActivity(intent);
        }

        private void BtnRegitar_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Registar));
            this.StartActivity(intent);
        }
    }
}