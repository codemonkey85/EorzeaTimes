namespace Eorzea.Shared.Extensions;

public static class EorzeaDateTimeExtensions
{
    // Credit to Oli Trenouth: https://olitee.com/2015/01/c-convert-current-time-ffxivs-eorzea-time/
    public static DateTime ToEorzeaTime(this DateTime date)
    {
        const double EORZEA_MULTIPLIER = 3600D / 175D;

        // Calculate how many ticks have elapsed since 1/1/1970
        var epochTicks = date.ToUniversalTime().Ticks - new DateTime(1970, 1, 1).Ticks;

        // Multiply those ticks by the Eorzea multipler (approx 20.5x)
        var eorzeaTicks = (long)Math.Round(epochTicks * EORZEA_MULTIPLIER);

        return new DateTime(eorzeaTicks);
    }
}
