using System;
using XamarinReference.Lib.Interface;
using Cirrious.CrossCore;
using Android.App;
using Android.Views;
using Android.Widget;

namespace XamarinReference.Droid
{
	public class MusicAdapter : BaseAdapter<Lib.Model.iTunes.MusicVideos.Entry>
	{
		private Activity _context;
		private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
		private Lib.Model.iTunes.MusicVideos.MusicVideo _music;
		public Lib.Model.iTunes.MusicVideos.MusicVideo Music
		{
			get { return _music; }
		}

		public override int Count
		{
			get { return _music == null ? 0 : _music.Feed.Entry.Count; }
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

			holder.Genre.Text = _music.Feed.Entry[position].ImName.Label;
			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView Genre { get; set; }
		}
	}
}

