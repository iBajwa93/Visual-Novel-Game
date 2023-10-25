using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using static Visual_Novel_Final_Project.Male_Creation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Visual_Novel_Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class Scenerio3 : Page
    {

        public Scenerio3()
        {
            this.InitializeComponent();

        }

        //OnNavigatedTo() function allows us to recieve transferred parameters from a previous page (such as character from MainPage.xaml, in this case)


        //Set to be transferred to other pages
        public class Sc3Character
        {
            public Sc3Character() { }
            public string ArmorPath { get; set; }
            public string FacePath { get; set; }
            public string HandsPath { get; set; }
            public string HairPath { get; set; }
            public string UniqueHairPath { get; set; }
            public string WeaponPath { get; set; }
            public string pName { get; set; }
            public string pGender { get; set; }
            public int pKarma { get; set; }
        }

        //New global object and class created, with attributes shared by previous parameters from the creation page, now it's able to transferred  to the next page
        //this will help the karma points to develop over each scene while maintaining the player's original appearence choices.

        PlayerCreation Scenerio3Player = new PlayerCreation();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            //base.OnNavigatedTo will accept the transferred class object from the creation page

            base.OnNavigatedTo(e);


            //PlayerParemeters variable accepts the attributes from the creation page and transfers them to the created object of this scenerio

            var Scenerio2Player = (PlayerCreation)e.Parameter;

            //Parameters are now being mapped to the new object so it can be transferred over

            Scenerio3Player.pName = Scenerio2Player.pName;

            Scenerio3Player.pGender = Scenerio2Player.pGender;

            Scenerio3Player.pKarma = Scenerio2Player.pKarma;

            Scenerio3Player.ArmorPath = Scenerio2Player.ArmorPath;

            tblkKarmaPoints.Text = Scenerio3Player.pKarma.ToString();


            Armor.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio3Player.ArmorPath))

            };

            Scenerio3Player.HairPath = Scenerio2Player.HairPath;

            Hair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio3Player.HairPath))

            };

            Scenerio3Player.UniqueHairPath = Scenerio2Player.UniqueHairPath;


            UniqueHair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio3Player.UniqueHairPath))

            };

            Scenerio3Player.FacePath = Scenerio2Player.FacePath;


            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio3Player.FacePath))

            };

            //Weapon.Fill = new ImageBrush()
            //{
            //    ImageSource = new BitmapImage(new Uri(PlayerParameters.WeaponPath))

            //};


            Scenerio3Player.HandsPath = Scenerio2Player.HandsPath;

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio3Player.HandsPath))

            };

            //different genders dictate different pronouns used

            if (Scenerio3Player.pGender == "Male")
            {
                tblkDefaultText.Text = Scenerio3Player.pName + " begins his jouney towards the tower, on a quest to rescue the captured princess. " + Scenerio3Player.pName + " knows that time is of the essence, but all he has is his legs… how will he proceed? ";
            }

            if (Scenerio3Player.pGender == "Female")
            {
                tblkDefaultText.Text = Scenerio3Player.pName + " begins her jouney towards the tower, on a quest to rescue the captured princess. " + Scenerio3Player.pName + " knows that time is of the essence, but all she has is her legs… how will she proceed? ";
            }

        }

        private void btnDice_Click(object sender, RoutedEventArgs e)
        {
            //make altered text gender neutral, easier without any if conditions 


            btnDice.IsEnabled = false;

            btnNextSlide.Visibility = Visibility.Visible;


            int Karma_Point;

            int GoalNum = int.Parse(tblkGoal.Text);

            Random diceRoll = new Random();

            int DicelNum = diceRoll.Next(1, 7);

            tblkPlayerRoll.Text = DicelNum.ToString();

            if (DicelNum < GoalNum)
            {
                tblkAlteredTextBad.Text = "Being no stranger to crime, " + Scenerio3Player.pName + " ambushes the first noble that passes by and steals his horse!";

                Karma_Point = -1;
                Scenerio3Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio3Player.pKarma.ToString();

            }

            if (DicelNum == GoalNum)
            {
                tblkAlteredTextNeutral.Text = "Walking is tough, but stealing is tough too.  " + Scenerio3Player.pName + " decides to take the civilized approach and wait hours for a carriage to pass by.";
                Karma_Point = 0;
                Scenerio3Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio3Player.pKarma.ToString();

            }

            if (DicelNum > GoalNum)
            {
                tblkAlteredTextGood.Text = " Legs is all this hero needs!  " + Scenerio3Player.pName + "  begins trekking towards the tower with great urgency, not taking a moment’s rest while the princess is in danger.";
                Karma_Point = +1;
                Scenerio3Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio3Player.pKarma.ToString()
;
            }
        }

        private void btnNextSlide_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Scenerio4), Scenerio3Player);

        }
    }
}
