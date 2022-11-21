using Microsoft.Win32;
using Sign_In_Page.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sign_In_Page;

public partial class MainWindow : Window
{
    public List<Human> Humen;

    public MainWindow()
    {
        InitializeComponent();
        Humen = new List<Human>();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        AddCountry();
        AddDay();
        AddMonth();
        AddYear();
    }





    private void Button_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog op = new OpenFileDialog();

        op.Title = "Select a picture";
        op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

        if (op.ShowDialog() == true)
        {
            //Profile_Photo.Fill = new ImageBrush(new BitmapImage(new Uri(op.FileName)));
            profile.ImageSource = new BitmapImage(new Uri(op.FileName));
            profile.Stretch = Stretch.UniformToFill;
        }

    }

    private void Button_Delete(object sender, RoutedEventArgs e)
    => Profile_Photo.Fill = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\Kamran\source\repos\Sign In_Page\Sign In_Page\userFirst.png", UriKind.Relative)));

    private void Sign_In_click(object sender, RoutedEventArgs e)
    {
        Human human = new();

        if (string.IsNullOrWhiteSpace(FullName_txt.Text))
        {
            MessageBox.Show("Enter FullName, please", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        if (string.IsNullOrWhiteSpace(Title_txt.Text))
        {
            MessageBox.Show("Enter Title, please", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        if (string.IsNullOrWhiteSpace(Email_txt.Text))
        {
            MessageBox.Show("Enter Email, please", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        if (string.IsNullOrWhiteSpace(Slogan_txt.Text))
        {
            MessageBox.Show("Enter Slogan, please", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        if (string.IsNullOrWhiteSpace(Region_txt.Text))
        {
            MessageBox.Show("Enter Region, please", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        if (string.IsNullOrWhiteSpace(Postal_txt.Text))
        {
            MessageBox.Show("Enter Postal, please", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        if (string.IsNullOrWhiteSpace(Phone_txt.Text))
        {
            MessageBox.Show("Enter Phone number, please", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);
        }



        if (Email_txt.Text.EndsWith("@mail.ru") || Email_txt.Text.EndsWith("@gmail.com") || Email_txt.Text.EndsWith("@yahoo.com"))
        {
            human.FullName = FullName_txt.Text;
            human.Title = Title_txt.Text;
            human.Email = Email_txt.Text;
            human.Slogan = Slogan_txt.Text;


            int day = int.Parse(Day_combo.SelectedItem.ToString()!);
            int month = int.Parse(Month_combo.SelectedItem.ToString()!);
            int year = int.Parse(Year_combo.SelectedItem.ToString()!);


            human.Birthday = new DateTime(year, month, day);
            human.Country = Country_combo.SelectedItem.ToString();
            human.Region = Region_txt.Text;
            human.PostalCode = Postal_txt.Text;
            human.PhoneNumber = Phone_txt.Text;

            human.Posts = Random.Shared.Next(0, 256);
            human.Messages = Random.Shared.Next(0, 256);
            human.Members = Random.Shared.Next(0, int.MaxValue / 1000);

            human.PictureUrl = profile.ImageSource.ToString();

            FullName.Content = human.FullName;
            Title.Content = human.Title;
            Posts.Content = human.Posts;
            Messages.Content = human.Messages;
            Members.Content = human.Members;
            Slogan.Content = human.Slogan;



            FullName_txt.IsEnabled = false;
            Title_txt.IsEnabled = false;
            Email_txt.IsEnabled = false;
            Slogan_txt.IsEnabled = false;
            Region_txt.IsEnabled = false;
            Postal_txt.IsEnabled = false;
            Phone_txt.IsEnabled = false;


            Humen.Add(human);
        }
        else
            MessageBox.Show("The email must end with mail.ru or gmail.com, yahoo.com", "Validation", MessageBoxButton.OK, MessageBoxImage.Information);




        var jsonString = System.Text.Json.JsonSerializer.Serialize(Humen);
        File.WriteAllText("Humen.json", jsonString);


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
        for (int i = 1; i <= 12; i++)
        {
            Month_combo.Items.Add(i);
        }
    }
    private void AddYear()
    {
        for (int i = 1900; i < 2023; i++)
        {
            Year_combo.Items.Add(i.ToString());
        }
    }

    private void AddCountry()
    {
        var list = CultureInfo.GetCultures(CultureTypes.SpecificCultures).
                           Select(p => new RegionInfo(p.Name).EnglishName).
                           Distinct().OrderBy(s => s).ToList();

        Country_combo.ItemsSource = list;
    }


    private void Profile_Photo_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            foreach (string fileName in filenames)
            {
                profile.ImageSource = new BitmapImage(new Uri(fileName));
                //Profile_Photo.Fill = new ImageBrush(new BitmapImage(new Uri(fileName, UriKind.Relative)));
            }
        }
    }
}