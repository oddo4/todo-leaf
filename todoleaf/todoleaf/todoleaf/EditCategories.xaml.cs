using System;
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
	public partial class EditCategories : ContentPage
	{
        ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        protected override void OnAppearing()
        {
            base.OnAppearing();
            QueryList(App.Query);
        }
        public EditCategories()
        {
            InitializeComponent();
        }
        public EditCategories(ObservableCollection<Category> listCat)
        {
            InitializeComponent();
            listCategory = listCat;

            listViewCategories.ItemsSource = listCategory;
        }
        private void SelectedCategory(object sender, ItemTappedEventArgs e)
        {
            EditCategory editCat = new EditCategory(listCategory, (Category)listViewCategories.SelectedItem);
            Navigation.PushAsync(editCat);
        }
        private void AddCat_Clicked(object sender, EventArgs e)
        {
            EditCategory editCat = new EditCategory(listCategory, new Category(""));
            Navigation.PushAsync(editCat);
        }
        private void QueryList(bool query)
        {
            if (query)
            {
                listCategory = new ObservableCollection<Category>();

                foreach (Category item in App.DatabaseCategories.GetAllAsync().Result)
                {
                    listCategory.Add(item);
                }
                listViewCategories.ItemsSource = listCategory;
            }
        }

    }
}