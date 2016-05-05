
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

namespace XamarinReference.Droid
{
	[Activity (Label = "Developer Options", HardwareAccelerated = true)]			
	public class DeveloperOptionsActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Create your application here
			SetContentView (Resource.Layout.ActivityFragmentLayout);
			var developerOptionsFragment = new DeveloperOptionsFragment ();
			var ft = FragmentManager.BeginTransaction ();
			ft.Add (Resource.Id.fragment_container, developerOptionsFragment);
			ft.Commit ();
		}


	}
}

