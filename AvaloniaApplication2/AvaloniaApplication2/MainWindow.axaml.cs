using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;

namespace AvaloniaApplication2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ReadButton_Click(object? sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.CurrentDirectory, "test.txt");

        if (File.Exists(filePath))
        {
            using var reader = new StreamReader(filePath);
            ContentTextBox.Text = reader.ReadToEnd();
        }
        else
        {
            var uri = new Uri("avares://AvaloniaApplication2/Assets/data.txt");
            using var stream = AssetLoader.Open(uri);
            using var reader = new StreamReader(stream);
            ContentTextBox.Text = reader.ReadToEnd();
        }
    }

    private void WriteButton_Click(object? sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.CurrentDirectory, "test.txt");
 
        using var writer = new StreamWriter(filePath);
        writer.Write(ContentTextBox.Text);
        
        Console.WriteLine($"Wrote {filePath}");
    }

    private void UpdateButton_Click(object? sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.CurrentDirectory, "test.txt");
        
        if (File.Exists(filePath))
        {
            var originalContent = File.ReadAllLines(filePath);
            Console.WriteLine("Oryginalna zawartość");
            Console.WriteLine(originalContent);

            using var writer = new StreamWriter(filePath, false);
            writer.Write(ContentTextBox.Text);
            Console.WriteLine($"Wrote: {filePath}");
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }

    private void DeleteButton_Click(object? sender, RoutedEventArgs e)
    {
        var filePath = Path.Combine(Environment.CurrentDirectory, "test.txt");
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"Delete {filePath}");
            ContentTextBox.Text = String.Empty;
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }
}