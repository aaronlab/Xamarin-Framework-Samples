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
	public class AboutFragment : BaseFragment
    {
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			//return base.OnCreateView (inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.AboutFragmentLayout, container, false);
			return view;
		}
    }
}