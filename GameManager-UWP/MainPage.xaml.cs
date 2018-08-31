using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace GameManager_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string ScenarioLocation { get; set; }
        public Scenario CurrentScenario { get { return GameFileManager.Instance.GetScenario(ScenarioLocation); } }

        public MainPage()
        {
            InitializeComponent();
            GameFileManager.Instance = new GameFileManager();
            ScenarioLocation = "0";
            LoadScenario();
        }

        private void LoadScenario()
        {
            GameContentTextBlock.Text = CurrentScenario.ResolvedText;
            SetChoicesButtons();
        }

        private void SetChoicesButtons()
        {
            foreach (NavigationViewItem item in navigationView.MenuItems)
            {
                item.IsEnabled = false;
                item.Content = ". . .";
                item.Visibility = Visibility.Collapsed;
            }

            foreach (Choice c in CurrentScenario.Choices)
            {
                (FindName($"Choice{c.Number}NavItem") as NavigationViewItem).IsEnabled = true;
                (FindName($"Choice{c.Number}NavItem") as NavigationViewItem).Content = c.ShortenedText;
                (FindName($"Choice{c.Number}NavItem") as NavigationViewItem).Visibility = Visibility.Visible;
            }
        }

        private void IncrementScenario(object val)
        {
            ScenarioLocation = $"{ScenarioLocation}{val}";
        }

        private void navigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            IncrementScenario((args.SelectedItem as NavigationViewItem).Tag);
            LoadScenario();
        }
    }
}
