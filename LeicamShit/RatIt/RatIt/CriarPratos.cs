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
using System.Collections.Generic;
using Android.Content.PM;
using Android.Net;
using Android.Graphics;
using Android.Provider;
using Java.IO;

namespace RatIt
{
    [Activity(Label = "CriarPratos")]
    public class CriarPratos : Activity
    {
        private Button btnFoto;
        private ImageView foto;
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            // Create your application here
            SetContentView(Resource.Layout.CriaPrato);
            btnFoto = FindViewById<Button>(Resource.Id.myButton);
            foto = FindViewById<ImageView>(Resource.Id.imageView1);

            btnFoto.Click += BtnFoto_Click;
        }

        private void BtnFoto_Click(object sender, EventArgs e)
        {
            //Intent intent = new Intent("android.media.action.IMAGE_CAPTURE");
            //StartActivityForResult(intent, 0);
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));
            StartActivityForResult(intent, 0);
        }

    }
}