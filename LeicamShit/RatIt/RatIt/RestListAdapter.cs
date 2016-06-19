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
using Java.Lang;

namespace RatIt
{
    class RestListAdapter : BaseAdapter<Restaurante>
    {
        private List<Restaurante> items;
        private Context mcontexto;
        private int nLayout;

        public RestListAdapter(Context contexto,int layout, List<Restaurante> list)
        {
            items = list;
            nLayout = layout;
            mcontexto = contexto;
        }
        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Restaurante this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mcontexto).Inflate(nLayout, parent, false);
            }

            TextView txtRest = row.FindViewById<TextView>(Resource.Id.rest);
            txtRest.Text = items[position].Nome;
            TextView txtPont = row.FindViewById<TextView>(Resource.Id.pont);
            txtPont.Text = items[position].PontuacaoMedia;
            TextView txtFreg = row.FindViewById<TextView>(Resource.Id.freguesia);
            txtFreg.Text = items[position].Freguesia;

            return row;

        }
    }
}