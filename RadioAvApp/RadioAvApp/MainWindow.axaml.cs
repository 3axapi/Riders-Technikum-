using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace RadioAvApp;

public partial class MainWindow : Window
{
    private List<RadioButton> group2RaduiButton; 
    public MainWindow()
    {
        InitializeComponent();
        
        SubmitButton.Click += SubmitButton_Click;
        group2RaduiButton = new List<RadioButton>
        {
            RadioButton3,
            RadioButton4,
            RadioButton5,
            RadioButton6
        };
    }

    private void SubmitButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            var checkBoxValue = MyCheckBox.IsChecked == true ? "true" : "false";
            var RadioButtonValue = RadioButton1.IsChecked == true
                ? RadioButton1.Content.ToString()
                : RadioButton2.Content.ToString();
            var selectedGroup2RadioButton = group2RaduiButton.FirstOrDefault(rb => rb.IsChecked == true);
            var group2RadioButtonValue =
                selectedGroup2RadioButton == null ? "" : selectedGroup2RadioButton?.Content.ToString();

            var ComboBoxValue = (ComboBoxMine.SelectedItem as ComboBoxItem)?.Content as string ?? "No selection";
        }
        catch (Exception exception)
        {
            InfoLabel.Content = $"Error: {exception.Message}";
        }
    }
}