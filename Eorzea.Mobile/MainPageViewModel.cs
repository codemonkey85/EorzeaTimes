namespace Eorzea.Mobile;

public partial class MainPageViewModel : ObservableObject, IDisposable
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EorzeaTimeString))]
    private DateTime eorzeaTime;

    public string EorzeaTimeString =>
        EorzeaTime.ToString(Constants.DefaultTimeDisplayFormat);

    private Timer timer;

    public MainPageViewModel() =>
        timer = new Timer(Tick, null, 0, 1000);

    private void Tick(object _) =>
        EorzeaTime = DateTime.Now.ToEorzeaTime();

    public void Dispose() =>
        timer?.Dispose();
}
