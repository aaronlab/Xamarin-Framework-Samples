using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.AppCompat;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Content;
using Cirrious.CrossCore;
using XamarinReference.Lib.Interface;
using XamarinReference.Droid.Fragments;

namespace XamarinReference.Droid
{
	[Activity(Label = "Mobile Sample", MainLauncher = true, HardwareAccelerated = true)]
	public class MainActivity : Activity
    {
		DrawerLayout drawerLayout;
		ActionBarDrawerToggle drawerToggle;
		ListView drawerListView;
		MenuAdapter menuAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			SetContentView(Resource.Layout.Main);
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

			drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, Resource.String.DrawerOpenDescription, Resource.String.DrawerCloseDescription);

			drawerLayout.SetDrawerListener(drawerToggle);
			ActionBar.SetIcon(Android.Resource.Color.Transparent);
			ActionBar.SetDisplayHomeAsUpEnabled(true); 

			drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);
			menuAdapter = new MenuAdapter (this);
			drawerListView.Adapter = menuAdapter;
			drawerListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => OnMenuItemClick(e.Position);
			var aboutFrag = menuAdapter.MenuItems.FirstOrDefault(x => x.Manager.GetType() == typeof(AboutFragment));
			var aboutPos = menuAdapter.MenuItems.IndexOf (aboutFrag);
			drawerListView.SetItemChecked(aboutPos, true);	// Highlight the About Fragment at startup
			OnMenuItemClick(aboutPos);                     // Load About Fragment at startup
        }

		protected override void OnPostCreate(Bundle savedInstanceState)
		{
			//
			// Initialization and any needed Restore operation are now complete.
			// Sync the state of the ActionBarDrawerToggle to the drawer (i.e. show the "hamburger" if the drawer is closed or an arrow if it is open).
			//
			drawerToggle.SyncState();

			base.OnPostCreate(savedInstanceState);
		}

		void OnMenuItemClick(int position)
		{
			var selectedItem = menuAdapter.MenuItems[position];
			base.FragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, selectedItem.Manager).Commit();
			this.Title = selectedItem.Title;
			//var mainActivity = new Intent(this, menuAdapter.MenuItems[position].Manager.GetType());
			//StartActivity(mainActivity);
			drawerLayout.CloseDrawer(drawerListView);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			//
			// Forward all ActionBar-clicks to the ActionBarDrawerToggle.
			// It will verify the click was on the "Home" button (i.e. the button at the left edge of the ActionBar).
			// If so, it will toggle the state of the drawer. It will then return "true" so you know you do not need to do any more processing.
			//
			if (drawerToggle.OnOptionsItemSelected(item))
				return true;

			//
			// Other cases go here for other buttons in the ActionBar.
			// This sample app has no other buttons. This code is a placeholder to show what would be needed if there were other buttons.
			//
			switch (item.ItemId)
			{
			default: break;
			}

			return base.OnOptionsItemSelected(item);
		}
    }
}