using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
             
            NewGame();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's turn (O)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

        #endregion

        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>
        private void NewGame()
        {
            //Create a new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i<mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;

                //Make sure Player 1 starts the game
                mPlayer1Turn = true;

                //Iterate every button on the grid
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    //Change background, foreground and content to default values
                    button.Content = string.Empty;
                    button.Background = Brushes.White;
                    button.Foreground = Brushes.Blue;
                });

                //Make sure the game hasn't finished
                mGameEnded = false;
            }
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button was clicked</param>
        /// <param name="e">The events of the click</param>

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //Start a new game on the click after it's finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            //Cast the sender to a button
            var button= (Button)sender;

            //Find the button positions in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            //Don't do anything if there is a value in it
            if (mResults[index] != MarkType.Free)
                return;

            //Set the cell value based on which players turn it is
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            //Set button text to the result
            button.Content = mPlayer1Turn ? "X" : "O";

            //Change noughts to green
            if (!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }

            //Bitwise statement which will invert the value
            mPlayer1Turn ^= true;

            //Check for a winner
            CheckForWinner();
        }

        /// <summary>
        /// Check for a winner of a three line streak
        /// </summary>
        private void CheckForWinner()
        {
            #region Horizontal Wins
            //Check for horizontal wins
            ///
            ///Row 0
            ///
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn0_0.Background = btn1_0.Background = btn2_0.Background = Brushes.Green;
            }
            ///
            ///Row 1
            ///
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn0_1.Background = btn1_1.Background = btn2_1.Background = Brushes.Green;
            }
            ///
            ///Row 2
            ///
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn0_2.Background = btn1_2.Background = btn2_2.Background = Brushes.Green;
            }
            #endregion

            #region Vertical Wins
            //Check for vertical wins
            ///
            ///Column 0 
            ///
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn0_0.Background = btn0_1.Background = btn0_2.Background = Brushes.Green;
            }
            ///
            ///Column 1
            ///
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn1_0.Background = btn1_1.Background = btn1_2.Background = Brushes.Green;
            }
            ///
            ///Column 2 
            ///
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn2_0.Background = btn2_1.Background = btn2_2.Background = Brushes.Green;
            }
            #endregion

            #region Diagonal Wins

            //Check for diagonal wins
            ///
            ///Top Left - Bottom Right
            ///
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn0_0.Background = btn1_1.Background = btn2_2.Background = Brushes.Green;
            }
            ///
            ///Top Right - Bottom Right 
            ///
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                //Highlight winning cells in green
                btn0_2.Background = btn1_1.Background = btn2_0.Background = Brushes.Green;
            }

            #endregion
            //Check for no winner and full board 
            if (!mResults.Any(result=> result == MarkType.Free))
            {
                //Game ended
                mGameEnded = true;

                //Turn all cells orange
                //Iterate every button on the grid
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                });
            }
        }
    }
}
