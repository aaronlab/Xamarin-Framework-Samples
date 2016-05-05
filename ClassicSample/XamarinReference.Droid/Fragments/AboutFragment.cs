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
using XamarinReference.Lib.Interface;
using Cirrious.CrossCore;

namespace XamarinReference.Droid.Fragments
{
	public class AboutFragment : BaseFragment
    {
		private readonly IVersionInfo _versionInfo = Mvx.Resolve<IVersionInfo>();
		protected readonly IStringLookupService _localizeLookupService = Mvx.Resolve<IStringLookupService>();

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.AboutFragmentLayout, container, false);

			var appVersion = view.FindViewById<TextView>(Resource.Id.textViewAppVersion);
			appVersion.Text = string.Format("{0} {1}", _localizeLookupService.GetLocalizedString("BuildVersion"), _versionInfo.ApplicationVersion);;

			var buildDate = view.FindViewById<TextView>(Resource.Id.textViewBuildDate);
			buildDate.Text = string.Format("{0} {1}", _localizeLookupService.GetLocalizedString("BuildDate"),
				_versionInfo.ApplicationBuildTime); 
			
			var osVersion = view.FindViewById<TextView>(Resource.Id.textViewOS);
			osVersion.Text = string.Format("{0} {1}", _localizeLookupService.GetLocalizedString("BuildOsVersion"),
				_versionInfo.OperatingSystemVersion);

			var developerButton = view.FindViewById<Button>(Resource.Id.buttonDeveloperOptions);
			developerButton.Click += (object sender, EventArgs e) => {
				var intent = new Intent(this.Activity, typeof(DeveloperOptionsActivity))
					.SetFlags(ActivityFlags.ReorderToFront);
				StartActivity(intent);
			};
			return view;
		}
    }
}