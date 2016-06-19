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
    public class MenuPrem : Activity
    {
        private Button btnCriarRest;
        private Button btnVerCrit;
        private Button btnMenuPratos;
        private Button btnMenuMapa;
        private Button btnCriaCritica;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.menuP);

            btnCriarRest = FindViewById<Button>(Resource.Id.criar_restB);
            btnVerCrit = FindViewById<Button>(Resource.Id.ver_criticasB);
            btnMenuPratos = FindViewById<Button>(Resource.Id.menu_PratosB);
            btnMenuMapa = FindViewById<Button>(Resource.Id.menu_mapaB);
            btnCriaCritica = FindViewById<Button>(Resource.Id.cria_criticasB);
            btnMenuPratos.Click += BtnMenuPratos_Click;
            btnVerCrit.Click += BtnVerCrit_Click;
            btnMenuMapa.Click += BtnMenuMapa_Click;
            btnCriaCritica.Click += BtnCriaCritica_Click;
            btnCriarRest.Click += BtnCriarRest_Click;
        }

        private void BtnCriarRest_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CriaRestaurante));
            this.StartActivity(intent);
        }

        private void BtnCriaCritica_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuCriaCritica));
            this.StartActivity(intent);
        }

        private void BtnMenuMapa_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuMapas));
            this.StartActivity(intent);
        }

        private void BtnMenuPratos_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MenuPratos));
            this.StartActivity(intent);
        }

        private void BtnVerCrit_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(VerCritica));
            this.StartActivity(intent);
        }

    }
}
  