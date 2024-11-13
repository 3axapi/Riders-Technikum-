using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;

namespace AvaloniaApplication3;

class Album
{
    public string album;
    public string title;
    public int nr_song;
    public int year;
    public int nr_download;
    
    public Album(string album, string title, int nr_song, int year, int nr_download)
    {
        this.album = album;
        this.title = title;
        this.nr_song = nr_song;
        this.year = year;
        this.nr_download = nr_download;
    }
}

public partial class MainWindow : Window
{
    private List<Album> album_objects = new List<Album>();
    public MainWindow()
    {
        InitializeComponent();
    }

    void Recording()
    {
        var uri = new Uri("avares://AvaloniaApplication3/Assets/Data.txt");
        using var stream = AssetLoader.Open(uri);
        using var reader = new StreamReader(stream);
        string content = reader.ReadToEnd();

        List<string> temp_album = new List<string>();
        int crec = 0;

        var lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            if (line != "\n")
            {
                if (crec < 4)
                {
                    temp_album.Add(line); // Użyj Add zamiast Append
                    crec++;
                }
                else
                {
                    // Sprawdź, czy temp_album ma co najmniej 5 elementów
                    if (temp_album.Count >= 5)
                    {
                        album_objects.Add(new Album(temp_album[0], temp_album[1], int.Parse(temp_album[2]), int.Parse(temp_album[3]), int.Parse(temp_album[4])));
                    }
                    temp_album = new List<string>();
                    crec = 0;
                }
            }
            else
            {
                continue;
            }
        }
    }

    private void Right_Click(object? sender, RoutedEventArgs e)
    {
        Recording();
    }
}