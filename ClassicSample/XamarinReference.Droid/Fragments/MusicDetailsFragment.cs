
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
using XamarinReference.Lib.Interface;
using Cirrious.CrossCore;
using System.Threading.Tasks;

namespace XamarinReference.Droid
{
	public class MusicDetailsFragment : BaseFragment
	{
		MusicAdapter _musicAdapter;
		private readonly IITunesDataService _itunesService = Mvx.Resolve<IITunesDataService>();
		private string _genre;
		ListView _listView;
		private Lib.Model.iTunes.MusicVideos.MusicVideo _music;
		public enum MovieFragmentType
		{
			TopMovies,
			TopMovieRentals
		};

		public MusicDetailsFragment(string genre)
		{
			_genre = genre;
		}
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			GetMusic ();
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{

			var view = inflater.Inflate(Resource.Layout.MoviesLayout, container, false);
			_listView = view.FindViewById<ListView>(Resource.Id.listViewMovies);

			return view;
		}

		private async Task GetMusic()
		{
			var progressDialog = ProgressDialog.Show(Activity, "Please wait", "Loading...", true);
			Activity.SetProgressBarIndeterminate (true);
			Activity.SetProgressBarIndeterminateVisibility (true);
			var task = _itunesService.GetMusicVideosAsync(25, _genre);
			_music = await task;
			_musicAdapter = new MusicAdapter (this.Activity, _music);
			_listView.Adapter = _musicAdapter;
			progressDialog.Hide ();
		}
	}
}

