using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EorzeaTimes;

public class EorzeaTimeViewModel : INotifyPropertyChanged
{
    private DateTime eorzeaTime = DateTime.Now.ToEorzeaTime();

    public event PropertyChangedEventHandler PropertyChanged;

    public DateTime EorzeaTime
    {
        get => eorzeaTime;
        set
        {
            eorzeaTime = value;
            OnPropertyChanged();
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
