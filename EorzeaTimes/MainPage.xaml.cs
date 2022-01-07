using System.Timers;
using Timer = System.Timers.Timer;

namespace EorzeaTimes;

public partial class MainPage : ContentPage
{
    private readonly EorzeaTimeViewModel eorzeaTimeViewModel = new();
    private readonly Timer timer = new(1000D);

    public MainPage()
    {
        InitializeComponent();

        EorzeaTimeLabel.BindingContext = eorzeaTimeViewModel;
        EorzeaTimeLabel.SetBinding(Label.TextProperty, "EorzeaTime");

        timer.Elapsed += TimerElapsed;
        timer.Enabled = true;
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e) => eorzeaTimeViewModel.EorzeaTime = DateTime.Now.ToEorzeaTime();
}
