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
using System.Threading;
using TicTacToe_WPF.ViewModel;

namespace TicTacToe_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public delegate void MyDelegate(object sender, RoutedEventArgs e);
    public delegate void UpdateTextDelegate(string newString);

    public partial class MainWindow : Window
    {
        public MainWindow AppWindow;
        //private GameController newGame;
        //public MyDelegate myDel;

        public TicTacToeVM newGame;
        public MainWindow()
        {
            //InitializeComponent();
            newGame = new TicTacToeVM();
            //newGame.RunGame();
            InitializeComponent();
        }
        /*
        public MainWindow()
        {
            AppWindow = this;
            this.myDel = new MyDelegate(AppWindow.turn_Click);
            InitializeComponent();
            newGame = new GameController(AppWindow);
            newGame.RunGame();
            
        }
              
        
        public void UpdateCommentary(string newText)
        {
            commentary.Text = newText;
        } 

        public void turn_Click(object sender, RoutedEventArgs e)
        {

            string userTurn = (sender as Button).Tag.ToString();
            ThreadStart start = delegate ()
            {
                /*if (newGame.HandleUserTurn(Int32.Parse(userTurn)))
                {
                    Thread.Sleep(3000);
                    
                    newGame.HandleComputerTurn();
                    
                }
                if (newGame.gameRunning)
                {
                    newGame.HandleUserTurn(Int32.Parse(userTurn));
                }

                Thread.Sleep(3000);
                if (newGame.gameRunning)
                {
                    newGame.HandleComputerTurn();
                }


            };
            new Thread(start).Start();
            
            //Thread.Sleep(1000);
            
            
        }
       
        public void UpdateButton(string tag, Token token)
        {
            foreach (var x in MyGrid.Children.OfType<Button>())
            {
                if ((x.Tag).ToString() == tag)
                {
                    x.Content = token;
                }
            }
        }

        public void UpdateTextHelper(Action action)
        {
            
                if (!Dispatcher.CheckAccess())
                    Dispatcher.BeginInvoke(action);
                else
                    action.Invoke();
            
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetGame()
        {
            foreach (Control element in MyGrid.Children)
            {
               if (element.GetType().ToString() == "Button")
                {
                    (element as Button).Content = "";
                }
            }

            UpdateCommentary("");
    
        } */

    }
}
