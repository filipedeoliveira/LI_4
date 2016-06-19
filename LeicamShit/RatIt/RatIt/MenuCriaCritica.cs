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
        private EditText restNome;
        private EditText critNome;
        private Button btnAdDescricao;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MenuCriaCritica);
            btnAdDescricao = FindViewById<Button>(Resource.Id.btnDescr);
            restNome = FindViewById<EditText>(Resource.Id.restaurante);
            critNome = FindViewById<EditText>(Resource.Id.critico);
            btnAdDescricao.Click += BtnAdDescricao_Click;
        }

        private void BtnAdDescricao_Click(object sender, EventArgs e)
        {
            if (restNome.Text.Length == 0 || critNome.Text.Length == 0)
            {
                Toast.MakeText(this, "Os campos Nome do restaurante e Nome do critico são obrigatórios", ToastLength.Long).Show();
            }
            else {
                Intent intent = new Intent(this, typeof(AdicionarDescr));
                intent.PutExtra("RestNome", restNome.Text);
                intent.PutExtra("CritNome", critNome.Text);
                this.StartActivity(intent);
            }
        }
    }
}