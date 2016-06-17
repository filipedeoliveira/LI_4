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

namespace RatIt
{
        [Activity(Label = "RatIt")]
        class Registar : Activity
        {
            private Button btnVoltar;

            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Registar);
                btnVoltar = FindViewById<Button>(Resource.Id.btnVoltar);
                btnVoltar.Click += BtnVoltar_Click;
            }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LogIn));
            this.StartActivity(intent);
        }
    }
   
}