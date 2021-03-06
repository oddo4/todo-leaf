﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todoleaf
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditTask : ContentPage
	{
        ObservableCollection<TodoItem> listTasks = new ObservableCollection<TodoItem>();
        ObservableCollection<Category> listCat = new ObservableCollection<Category>();
        List<string> listCategory = new List<string>();
        TodoItem task = new TodoItem();
        public EditTask()
        {
            InitializeComponent();
        }
        public EditTask(ObservableCollection<TodoItem> listTasks, ObservableCollection<Category> listCat, TodoItem task)
        {
            InitializeComponent();
            this.task = task;
            this.listCat = listCat;
            this.listTasks = listTasks;
            foreach (Category cat in listCat)
            {
                if(!listCategory.Contains(cat.Name))
                {
                    listCategory.Add(cat.Name);
                }
            }
            entText.Text = task.Text;
            pkrCategories.ItemsSource = listCategory;
            pkrCategories.SelectedIndex = listCategory.FindIndex(x => x.StartsWith(this.task.Name));
        }
        /*private void SelectedTask(object sender, ItemTappedEventArgs e)
        {

        }*/
        private void SaveTask_Clicked(object sender, EventArgs e)
        {
            if (task.Name != (string)pkrCategories.SelectedItem)
            {
                App.DatabaseTasks.DeleteItemAsync(task);
            }
            task.Name = (string)pkrCategories.SelectedItem;
            task.Text = entText.Text;
            App.DatabaseTasks.SaveItemAsync(task);
            App.Query = true;
            Navigation.PopAsync();
        }
        private void DeleteTask_Clicked(object sender, EventArgs e)
        {
            App.DatabaseTasks.DeleteItemAsync(task);
            TaskPage taskPage = new TaskPage(task.Name, listCat);
            App.Query = true;
            Navigation.PopAsync();
        }
    }
}