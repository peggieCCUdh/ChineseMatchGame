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
            //string A = "打", B = "吃" ,C = "英",D = "國",E = "他",F = "江",G = "板",H = "快",I = "好",J = "煮",K = "大",L = "早",M = "會",N = "有",O = "次",P = "步",Q = "爭",R = "飯";
            
            //throw new NotImplementedException();
            List<string> matchword = new List<string>()
            {
               
            "打","手",
            "吃","口",
            "英","艸",
            "國","囗",
            "他","人",
            "江","水",
            "板","木",
            "快","心",
            "好","女",
            "煮","火",
            "大","天",
            "早","日",
            "會","曰",
            "有","月",
            "次","欠",
            "步","止",
            "爭","爪",
            "飯","食",
            };
            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
             {
                int index = random.Next(matchword.Count);
                string nextword = matchword[index];
                textBlock.Text = nextword;
                matchword.RemoveAt(index);
             }
        }
    }
}
