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
        public EditCategory()
        {
            InitializeComponent();
        }
        public EditCategory(ObservableCollection<Category> listCat, Category cat)
        {
            InitializeComponent();
            category = cat;
            listCategory = listCat;
            entText.Text = category.Name;
        }
        private void SaveCategory_Clicked(object sender, EventArgs e)
        {
            //App.DatabaseCategories.DeleteItemAsync(category);
            App.DatabaseTasks.RenameCategoryAsync(entText.Text, category.Name);
            Category newCat = category;
            newCat.Name = entText.Text;
            App.DatabaseCategories.SaveItemAsync(newCat);
            App.Query = true;
            Navigation.PopAsync();
            
        }
        private void DeleteCategory_Clicked(object sender, EventArgs e)
        {
            App.DatabaseCategories.DeleteItemAsync(category);
            App.DatabaseTasks.DeleteCategoryAsync(category.Name);
            App.Query = true;
            Navigation.PopAsync();
        }
    }
}