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
    using System.Windows.Threading;
    
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSeconds;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();
            Timer();
            SetUpGame();
            
        }
        private void Timer()
        {
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSeconds++;
            timeTextBlock.Text = (tenthsOfSeconds/10F).ToString("0.0s");
            if(matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text += " - Play Again? click here";
            }
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
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }
            timer.Start();
            tenthsOfSeconds = 0;
            matchesFound = 0;
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
                matchesFound++;
                currentTextBLockClicked.Visibility = Visibility.Hidden;
                isMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                isMatch = false;
            }
        }
        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}