using System;
using XamarinReference.Lib.Model;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Cirrious.CrossCore;
using XamarinReference.Lib.Interface;
using Android.Views;

namespace XamarinReference.Droid
{
	public class BusinessCardAdapter : BaseAdapter<Job>
	{
		private readonly IJobsService _jobServices = Mvx.Resolve<IJobsService>();
		private readonly IStringLookupService _services = Mvx.Resolve<IStringLookupService>();

		private Activity _context;
		private IList<Job> _jobs;
		private string _inProgressText, _inReviewText, _myTasksText, _toDoText;

		public IList<Job> Jobs
		{
			get { return _jobs; }
		}

		public override int Count
		{
			get { return _jobs == null ? 0 : _jobs.Count; }
		}
		public BusinessCardAdapter(Activity context)
		{
			_context = context;

			_jobs = _jobServices.Jobs;
			_inProgressText = _services.GetLocalizedString("TaskInProgress");
			_inReviewText = _services.GetLocalizedString("TaskInReview");
			_myTasksText = _services.GetLocalizedString("TaskForReview");
			_toDoText = _services.GetLocalizedString("TaskToDo");
		}


		public override long GetItemId(int position)
		{
			return position;
		}

		public override Job this[int position]
		{
			get { return _jobs[position]; }
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView;
			ViewHolder holder;

			if (view == null)
			{
				view = _context.LayoutInflater.Inflate(Resource.Layout.BusinessCardItem, parent, false);
				holder = new ViewHolder
				{
					CompanyName = view.FindViewById<TextView>(Resource.Id.textViewName),
					OfficeLocation = view.FindViewById<TextView>(Resource.Id.textViewLocation),
					JobName = view.FindViewById<TextView>(Resource.Id.textViewJobName),
					DueDate = view.FindViewById<TextView>(Resource.Id.textViewDate),
					InProgress = view.FindViewById<TextView>(Resource.Id.textViewInProgress),
					InProgressValue = view.FindViewById<TextView>(Resource.Id.textViewInProgressValue),
					InReview = view.FindViewById<TextView>(Resource.Id.textViewInReview),
					InReviewValue = view.FindViewById<TextView>(Resource.Id.textViewInReviewValue),
					MyTasks = view.FindViewById<TextView>(Resource.Id.textViewMyTasks),
					MyTasksValue = view.FindViewById<TextView>(Resource.Id.textViewMyTasksValue),
					ToDo = view.FindViewById<TextView>(Resource.Id.textViewToDo),
					ToDoValue = view.FindViewById<TextView>(Resource.Id.textViewToDoValue),
				};
				view.Tag = holder;
			}
			else
			{
				holder = view.Tag as ViewHolder;
			}

			var job = _jobs[position];

			holder.CompanyName.Text = job.CompanyName;
			holder.OfficeLocation.Text = job.OfficeLocation;
			holder.JobName.Text = job.JobName;
			if (job.DueDate != null) {
				holder.DueDate.Text = ((DateTime)job.DueDate).ToShortDateString();
			}
			holder.InProgress.Text = _inProgressText;
			holder.InProgressValue.Text = job.TaskInProgress.ToString();
			holder.InReview.Text = _inReviewText;
			holder.InReviewValue.Text = job.TaskInReview.ToString();
			holder.MyTasks.Text = _myTasksText;
			holder.MyTasksValue.Text = job.TaskForReview.ToString();
			holder.ToDo.Text = _toDoText;
			holder.ToDoValue.Text = job.TaskToDo.ToString();
			return view;
		}

		private class ViewHolder : Java.Lang.Object
		{
			public TextView CompanyName { get; set; }
			public TextView OfficeLocation { get; set; }
			public TextView JobName { get; set; }
			public TextView DueDate { get; set; }
			public TextView InProgress { get; set; }
			public TextView InProgressValue { get; set; }
			public TextView InReview { get; set; }
			public TextView InReviewValue { get; set; }
			public TextView MyTasks { get; set; }
			public TextView MyTasksValue { get; set; }
			public TextView ToDo { get; set; }
			public TextView ToDoValue { get; set; }
		}
	}
}

