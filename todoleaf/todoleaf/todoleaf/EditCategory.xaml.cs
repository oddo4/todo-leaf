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
	public partial class EditCategory : ContentPage
	{
        ObservableCollection<Category> listCategory = new ObservableCollection<Category>();
        Category category = new Category();
        MainPage MainPage = null;
        EditCategories EditCategories = null;
        public EditCategory()
        {
            InitializeComponent();
        }
        public EditCategory(ObservableCollection<Category> listCat, Category cat, MainPage mainPage = null)
        {
            InitializeComponent();
            category = cat;
            MainPage = mainPage;
            listCategory = listCat;
            entText.Text = category.Name;
        }
        public EditCategory(ObservableCollection<Category> listCat, Category cat, EditCategories editCategories = null)
        {
            InitializeComponent();
            category = cat;
            EditCategories = editCategories;
            listCategory = listCat;
            entText.Text = category.Name;
        }
        private void SaveCategory_Clicked(object sender, EventArgs e)
        {
            //App.DatabaseCategories.DeleteItemAsync(category);
            Category newCat = new Category(entText.Text);
            App.DatabaseCategories.SaveItemAsync(newCat);
            App.DatabaseTasks.RenameCategoryAsync(newCat.Name, category.Name);
            MessageCenter();
            
            Navigation.PopAsync();
            
        }
        private void DeleteCategory_Clicked(object sender, EventArgs e)
        {
            App.DatabaseCategories.DeleteItemAsync(category);
            App.DatabaseTasks.DeleteCategoryAsync(category.Name);
            MessageCenter();
            Navigation.PopAsync();
        }
        private void MessageCenter()
        {
            if (MainPage != null)
            {
                MessagingCenter.Send(MainPage, "UpdateList");
            }
            else if (EditCategories != null)
            {
                MessagingCenter.Send(EditCategories, "UpdateList");
            }
        }
    }
}