using Serilog.Sinks.File;

namespace UnoTest;

public sealed partial class MainPage : Page
{
    private readonly ViewModel ViewModel = new();
    public MainPage()
    {
        this.InitializeComponent();
        DataContext = ViewModel;
    }

    private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string? date = ViewModel.SelectedText;
        if (date != null)
        {
            await ShowDialog("Datum gewählt", "Du hast das Datum "+date+" gewählt");
            return;
        }
    }

    private async void AddToList(object sender, RoutedEventArgs e)
    {
        DateTimeOffset date = ViewModel.SelectedDate;
        if (date.ToString("dd.MM.yyyy").Equals("01.01.0001"))
        {
            await ShowDialog("Datum fehlt", "Du hast kein Datum gewählt");
            return;
        }
        string sDate=date.ToString("dd.MM.yyyy");
        if (ViewModel.Dates.Contains(sDate))
        {
            await ShowDialog("Bereits vorhanden", "Das Datum "+sDate+" ist bereits in der Liste vorhanden");
            return;
        }
        ViewModel.Dates.Add(sDate);
    }

    private async Task ShowDialog(string title, string message)
    {
        ContentDialog dialog = new ContentDialog
        {
            Title = title,
            Content = message,
            CloseButtonText = "OK", 
            XamlRoot=this.XamlRoot
        };
        await dialog.ShowAsync();
    }
}
