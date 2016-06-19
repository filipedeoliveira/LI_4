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
    [Activity(Label = "RatIt", Icon = "@android:color/transparent")]
    class VerCritica : Activity
    {
        private Button btnRestaurante;
        private Button btnCritico;
        private EditText nomeRest;
        private EditText nomeCritic;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MenuCritica);
            // PARA METER A SETA PARA ANDAR PARA TRÁS
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            // ATÈ AQUI!!!
            btnRestaurante = FindViewById<Button>(Resource.Id.btnSeg1);
            btnCritico = FindViewById<Button>(Resource.Id.btnSeg2);
            nomeRest = FindViewById<EditText>(Resource.Id.restName);
            nomeCritic = FindViewById<EditText>(Resource.Id.nameCritico);
            btnRestaurante.Click += BtnRestaurante_Click;
            btnCritico.Click += BtnCritico_Click;
        }

        private void BtnCritico_Click(object sender, EventArgs e)
        {
            if (nomeCritic.Text.Length == 0)
            {
                Toast.MakeText(this, "Insira um Critico", ToastLength.Long).Show();
            }
            else {
                Intent intent = new Intent(this, typeof(SubCritico));
                intent.PutExtra("Critico", nomeCritic.Text);
                this.StartActivity(intent);
            }
        }

        private void BtnRestaurante_Click(object sender, EventArgs e)
        {
            if (nomeRest.Text.Length == 0)
            {
                Toast.MakeText(this, "Insira um Restaurante", ToastLength.Long).Show();
            }
            else {
                Intent intent = new Intent(this, typeof(SubRestaurante));
                intent.PutExtra("Restaurante", nomeRest.Text);
                this.StartActivity(intent);
            }
        }
        // PARA METER A SETA PARA ANDAR PARA TRÁS
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }

        }
        // ATÉ AQUI!!!
    }
}
