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
    class VerCriticasRestAdapter : BaseAdapter<CriticaRestaurante>
    {
        private List<CriticaRestaurante> items;
        private Context mcontexto;
        private int nLayout;

        public VerCriticasRestAdapter(Context contexto, int layout, List<CriticaRestaurante> list)
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

        public override CriticaRestaurante this[int position]
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

            TextView txtCritica = row.FindViewById<TextView>(Resource.Id.rest);
            txtCritica.Text = items[position].Criticatxt;
            TextView txtPont = row.FindViewById<TextView>(Resource.Id.pont);
            txtPont.Text = items[position].PontuacaoMedia;
            TextView txtRest = row.FindViewById<TextView>(Resource.Id.freguesia);
            txtRest.Text = items[position].Critico;

            return row;

        }
    }
}