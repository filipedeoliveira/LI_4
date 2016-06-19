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
    public class SubCritico : Activity
    {
        TextView mCritico;
        string nomeCritico;
        private ListView mListview;
        private List<Critica> mCritica;
        private BaseAdapter<Critica> mAdapter;
        private WebClient client;
        private Uri mUri;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SubMenuCritico);
            mCritico = FindViewById<TextView>(Resource.Id.criticoEsc);
            mListview = FindViewById<ListView>(Resource.Id.listCriticos);
            nomeCritico = Intent.GetStringExtra("Critico");
            mCritico.Text = Intent.GetStringExtra("Critico");

            client = new WebClient();
            //mUri = new Uri("http://172.26.48.19:8080/getCriticasFcritico.php");
            mUri = new Uri("http://192.168.1.85:8080/getCriticasFcritico.php");

            NameValueCollection parametros = new NameValueCollection();
            parametros.Add("Critico", mCritico.Text);

            client.UploadValuesAsync(mUri, parametros);
            client.UploadValuesCompleted += Client_UploadValuesCompleted;
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {

                string res = Encoding.UTF8.GetString(e.Result);
                mCritica = JsonConvert.DeserializeObject<List<Critica>>(res);
                mAdapter = new CriticasListAdapter(this, Resource.Layout.ListViewRow, mCritica);
                mListview.Adapter = mAdapter;

            });
        }
    }
}