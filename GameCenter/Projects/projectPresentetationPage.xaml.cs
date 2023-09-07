using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GameCenter.Projects
{
    /// <summary>
    /// Interaction logic for projectPresentetationPage.xaml
    /// </summary>
    public partial class projectPresentetationPage : Window
    {
        private Window? currentProject;
        public projectPresentetationPage()
        {
            InitializeComponent();
        }

        public void OnStart(string title, string projectDescription, ImageSource imageSoursce, Window project)
        {
            TitleLabel.Content = title;
            ProjectText.Text = projectDescription;
            ProjectImage.Source = imageSoursce;
            currentProject = project;
        }

        private void ProjectImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Close();
            currentProject!.ShowDialog();
            currentProject!.Close();
        }
    }
}
