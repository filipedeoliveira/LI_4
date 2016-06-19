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

        private ImageButton btnLogin;
        private Button btnVerCrit;
        private Button btnMenuPratos;
        private Button btnMenuMapa;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnLogin = FindViewById<ImageButton>(Resource.Id.imageButton1);
            btnVerCrit = FindViewById<Button>(Resource.Id.ver_criticasB);
            btnMenuPratos = FindViewById<Button>(Resource.Id.menu_PratosB);
            btnMenuMapa = FindViewById<Button>(Resource.Id.menu_mapaB);
            btnMenuPratos.Click += BtnMenuPratos_Click;
            btnVerCrit.Click += BtnVerCrit_Click;
            btnMenuMapa.Click += BtnMenuMapa_Click;

            btnLogin.Click += BtnLogin_Click;
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

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this,typeof(LogIn));
            this.StartActivity(intent);
        }

    }  
}