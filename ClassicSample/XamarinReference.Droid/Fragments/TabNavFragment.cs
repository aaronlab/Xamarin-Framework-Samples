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

namespace XamarinReference.Droid.Fragments
{
	public class TabNavFragment : BaseFragment
	{
		MainActivity _mainActivity;
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			_mainActivity = (MainActivity)Activity;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.TabNavFragmentLayout, container, false);
			return view;
		}

		public override void OnPause ()
		{
			base.OnPause ();
			_mainActivity.ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
			_mainActivity.ActionBar.RemoveAllTabs ();
		}

		public override void OnResume ()
		{
			base.OnResume ();
			_mainActivity.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			SetupTabs ();
		}

		private void SetupTabs()
		{
			var salesTab = _mainActivity.ActionBar.NewTab();
			salesTab.SetText(_localizeLookupService.GetLocalizedString("TopMovies"));
			salesTab.SetIcon(Resource.Drawable.f008);
			salesTab.TabSelected += (sender, args) => {
				base.FragmentManager.BeginTransaction().Replace(Resource.Id.tabFrameLayout, new MovieSalesFragment()).Commit();
			};
			Activity.ActionBar.AddTab(salesTab);

			var rentalsTab = _mainActivity.ActionBar.NewTab();
			rentalsTab.SetText(_localizeLookupService.GetLocalizedString("TopMovieRentals"));
			rentalsTab.SetIcon(Resource.Drawable.f145);
			rentalsTab.TabSelected += (sender, args) => {
				base.FragmentManager.BeginTransaction().Replace(Resource.Id.tabFrameLayout, new MovieRentalsFragment()).Commit();
			};
			Activity.ActionBar.AddTab(rentalsTab);

			var videosTab = _mainActivity.ActionBar.NewTab();
			videosTab.SetText(_localizeLookupService.GetLocalizedString("TopMusicVideos"));
			videosTab.SetIcon(Resource.Drawable.f001);
			videosTab.TabSelected += (sender, args) => {
				base.FragmentManager.BeginTransaction().Replace(Resource.Id.tabFrameLayout, new MusicVideosFragment()).Commit();
			};
			_mainActivity.ActionBar.AddTab(videosTab);
		}

	}
}