
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

using Cirrious.CrossCore;

using XamarinReference.Lib.Interface;
using XamarinReference.Lib.Model;
using XamarinReference.Droid.Activities;

namespace XamarinReference.Droid
{	
	public class MenuAdapter : BaseAdapter<NavigationMenuItem<Fragment>>
	{
		private Activity _context;
		private IList<NavigationMenuItem<Fragment>> _menuItems;
		public IList<NavigationMenuItem<Fragment>> MenuItems
		{
			get { return _menuItems; }
		}

		public override int Count
		{
			get { return _menuItems == null ? 0 : _menuItems.Count; }
		}
		public MenuAdapter(Activity context)
		{
			_context = context;
			var _navMenuService = Mvx.Resolve<INavigationMenuService<Fragment>>();
			_menuItems = _navMenuService.GetMenuItemsEnabled();
		}


		public override long GetItemId(int position)
		{
			return position;
		}

		public override NavigationMenuItem<Fragment> this[int position]
		{
			get { return _menuItems[position]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			ViewHolder holder;

			if (view == null)
			{
				view = _context.LayoutInflater.Inflate(Resource.Layout.ListViewMenuRow, parent, false);
				holder = new ViewHolder
				{
					Title = view.FindViewById<TextView>(Resource.Id.menuRowTextView),
				};
				view.Tag = holder;
			}
			else
			{
				holder = view.Tag as ViewHolder;
			}

			var menuItem = _menuItems[position];

			holder.Title.Text = menuItem.Title;

			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView Title { get; set; }
		}
	}
}

