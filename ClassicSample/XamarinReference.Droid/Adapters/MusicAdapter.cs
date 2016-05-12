using System;
using XamarinReference.Lib.Model;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Cirrious.CrossCore;
using XamarinReference.Lib.Interface;
using Android.Views;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;
using RadialProgress;
using System.Threading.Tasks;
using XamarinReference.Droid.Fragments;
using XamarinReference.Lib.Model.iTunes.Movies;

namespace XamarinReference.Droid
{
	public class MusicAdapter : BaseAdapter<Lib.Model.iTunes.MusicVideos.Entry>
	{
		private Activity _context;

		private Lib.Model.iTunes.MusicVideos.MusicVideo _music;
		public Lib.Model.iTunes.MusicVideos.MusicVideo Music
		{
			get { return _music; }
		}

		public override int Count
		{
			get { return _music?.Feed?.Entry == null ? 0 : _music.Feed.Entry.Count; }
		}

		public MusicAdapter (Activity context, Lib.Model.iTunes.MusicVideos.MusicVideo music)
		{
			_context = context;
			_music = music;
		}


		public override long GetItemId(int position)
		{
			return position;
		}

		public override Lib.Model.iTunes.MusicVideos.Entry this[int position]
		{
			get { return _music.Feed.Entry[position]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			ViewHolder holder;
			if (view == null) {
				view = _context.LayoutInflater.Inflate (Resource.Layout.ListViewMenuRow, parent, false);
				holder = new ViewHolder {
					Genre = view.FindViewById<TextView> (Resource.Id.menuRowTextView),
				};
				view.Tag = holder;
			}
			else
			{
				holder = view.Tag as ViewHolder;
			}

			holder.Genre.Text = _music.Feed.Entry[position].Title.Label;
			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView Genre { get; set; }
		}
	}
}

