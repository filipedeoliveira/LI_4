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
using System.Net;
using System.Collections.Specialized;

namespace RatIt
{
        [Activity(Label = "RatIt")]
        class Registar : Activity
        {
            private Button btnVoltar;
            private Button btnSignUP;
        private EditText nome;
        private EditText pass;
        private EditText username;

            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.Registar);
                btnVoltar = FindViewById<Button>(Resource.Id.btnVoltar);
                btnSignUP = FindViewById<Button>(Resource.Id.btnSignUp);
                 nome = FindViewById<EditText>(Resource.Id.nome);
               pass = FindViewById<EditText>(Resource.Id.password);
                 username = FindViewById<EditText>(Resource.Id.userName);
               btnVoltar.Click += BtnVoltar_Click;
               btnSignUP.Click += BtnSignUP_Click;
            }

        private void BtnSignUP_Click(object sender, EventArgs e)
        {
            if (nome.Text.Length== 0 || username.Text.Length == 0 || pass.Text.Length == 0)
            {
                Toast.MakeText(this, "Preencha todos os campos para o registo", ToastLength.Long).Show();
            }
            else {
                WebClient cliente = new WebClient();
                //Uri uri = new Uri("http://172.26.48.19:8080/CreateContact.php");
                Uri uri = new Uri("http://192.168.1.85:8080/CreateContact.php");
                NameValueCollection parametros = new NameValueCollection();
                parametros.Add("Username", username.Text);
                parametros.Add("Password", pass.Text);
                parametros.Add("Nome", nome.Text);

                cliente.UploadValuesCompleted += Cliente_UploadValuesCompleted;
                cliente.UploadValuesAsync(uri, parametros);
            }
        }

        private void Cliente_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                string resp = Encoding.UTF8.GetString(e.Result);
                if (resp.Equals("Query Failed")) { Toast.MakeText(this, "Registo inválido, UserName Repetido", ToastLength.Long).Show(); }
                else
                {
                    Toast.MakeText(this, "Registado com sucesso", ToastLength.Long).Show();
                    Intent intent = new Intent(this, typeof(LogIn));
                    this.StartActivity(intent);
                }
            });
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LogIn));
            this.StartActivity(intent);
        }
    }
   
}