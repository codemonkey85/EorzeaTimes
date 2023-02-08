using CommunityToolkit.Mvvm.Input;

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

    [RelayCommand]
    private async Task TestNotificationAsync()
    {
#if ANDROID || IOS
        if (await LocalNotificationCenter.Current.AreNotificationsEnabled() is not true)
        {
            await LocalNotificationCenter.Current.RequestNotificationPermission();
        }

        var request = new NotificationRequest
        {
            NotificationId = 1,
            Title = "Test Title",
            Subtitle = "Test Subtitle",
            Description = "Test Description",
            BadgeNumber = 1,
            CategoryType = NotificationCategoryType.Alarm,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now, // .AddSeconds(5),
                //NotifyRepeatInterval = TimeSpan.FromSeconds(1),
                //RepeatType = NotificationRepeat.TimeInterval,
            },
        };

        await LocalNotificationCenter.Current.Show(request);
#endif
    }

    public void Dispose() =>
        timer?.Dispose();
}
