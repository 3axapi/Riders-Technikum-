using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaImages;

public partial class MainWindow : Window
{
    private readonly string[] _imagePaths = 
    {
        "avares://AvaloniaImages/Assets/Images/5501833.jpg",
        "avares://AvaloniaImages/Assets/Images/olsztyn.jpg",
        "avares://AvaloniaImages/Assets/5501832.jpg"
    };
    
    private readonly Random _random = new();


    public MainWindow()
    {
        InitializeComponent();
        var uri = new Uri("avares://AvaloniaImages/Assets/Images/olsztyn.jpg");

        using (var stream = AssetLoader.Open(uri))
        {
            var bitmap = new Bitmap(stream);
            DisplayCsharpek.Source = bitmap;
        }
    }

    private void RandomSelectiomButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var randomImagePath = _imagePaths[_random.Next(_imagePaths.Length)];
            using var stream = AssetLoader.Open(new Uri(randomImagePath));
            DisplayCsharpek.Source = new Bitmap(stream);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
























,23