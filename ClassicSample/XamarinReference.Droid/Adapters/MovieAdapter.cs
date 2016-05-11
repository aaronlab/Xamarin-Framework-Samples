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
	public class MovieAdapter : BaseAdapter<Lib.Model.iTunes.Movies.Entry>
	{
		private Activity _context;

		private Lib.Model.iTunes.Movies.Movie _movies;
		public Lib.Model.iTunes.Movies.Movie Movies
		{
			get { return _movies; }
		}

		public override int Count
		{
			get { return _movies == null ? 0 : _movies.Feed.Entry.Count; }
		}

		public MovieAdapter (Activity context, Movie movies)
		{
			_context = context;
			_movies = movies;
		}


		public override long GetItemId(int position)
		{
			return position;
		}

		public override Lib.Model.iTunes.Movies.Entry this[int position]
		{
			get { return _movies.Feed.Entry[position]; }
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

			holder.Genre.Text = _movies.Feed.Entry[position].ImName.Label;
			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView Genre { get; set; }
		}
	}
}

