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
    public partial class MainWindow : Window
    {
        public MainWindow AppWindow;
        private GameController newGame;

        
        public MainWindow()
        {
            InitializeComponent();
            newGame = new GameController(AppWindow);
            newGame.RunGame();
            //AppWindow = this;

        }

        public void UpdateCommentary(string newText)
        {
            commentary.Text = newText;
        }

        private void turn_Click(object sender, RoutedEventArgs e)
        {
            string turn = (sender as Button).Tag.ToString();
            if (newGame.ValidateTurn(Int32.Parse(turn)))
            {
                (sender as Button).Content = newGame.CurrentPlayer.NoughtOrCross.ToString();
                UpdateCommentary(newGame.CheckForWin());
            } else
            {
                UpdateCommentary(newGame.CurrentPlayer.TryAgainText);
            }
            HandleComputerTurn();
            //newGame.ValidateTurn(newGame.CurrentPlayer.GetChoiceOfCell());

        
        }

        private void HandleComputerTurn()
        {

            UpdateCommentary(newGame.CurrentPlayer.TakeTurnText);
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
            
        }

        private void UpdateButton(string tag, Token token)
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
