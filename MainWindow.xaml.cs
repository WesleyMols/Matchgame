using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Matchgame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
            
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🦑", "🦑",
                "🙊", "🙊",
                "🦁", "🦁",
                "🦄", "🦄",
                "🐊", "🐊",
                "🐋", "🐋",
                "🐉", "🐉",
                "🦚", "🦚",
            };
            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
                
            }
        }

        TextBlock lastTextBlockClicked;
        Boolean isMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock currentTextBLockClicked = sender as TextBlock;
            if(isMatch == false)
            {
                currentTextBLockClicked.Visibility = Visibility.Hidden;
                lastTextBlockClicked = currentTextBLockClicked;
                isMatch = true;
            }
            else if(currentTextBLockClicked.Text == lastTextBlockClicked.Text)
            {
                currentTextBLockClicked.Visibility = Visibility.Hidden;
                isMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                isMatch = false;
            }
        }
    }
}