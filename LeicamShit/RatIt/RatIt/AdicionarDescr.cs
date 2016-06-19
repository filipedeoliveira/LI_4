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
    public class AdicionarDescr : Activity
    {
        string restNome;
        string critNome;
        private Button btnCriarCrit;
        private EditText critica;
        private EditText pont;
        int pontNum;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AdDescricao);

            restNome = Intent.GetStringExtra("RestNome");
            critNome = Intent.GetStringExtra("CritNome");

            btnCriarCrit = FindViewById<Button>(Resource.Id.btnCriar);
            critica = FindViewById<EditText>(Resource.Id.critica);
            pont = FindViewById<EditText>(Resource.Id.rating);
            btnCriarCrit.Click += BtnCriarCrit_Click;
            
        }

        private void BtnCriarCrit_Click(object sender, EventArgs e)
        {
            pontNum = Int32.Parse(pont.Text);
            if (critica.Text.Length == 0 || pont.Text.Length == 0)
            {
                Toast.MakeText(this, "Insira uma avaliação e uma Critica text!!", ToastLength.Long).Show();
            }
            else if (pontNum < 0 || pontNum > 5) { Toast.MakeText(this, "A pontuação só pode variar entre 0 e 5", ToastLength.Long).Show(); }
            else {
                WebClient cliente = new WebClient();
                //Uri uri = new Uri("http://172.26.48.19:8080/CreateCritica.php");
                Uri uri = new Uri("http://192.168.1.85:8080/CreateCritica.php");
                NameValueCollection parametros = new NameValueCollection();
                parametros.Add("Restaurante", restNome);
                parametros.Add("Critico", critNome);
                parametros.Add("Pontuacao", pont.Text);
                parametros.Add("Critica", critica.Text);

                cliente.UploadValuesCompleted += Cliente_UploadValuesCompleted;
                cliente.UploadValuesAsync(uri, parametros);
            }
        }

        private void Cliente_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                string resp = Encoding.UTF8.GetString(e.Result);
                if (resp.Equals("Query Failed")) { Toast.MakeText(this, "Algo correu mal, porfavor tente mais tarde", ToastLength.Long).Show(); }
                else
                {
                    Toast.MakeText(this, "Critica registada com sucesso, Obrigado!", ToastLength.Long).Show();
                    Intent intent = new Intent(this, typeof(MenuPrem));
                    this.StartActivity(intent);
                }
            });
        }
    }
}