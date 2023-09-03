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
        EorzeaTime.ToString(UseMilitaryTime ? Constants.MilitaryTimeDisplayFormat : Constants.DefaultTimeDisplayFormat);

    private Timer timer;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EorzeaTimeString))]
    private bool useMilitaryTime;

    partial void OnUseMilitaryTimeChanged(bool oldValue, bool newValue)
    {
        if (oldValue != newValue)
        {
            Preferences.Default.Set(nameof(UseMilitaryTime), newValue);
        }
    }

    public MainPageViewModel()
    {
        timer = new Timer(Tick, null, 0, Constants.TimeRefreshInterval);
        UseMilitaryTime = Preferences.Default.Get(nameof(UseMilitaryTime), false);
    }

    private void Tick(object _) =>
        EorzeaTime = DateTime.Now.ToEorzeaTime();

    [RelayCommand]
#pragma warning disable CA1822 // Mark members as static
#if WINDOWS || MACCATALYST || TIZEN
#pragma warning disable CS1998
#endif
    private async Task TestNotificationAsync()
#if WINDOWS || MACCATALYST || TIZEN
#pragma warning restore CS1998
#endif
#pragma warning restore CA1822 // Mark members as static
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
