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
    [Activity(Label = "CriaRestaurante", Icon = "@android:color/transparent")]
    public class CriaRestaurante : Activity
    {
        private Button validar;
        private EditText rest;
        private EditText cidade;
        private EditText freg;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application herev
            SetContentView(Resource.Layout.CriarRestaurante);

            validar = FindViewById<Button>(Resource.Id.btnRegistar);
            rest = FindViewById<EditText>(Resource.Id.restaurante);
            cidade = FindViewById<EditText>(Resource.Id.cidade);
            freg = FindViewById<EditText>(Resource.Id.freguesia);

            validar.Click += Validar_Click;

            // PARA METER A SETA PARA ANDAR PARA TRÁS
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            // ATÈ AQUI!!!
        }

        private void Validar_Click(object sender, EventArgs e)
        {
            if (rest.Text.Length == 0 || cidade.Text.Length == 0 || freg.Text.Length == 0)
            {
                Toast.MakeText(this, "Preencha todos os campos para o registo", ToastLength.Long).Show();
            }
            else {
                int pt = 0;
                string pont = pt.ToString();
                WebClient cliente = new WebClient();
                //Uri uri = new Uri("http://172.26.48.19:8080/CreateRest.php");
                Uri uri = new Uri("http://192.168.1.85:8080/CreateRest.php");
                NameValueCollection parametros = new NameValueCollection();
                parametros.Add("Restaurante", rest.Text);
                parametros.Add("Cidade", cidade.Text);
                parametros.Add("Freguesia", freg.Text);
                parametros.Add("Pontuacao", pont);

                cliente.UploadValuesCompleted += Cliente_UploadValuesCompleted;
                cliente.UploadValuesAsync(uri, parametros);
            }
        }

        private void Cliente_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                string resp = Encoding.UTF8.GetString(e.Result);
                if (resp.Equals("Query Failed")) { Toast.MakeText(this, "Registo inválido, Restaurante já existe", ToastLength.Long).Show(); }
                else
                {
                    Toast.MakeText(this, "Novo Restaurante registado com sucesso", ToastLength.Long).Show();
                    Intent intent = new Intent(this, typeof(MenuPrem));
                    this.StartActivity(intent);
                }
            });
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