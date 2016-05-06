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
using XamarinReference.Lib.Model;

namespace XamarinReference.Droid.Fragments
{
	public class BusinessCardFragment : BaseFragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.BusinessCardFragmentLayout, container, false);
			var listView = view.FindViewById<ListView>(Resource.Id.listViewBusinessCards);
			listView.Adapter = new BusinessCardAdapter (this.Activity);
			return view;
		}
	}
}