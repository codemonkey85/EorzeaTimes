namespace Eorzea.Rcl.Components;

public partial class EorzeaClock : IDisposable
{
    private DateTime EorzeaTime { get; set; }

    private string EorzeaTimeString =>
        EorzeaTime.ToString(
            UseMilitaryTime ? Constants.MilitaryTimeDisplayFormat : Constants.DefaultTimeDisplayFormat);

    private Timer? timer;

    private bool UseMilitaryTime { get; set; } = false;

    private bool ShowTimeInTitle { get; set; } = true;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        timer = new Timer(Tick, null, 0, 1000);
    }

    private void Tick(object? _)
    {
        EorzeaTime = DateTime.Now.ToEorzeaTime();
        InvokeAsync(StateHasChanged);
    }

    public void Dispose() => timer?.Dispose();
}
