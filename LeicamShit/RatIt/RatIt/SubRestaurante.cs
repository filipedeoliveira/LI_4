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
using Newtonsoft.Json;

namespace RatIt
{

    [Activity(Label = "RatIt")]
    public class SubRestaurante : Activity
    {
        TextView mRestaurante;
        private ListView mListview;
        private List<CriticaRestaurante> mListRest;
        private BaseAdapter<CriticaRestaurante> mAdapter;
        private WebClient client;
        private Uri mUri;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SubMenuRest);

            mRestaurante = FindViewById<TextView>(Resource.Id.restEscolhido);
            mListview = FindViewById<ListView>(Resource.Id.listPrestaurante);
            mRestaurante.Text = Intent.GetStringExtra("Restaurante");

            client = new WebClient();
            //mUri = new Uri("http://172.26.48.19:8080/getCriticasFrest.php");
            mUri = new Uri("http://192.168.1.85:8080/getCriticasFrest.php");

            NameValueCollection parametros = new NameValueCollection();
            parametros.Add("Restaurante", mRestaurante.Text);

            client.UploadValuesAsync(mUri, parametros);
            client.UploadValuesCompleted += Client_UploadValuesCompleted;
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {

                string res = Encoding.UTF8.GetString(e.Result);
                mListRest = JsonConvert.DeserializeObject<List<CriticaRestaurante>>(res);
                mAdapter = new VerCriticasRestAdapter(this, Resource.Layout.ListViewRow, mListRest);
                mListview.Adapter = mAdapter;

            });
        }
    }
}