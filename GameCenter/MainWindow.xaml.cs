using GameCenter.Projects;
using GameCenter.Projects.Project1;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace GameCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer clock = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            clock.Tick += ShowCurrentDate!;
            clock.Start();

        }

        private void ShowCurrentDate(object sender, EventArgs e)
        {
            DateLabel.Content = DateTime.UtcNow.ToString("dddd, dd, MMMM yyyy HH:mm:ss");
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 0.6;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
        }

        private void OnImage1Click(object sender, MouseButtonEventArgs e)
        {
            Project1 project1 = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart(
                "To-Do List", "" +
                "s simply dummy text of the printing and typesetting industry. " +
                "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                "when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived not only five centuries, but also the leap into electronic typesetting, " +
                "remaining essentially unchanged. " +
                "It was popularised in the 1960s with the release of Letraset sheets containing Lorem " +
                "Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker " +
                "including versions of Lorem Ipsum.", 
                Image1.Source, 
                project1
            );
            presentetion.ShowDialog();
        }

        private void OnImage2Click(object sender, MouseButtonEventArgs e)
        {
            Project1 project1 = new();
            projectPresentetationPage presentetion = new();
            presentetion.OnStart(
                "PacMan", "" +
                "this is pucman",
                Image2.Source,
                project1
            );
        }
    }
}
