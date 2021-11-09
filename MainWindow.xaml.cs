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


namespace TicTacToe_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public delegate void MyDelegate(object sender, RoutedEventArgs e);

    public partial class MainWindow : Window
    {
        public MainWindow AppWindow;
        private GameController newGame;
        public MyDelegate myDel;


        public MainWindow()
        {
            //InitializeComponent();
            AppWindow = this;
            this.myDel = new MyDelegate(AppWindow.turn_Click);
            InitializeComponent();
            //AppWindow = this;
            newGame = new GameController(AppWindow);
            newGame.RunGame();
            
            
        }
              

        public void UpdateCommentary(string newText)
        {
            commentary.Text = newText;
        }

        public async void turn_Click(object sender, RoutedEventArgs e)
        {

            string turn = (sender as Button).Tag.ToString();

            await newGame.HandleTurn(Int32.Parse(turn));
            Thread.Sleep(500);
            await newGame.HandleComputerTurn();
            
        
        }
        /*
        private void HandleComputerTurn()
        {
            newGame.HandleComputerTurn();
            /* UpdateCommentary(newGame.CurrentPlayer.TakeTurnText);
             Thread.Sleep(300);
             int turn = newGame.CurrentPlayer.GetChoiceOfCell(); //get turn
             bool validTurn = false;
             while (!validTurn)
             {
                 if (newGame.ValidateTurn(turn))
                 {
                     //need method to update button content & 
                     UpdateButton(turn.ToString(), newGame.CurrentPlayer.NoughtOrCross);
                     UpdateCommentary(newGame.CheckForWin());
                     validTurn = true;
                 }
                 else
                 {
                     //try taking turn again
                     turn = newGame.CurrentPlayer.GetChoiceOfCell();
                 }
             }
             
        }*/

        //public void UpdateButton(string tag, Token token)
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

       
    }
}
