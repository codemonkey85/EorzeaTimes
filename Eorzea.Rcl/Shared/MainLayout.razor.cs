namespace Eorzea.Rcl.Shared;

public partial class MainLayout
{
    private bool isDarkMode;
    private MudThemeProvider? mudThemeProvider;

    private const string AppTitle = "Eorzea Times";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && mudThemeProvider is not null)
        {
            isDarkMode = await mudThemeProvider.GetSystemPreference();
            await mudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);
            StateHasChanged();
        }
    }

    private Task OnSystemPreferenceChanged(bool newValue)
    {
        isDarkMode = newValue;
        StateHasChanged();
        return Task.CompletedTask;
    }
}
