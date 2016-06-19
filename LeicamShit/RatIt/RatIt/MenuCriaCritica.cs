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
    public class MenuCriaCritica : Activity
    {

        private Button btnAdDescricao;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MenuCriaCritica);
            btnAdDescricao = FindViewById<Button>(Resource.Id.btnDescr);

            btnAdDescricao.Click += BtnAdDescricao_Click;
        }

        private void BtnAdDescricao_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AdicionarDescr));
            this.StartActivity(intent);
        }
    }
}