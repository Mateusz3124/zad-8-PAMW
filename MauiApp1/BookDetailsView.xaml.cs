using P12MAUI.Client.ViewModels;

namespace P12MAUI.Client;

public partial class BookDetailsView : ContentPage
{
	public BookDetailsView(BookDetailsViewModel bookDetailsViewModel)
	{
        BindingContext = bookDetailsViewModel;
        InitializeComponent();
	}
}