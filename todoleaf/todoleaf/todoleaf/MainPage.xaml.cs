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
        public MainPage()
		{
			InitializeComponent();
            /*Category cat1 = new Category("Kat 1");
            Category cat2 = new Category("Kat 2");
            listCategory.Add(cat1);
            listCategory.Add(cat2);*/

            foreach (Category item in App.DatabaseCategories.GetAllAsync().Result)
            {
                listCategory.Add(item);
            }

            MessagingCenter.Subscribe<MainPage>(this, "UpdateList", (sender) => {
                listCategory = new ObservableCollection<Category>();

                foreach (Category item in App.DatabaseCategories.GetAllAsync().Result)
                {
                    listCategory.Add(item);
                }

                listViewCategories.ItemsSource = listCategory;
            });

            listViewCategories.ItemsSource = listCategory;
        }
        private void SelectedCategory(object sender, ItemTappedEventArgs e)
        {
            var selected = (Category)listViewCategories.SelectedItem;
            TaskPage taskPage = new TaskPage(selected.Name, listCategory);
            listViewCategories.SelectedItem = null;
            Navigation.PushAsync(taskPage);
        }
        private void EditCat_Clicked(object sender, EventArgs e)
        {
            EditCategories editCategories = new EditCategories(listCategory);
            Navigation.PushAsync(editCategories);
        }
        private void AddCat_Clicked(object sender, EventArgs e)
        {
            EditCategory editCat = new EditCategory(listCategory, new Category(""), this);
            Navigation.PushAsync(editCat);
        }
    }
}
