using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace RatIt
{
    [Activity(Label = "MenuMapas", Icon = "@android:color/transparent")]
    public class MenuMapas : Activity
    {
        private EditText cidade;
        private BaseAdapter<Restaurante> mAdapter;
        private Button btnProc;
        private ListView mListview;
        private List<Restaurante> mRest;
        private WebClient client;
        private Uri mUri;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MenuMapa);
            // PARA METER A SETA PARA ANDAR PARA TRÁS
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            // ATÈ AQUI!!!

            btnProc = FindViewById<Button>(Resource.Id.btnProc);
            cidade = FindViewById<EditText>(Resource.Id.localizacao);
            mListview = FindViewById<ListView>(Resource.Id.listView1);
            client = new WebClient();
            //mUri = new Uri("http://172.26.48.19:8080/getContacts.php");
            mUri = new Uri("http://192.168.1.85:8080/getContacts.php");

            btnProc.Click += BtnProc_Click;

        }

        private void BtnProc_Click(object sender, EventArgs e)
        {
            NameValueCollection parametros = new NameValueCollection();
            parametros.Add("Cidade", cidade.Text);

            client.UploadValuesAsync(mUri, parametros);
            client.UploadValuesCompleted += Client_UploadValuesCompleted;
            
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            RunOnUiThread(() =>
            {

                string res = Encoding.UTF8.GetString(e.Result);
                mRest = JsonConvert.DeserializeObject<List<Restaurante>>(res);  
                mAdapter = new RestListAdapter(this,Resource.Layout.ListViewRow, mRest);
                mListview.Adapter = mAdapter;
                
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