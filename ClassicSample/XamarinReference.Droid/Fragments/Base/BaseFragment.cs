
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
using XamarinReference.Lib.Interface;
using Cirrious.CrossCore;

namespace XamarinReference.Droid.Fragments.Base
{
	public class BaseFragment : Fragment
	{
		//used to look up localized text based on language required
		protected readonly IStringLookupService _localizeLookupService = Mvx.Resolve<IStringLookupService>();

		//used to look up logging based on how the app has logging setup 
		protected readonly ILoggingService _logging = Mvx.Resolve<ILoggingService>();

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return base.OnCreateView (inflater, container, savedInstanceState);
		}
	}
}

