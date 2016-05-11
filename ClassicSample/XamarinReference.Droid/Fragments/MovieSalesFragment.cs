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

using XamarinReference.Droid.Fragments.Base;
using Cirrious.CrossCore;
using XamarinReference.Lib.Interface;

namespace XamarinReference.Droid.Fragments
{
	public class MovieSalesFragment : BaseFragment
	{
		GenreAdapter _genreAdapter;
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.MoviesLayout, container, false);
			var listView = view.FindViewById<ListView>(Resource.Id.listViewMovies);
			_genreAdapter = new GenreAdapter (this.Activity);
			listView.Adapter = _genreAdapter;
			listView.ItemClick += GenreClicked;
			return view;
		}

		void GenreClicked (object sender, AdapterView.ItemClickEventArgs e)
		{
			var genre = _genreAdapter.Genres[e.Position];
			FragmentManager.BeginTransaction()
				.Replace(Resource.Id.tabFrameLayout, new MovieDetailsFragment(genre, MovieDetailsFragment.MovieFragmentType.TopMovies))
				.AddToBackStack(genre)
				.CommitAllowingStateLoss();
			Activity.ActionBar.Title = genre;
		}
	}
}