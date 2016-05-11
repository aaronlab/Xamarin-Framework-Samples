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
using Android.Graphics;
using RadialProgress;

namespace XamarinReference.Droid
{
	public class GenreAdapter : BaseAdapter<string>
	{
		private Activity _context;
		private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
		private IList<string> _genres;
		public IList<string> Genres
		{
			get { return _genres; }
		}

		public override int Count
		{
			get { return _genres == null ? 0 : _genres.Count; }
		}

		public GenreAdapter (Activity context)
		{
			_context = context;
			_genres = _itunesService.GetMovieGenres();

		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override string this[int position]
		{
			get { return _genres[position]; }
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

			holder.Genre.Text = _genres[position];
			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView Genre { get; set; }
		}
	}
}

