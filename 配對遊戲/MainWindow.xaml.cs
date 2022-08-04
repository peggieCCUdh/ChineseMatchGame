using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 配對遊戲
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;
        Dictionary<string, string> matchword = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            TimeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 18)
            {
                timer.Stop();
                TimeTextBlock.Text = TimeTextBlock.Text + "-Play again?";
            }
        }

        private void SetUpGame()
        {
            //throw new NotImplementedException();
            List<string> matchwordlist = new List<string>()
            {
            "打","手",
            "吃","口",
            "英","草",
            "國","囗",
            "他","人",
            "江","水",
            "板","木",
            "快","心",
            "好","女",
            "煮","火",
            "天","大",
            "早","日",
            "會","曰",
            "有","月",
            "次","欠",
            "步","止",
            "爭","爪",
            "飯","食",
            };
            matchword.Add("打", "1");
            matchword.Add("手", "1");
            matchword.Add("吃", "2");
            matchword.Add("口", "2");
            matchword.Add("英", "3");
            matchword.Add("艸", "3");
            matchword.Add("國", "4");
            matchword.Add("囗", "4");
            matchword.Add("他", "5");
            matchword.Add("人", "5");
            matchword.Add("江", "6");
            matchword.Add("水", "6");
            matchword.Add("板", "7");
            matchword.Add("木", "7");
            matchword.Add("快", "8");
            matchword.Add("心", "8");
            matchword.Add("好", "9");
            matchword.Add("女", "9");
            matchword.Add("煮", "10");
            matchword.Add("火", "10");
            matchword.Add("天", "11");
            matchword.Add("大", "11");
            matchword.Add("早", "12");
            matchword.Add("日", "12");
            matchword.Add("會", "13");
            matchword.Add("曰", "13");
            matchword.Add("有", "14");
            matchword.Add("月", "14");
            matchword.Add("次", "15");
            matchword.Add("欠", "15");
            matchword.Add("步", "16");
            matchword.Add("止", "16");
            matchword.Add("爭", "17");
            matchword.Add("爪", "17");
            matchword.Add("飯", "18");
            matchword.Add("食", "18");
            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "TimeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(matchwordlist.Count);
                    string nextword = matchwordlist[index];
                    textBlock.Text = nextword;
                    matchwordlist.RemoveAt(index);
                }
            }
            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
           

            TextBlock textBlock = sender as TextBlock;
                if (findingMatch == false)
                {
                    textBlock.Visibility = Visibility.Hidden;
                    lastTextBlockClicked = textBlock;
                    findingMatch = true;
                }
                else if (matchword[textBlock.Text] == matchword[lastTextBlockClicked.Text])
                {
                    matchesFound++;
                    textBlock.Visibility = Visibility.Hidden;
                    findingMatch = false;
                }
                else
                {
                    lastTextBlockClicked.Visibility = Visibility.Visible;
                    findingMatch = false;
                }
            
        }
        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 18)
            {
                SetUpGame();
            }
        }
    }
}
