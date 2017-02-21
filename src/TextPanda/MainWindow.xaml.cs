using TextPanda.ViewModels;

namespace TextPanda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SnippetsViewModel();
        }
    }
}
