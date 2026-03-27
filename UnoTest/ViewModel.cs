using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UnoTest;

internal class ViewModel : INotifyPropertyChanged
{
    private string? selectedText;

    private DateTimeOffset selectedDate;

    public ObservableCollection<string> Dates { get; } = new();

    public DateTimeOffset SelectedDate
    {
        get => selectedDate;
        set
        {
            if (selectedDate != value)
            {
                selectedDate= value;
                OnPropertyChanged();
            }
        }
    }

    public string? SelectedText
    {
        get=> selectedText;
        set
        {
            if (selectedText != value)
            {
                selectedText = value;
                OnPropertyChanged();
            }
        }
    }

    private void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
