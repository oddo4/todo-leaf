using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace todoleaf
{
	public partial class App : Application
	{
        public static bool Query = true;
        static TodoItemDatabase databaseTasks;
        static CategoryDatabase databaseCategories;

        public static TodoItemDatabase DatabaseTasks
        {
            get
            {
                if (databaseTasks == null)
                {
                    databaseTasks = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TasksDB.db3"));
                }
                return databaseTasks;
            }
        }
        public static CategoryDatabase DatabaseCategories
        {
            get
            {
                if (databaseCategories == null)
                {
                    databaseCategories = new CategoryDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("CategoryDB.db3"));
                }
                return databaseCategories;
            }
        }

        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
