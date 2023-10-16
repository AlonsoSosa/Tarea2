
namespace Tarea2.Views;


public partial class PageListPerson : ContentPage
{
	public PageListPerson()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        list.ItemsSource = await App.Instancia.listPersonas();
    }

    private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PagePerson());
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

    }
}