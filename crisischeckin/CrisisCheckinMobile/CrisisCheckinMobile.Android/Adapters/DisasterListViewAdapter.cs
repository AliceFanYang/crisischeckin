﻿using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Content;

namespace CrisisCheckinMobile.Droid
{
    public class DisasterListViewAdapter : BaseAdapter<DisasterListViewModel>
    {
        private readonly List<DisasterListViewModel> _items;
        private readonly Context _context;

        public DisasterListViewAdapter(Context context, List<DisasterListViewModel> items)
        {
            _items = items;
            _context = context;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView ?? 
                LayoutInflater.From(_context).Inflate(Resource.Layout.disasterListViewRow, null, false);

            TextView disasterName = row.FindViewById<TextView>(Resource.Id.disasterListViewItemName);
            TextView disasterStatusAndDates = row.FindViewById<TextView>(Resource.Id.disasterListViewItemStatusAndDates);

            var item =_items[position];
            disasterName.Text = item.DisasterName;
            disasterStatusAndDates.Text = item.DisasterStatusAndDate;

            return row;
        }

        public override int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public override DisasterListViewModel this[int index]
        {
            get
            {
                return _items[index];
            }
        }
    }
}