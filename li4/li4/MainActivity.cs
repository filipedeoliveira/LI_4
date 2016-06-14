using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace li4
{
    [Activity(Label = "RatIt", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List<string> mItems;
        private ListView mListView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.myListView);
            //ed
            mItems = new List<string>();
            mItems.Add("Consultar Resturantes");
            mItems.Add("Adicio");
            mItems.Add("shfikwei");

            myListViewAdapter adapter = new myListViewAdapter(this, mItems);

            string indexerTest = adapter.mItems[1];
            mListView.Adapter = adapter;
           
          
        }
    }
}

