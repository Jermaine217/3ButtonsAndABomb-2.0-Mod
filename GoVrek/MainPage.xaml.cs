using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoVrek
{

    public partial class MainPage : ContentPage
    {

        static string bomb = new Random().Next(1, 7).ToString();

        string[] bombs;

        static int scores = 0;
        public MainPage()
        {
            InitializeComponent();

            SetupBombs();
        }

        private void SetupBombs()
        {
            bombs = new string[2];

            for(int index=0; index < bombs.Length;index++)
                bombs[index] = new Random().Next(1, 7).ToString();
        }

        private bool IsBoom(string checkBomb)
        {
            for (int index = 0; index < bombs.Length; index++)
                if (bombs[index] == checkBomb)
                    return true;

            return false;
        }

        async void ButtonClicked(object sender, EventArgs e)
        {

            Button button = sender as Button;

            if (IsBoom(button.Text))
            {
                scores = 0;

                await DisplayAlert("Bomb Exploded", "Go Home Noob", "Or Try Again");
                SetupBombs();
            }
            else
            {
                scores += 1;

                await DisplayAlert("Bomb Defused!", "Score " + scores, "Continue");
                SetupBombs();
             
            }
        }
    }
}
