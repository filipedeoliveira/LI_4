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
    public class MenuPratos : Activity
    {
        private Button btnCria;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MenuPratos);
            btnCria = FindViewById<Button>(Resource.Id.btnCriarPrato);
            btnCria.Click += BtnCria_Click;
        }

        private void BtnCria_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CriarPratos));
            this.StartActivity(intent);
        }
    }
}