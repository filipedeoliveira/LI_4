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
    class VerCritica : Activity
    {
        private Button btnRestaurante;
        private Button btnCritico;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MenuCritica);
            btnRestaurante = FindViewById<Button>(Resource.Id.btnSeg1);
            btnCritico = FindViewById<Button>(Resource.Id.btnSeg2);
            btnRestaurante.Click += BtnRestaurante_Click;
            btnCritico.Click += BtnCritico_Click;
        }

        private void BtnCritico_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SubCritico));
            this.StartActivity(intent);
        }

        private void BtnRestaurante_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SubRestaurante));
            this.StartActivity(intent);
        }
    }
}
