using System.Globalization;
using System.Linq;
using System.Windows;

namespace Sign_In_Page;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }







    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        AddCountry();
        AddDay();
        AddMonth();
        AddYear();
    }

    private void AddCountry()
    {
        var list = CultureInfo.GetCultures(CultureTypes.SpecificCultures).
                           Select(p => new RegionInfo(p.Name).EnglishName).
                           Distinct().OrderBy(s => s).ToList();

        Country_combo.ItemsSource = list;
    }

    private void AddDay()
    {
        for (int i = 1; i <= 31; i++)
        {
            Day_combo.Items.Add(i.ToString());
        }
    }

    private void AddMonth()
    {
        Month_combo.Items.Add("January");
        Month_combo.Items.Add("February");
        Month_combo.Items.Add("March");
        Month_combo.Items.Add("April");
        Month_combo.Items.Add("May");
        Month_combo.Items.Add("June");
        Month_combo.Items.Add("July");
        Month_combo.Items.Add("August");
        Month_combo.Items.Add("September");
        Month_combo.Items.Add("October");
        Month_combo.Items.Add("November");
        Month_combo.Items.Add("December");
    }

    private void AddYear()
    {
        for (int i = 1900; i < 2023; i++)
        {
            Year_combo.Items.Add(i.ToString());
        }
    }



}