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
using System.Net;
using System.Collections.Specialized;

namespace RatIt
{
    [Activity(Label = "RatIt",Icon = "@android:color/transparent")]
       class LogIn : Activity
    {
        private Button btnRegistar;
        private Button btnLogar;
        private EditText username;
        private EditText pass;

        public object Toastlength { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LogIn);
            btnLogar = FindViewById<Button>(Resource.Id.btnLogIN);  
            btnRegistar = FindViewById<Button>(Resource.Id.btnSignUP);
            btnRegistar.Click += BtnRegitar_Click;
            btnLogar.Click += BtnLogar_Click;
            username = FindViewById<EditText>(Resource.Id.userName);
            pass = FindViewById<EditText>(Resource.Id.password);
            // PARA METER A SETA PARA ANDAR PARA TRÁS
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            // ATÈ AQUI!!!
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            WebClient cliente = new WebClient();
            //Uri uri = new Uri("http://172.26.48.19:8080/Login.php");
            Uri uri = new Uri("http://192.168.1.85:8080/Login.php");
            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("login", username.Text);
            parameters.Add("password", pass.Text);

            cliente.UploadValuesCompleted += Cliente_UploadValuesCompleted;
            cliente.UploadValuesAsync(uri, parameters);
        }

        private void Cliente_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            String resp = Encoding.UTF8.GetString(e.Result);
            if (resp == "ok") {
                Intent intent = new Intent(this, typeof(MenuPrem));
                this.StartActivity(intent);
            }
            else { Toast.MakeText(this, "UserName ou Password errados", ToastLength.Long).Show(); }
        }

        private void BtnRegitar_Click(object sender, EventArgs e)
        {

            Intent intent = new Intent(this, typeof(Registar));
            this.StartActivity(intent);
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