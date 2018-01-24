using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace todoleaf
{
	public partial class MainPage : ContentPage
	{
        ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        protected override void OnAppearing()
        {
            base.OnAppearing();

            QueryList(App.Query);
        }
        public MainPage()
		{
			InitializeComponent();
            CreateUnsortedCat();
        }
        private void CreateUnsortedCat()
        {
            Category unsort = new Category("Unsorted tasks", true);

        }
        private void SelectedCategory(object sender, ItemTappedEventArgs e)
        {
            var selected = (Category)listViewCategories.SelectedItem;
            TaskPage taskPage = new TaskPage(selected.Name, listCategory);
            listViewCategories.SelectedItem = null;
            App.Query = true;
            Navigation.PushAsync(taskPage);
        }
        private void EditCat_Clicked(object sender, EventArgs e)
        {
            EditCategories editCategories = new EditCategories(listCategory);
            Navigation.PushAsync(editCategories);
        }
        private void AddCat_Clicked(object sender, EventArgs e)
        {
            EditCategory editCat = new EditCategory(listCategory, new Category(""));
            Navigation.PushAsync(editCat);
        }
        private void QueryList(bool query)
        {
            if(query)
            {
                listCategory = new ObservableCollection<Category>();

                foreach (Category item in App.DatabaseCategories.GetAllAsync().Result)
                {
                    listCategory.Add(item);
                }
                listViewCategories.ItemsSource = listCategory;
                App.Query = false;
            }
        }
    }
}
