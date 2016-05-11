
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinReference.Droid.Fragments.Base;
using System.Threading.Tasks;
using XamarinReference.Lib.Interface;
using Cirrious.CrossCore;

namespace XamarinReference.Droid.Fragments
{
	public class MovieDetailsFragment : BaseFragment
	{
		MovieAdapter _movieAdapter;
		private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
		private string _genre;
		ListView _listView;
		private Lib.Model.iTunes.Movies.Movie.ListingType _type;
		private Lib.Model.iTunes.Movies.Movie _movies;
		public enum MovieFragmentType
		{
			TopMovies,
			TopMovieRentals
		};

		public MovieDetailsFragment(string genre, MovieFragmentType type)
		{
			_genre = genre;
			_type = type == MovieDetailsFragment.MovieFragmentType.TopMovies ? 
				Lib.Model.iTunes.Movies.Movie.ListingType.TopMovies : Lib.Model.iTunes.Movies.Movie.ListingType.TopRentals;
		}
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			GetMovies ();
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{

			var view = inflater.Inflate(Resource.Layout.MoviesLayout, container, false);
			_listView = view.FindViewById<ListView>(Resource.Id.listViewMovies);

			return view;
		}

		private async Task GetMovies()
		{
			var progressDialog = ProgressDialog.Show(Activity, "Please wait", "Loading...", true);
			Activity.SetProgressBarIndeterminate (true);
			Activity.SetProgressBarIndeterminateVisibility (true);
			var task = _itunesService.GetMoviesAsync(_type, 25, _genre);
			_movies = await task;
			_movieAdapter = new MovieAdapter (this.Activity, _movies);
			_listView.Adapter = _movieAdapter;
			progressDialog.Hide ();
		}
	}
}

