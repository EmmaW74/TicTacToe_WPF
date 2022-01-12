﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe_WPF.Commands;

//TO DO LIST
//Tidy code
//Review public/private
//Look at template bookmark for disabled button style
//Look at creating a style for the buttons (inc rounded corners for start button)
//Sort colours - diff colour for x and o? 

namespace TicTacToe_WPF.ViewModel
{
    public class TicTacToeVM: INotifyPropertyChanged
    {     
        private UserPlayer User1 { get; set; }
        private Player User2 { get; set; }
        public Grid GameGrid { get; set; }
        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get
            {
                return currentPlayer;
            }
            set
            {
                currentPlayer = value;

                UpdateCommentary(currentPlayer.TakeTurnText);
            }
        }
        private string commentary;
        public string Commentary
        {
            get { return commentary; }
            set
            {
                commentary = value;
                OnPropertyChanged("Commentary");
            }
        }
        private bool gameRunning;
        public bool GameRunning
        {
            get { return gameRunning; }
            set
            {
                gameRunning = value;
                //OnPropertyChanged("GameRunning");

            }
        }
        private bool awaitingStart;
        public bool AwaitingStart
        {
            get { return awaitingStart; }
            set
            {
                awaitingStart = value;
                OnPropertyChanged("AwaitingStart");
                
            }
        }
        private bool showCommentary;
        public bool ShowCommentary
        {
            get { return showCommentary; }
            set
            {
                showCommentary = value;
                OnPropertyChanged("ShowCommentary");

            }
        }
        public ButtonClickCommand ButtonClickCommand { get; set; }
        public StartButtonCommand StartButtonCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public TicTacToeVM()
        {
            User1 = new UserPlayer("Emma");
            GameGrid = new Grid();
            User2 = new ComputerPlayer();
            CurrentPlayer = User1;
            ButtonClickCommand = new ButtonClickCommand(this);
            AwaitingStart = true;
            StartButtonCommand = new StartButtonCommand(this);
            ShowCommentary = false;
            GameRunning = false;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RunGame()
        {
            AwaitingStart = false;
            ShowCommentary = true;
            GameRunning = true;
            UpdateCommentary(CurrentPlayer.TakeTurnText); 
        }

        public void UpdateCommentary(string newText)
        {
            Commentary = newText;
        }
             

        public async void TakeTurn(int chosenCell)
        {
            bool turnComplete = false;
            int turn;
            while (!turnComplete)
            {
                //Update grid & check for win
                if (CurrentPlayer == User1)
                {
                    turn = chosenCell;
                }
                else
                {
                    turn = CurrentPlayer.GetChoiceOfCell();
                }

                if (GameGrid.UpdateGridTest(turn, CurrentPlayer))
                {
                    WinOrDraw result = GameGrid.CheckWinOrDraw();
                    if (result == WinOrDraw.WIN)
                    {
                        UpdateCommentary(CurrentPlayer.GameWonText);
                        turnComplete = true;
                        GameRunning = false;
                    }
                    else if (result == WinOrDraw.DRAW)
                    {
                        UpdateCommentary(CurrentPlayer.DrawText);
                        turnComplete = true;
                        GameRunning = false;
                    }
                    else
                    {
                        if (CurrentPlayer == User1)
                        {

                            CurrentPlayer = User2;
                            
                            UpdateCommentary(CurrentPlayer.TakeTurnText);
                            await Task.Delay(3000);
                            CommandManager.InvalidateRequerySuggested();


                        }
                        else
                        {
                            CurrentPlayer = User1;
                            turnComplete = true;
                            
                        }
                        
                    }
                }
                else
                {
                    UpdateCommentary(CurrentPlayer.TryAgainText);
                    if (CurrentPlayer == User1)
                    {
                        turnComplete = true;
                        //return false;
                    }
                   
                }
                
            }
            //return true;
           
        }





    }
}
