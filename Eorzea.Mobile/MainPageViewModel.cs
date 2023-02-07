namespace Eorzea.Mobile;

public partial class MainPageViewModel : ObservableObject, IDisposable
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private DateTime eorzeaTime;

    private Timer timer;

    public MainPageViewModel()
    {
        timer = new Timer(UpdateEorzeaTime, null, 0, 1000);
    }

    [RelayCommand]
    private void UpdateEorzeaTime(object _)
    {
        EorzeaTime = DateTime.Now.ToEorzeaTime();
    }

    public void Dispose()
    {
        timer?.Dispose();
    }
}
