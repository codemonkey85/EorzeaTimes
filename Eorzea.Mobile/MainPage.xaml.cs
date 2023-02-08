namespace Eorzea.Mobile;

public partial class MainPage : ContentPage
{
    public MainPageViewModel ViewModel { get; }

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = ViewModel = viewModel;
#if ANDROID || IOS
        TestButton.IsVisible = true;
#endif
    }
}
