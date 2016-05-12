using System;
using XamarinReference.Lib.Interface;
using Cirrious.CrossCore;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace XamarinReference.Droid
{
	public class MusicGenreAdapter : BaseAdapter<string>
	{
		private Activity _context;
		private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
		private IList<string> _musicGenres;
		public IList<string> MusicGenres
		{
			get { return _musicGenres; }
		}

		public override int Count
		{
			get { return _musicGenres == null ? 0 : _musicGenres.Count; }
		}

		public MusicGenreAdapter (Activity context)
		{
			_context = context;
			_musicGenres = _itunesService.GetMusicVideoGenres();
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override string this[int position]
		{
			get { return _musicGenres[position]; }
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

			holder.Genre.Text = _musicGenres[position];
			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView Genre { get; set; }
		}
	}
}

