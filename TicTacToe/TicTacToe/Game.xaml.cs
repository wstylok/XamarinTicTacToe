using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Game : ContentPage
	{
		public Game ()
		{
			InitializeComponent ();
		}

        bool turn = true; // true - X turn, false - O turn

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
                NowMoves.Text = $"Now O has a turn";
            }
            else
            {
                b.Text = "O";
                NowMoves.Text = $"Now X has a turn";
            }
            turn = !turn;
            b.IsEnabled = false;

            TheWinnerIs();
        }

        private void TheWinnerIs()
        {
            bool weHaveTheWinner = false;

            if (b1.Text == b2.Text && b2.Text == b3.Text && b3.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b4.Text == b5.Text && b5.Text == b6.Text && b6.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b7.Text == b8.Text && b8.Text == b9.Text && b9.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b1.Text == b4.Text && b4.Text == b7.Text && b7.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b2.Text == b5.Text && b5.Text == b8.Text && b8.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b3.Text == b6.Text && b6.Text == b9.Text && b9.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b1.Text == b5.Text && b5.Text == b9.Text && b9.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b3.Text == b5.Text && b5.Text == b7.Text && b7.IsEnabled == false)
            {
                weHaveTheWinner = true;
            }
            else if (b1.IsEnabled == false && b2.IsEnabled == false && b3.IsEnabled == false && b4.IsEnabled == false && b5.IsEnabled == false && b6.IsEnabled == false && b7.IsEnabled == false && b8.IsEnabled == false && b9.IsEnabled == false && weHaveTheWinner == false)
            {
                DisplayAlert("No winner!", "There is no winner, try again.", "OK");

                NowMoves.IsVisible = false;
                MainMenu.IsVisible = true;
                PlayAgain.IsVisible = true;
            }

            if (weHaveTheWinner)
            {
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                DisplayAlert("Gratulations!", $"The winner is {winner}", "OK");

                b1.IsEnabled = false;
                b2.IsEnabled = false;
                b3.IsEnabled = false;
                b4.IsEnabled = false;
                b5.IsEnabled = false;
                b6.IsEnabled = false;
                b7.IsEnabled = false;
                b8.IsEnabled = false;
                b9.IsEnabled = false;
                NowMoves.IsVisible = false;
                MainMenu.IsVisible = true;
                PlayAgain.IsVisible = true;
            }
        }

        async void PlayAgain_Clicked(object sender, EventArgs e)
        {
            var game = new Game();
            await Navigation.PushAsync(game);
        }

        async void MainMenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}