using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SeptemberAvaloniaApplication;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Detonate(object? sender, RoutedEventArgs e)
    {
        welc.Text = "!!! Dotonation confirmed !!!";
    }
}