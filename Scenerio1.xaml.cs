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
    public  partial class Scenerio1 : Page
    {

        public Scenerio1()
        {
            this.InitializeComponent();

        }

        //OnNavigatedTo() function allows us to recieve transferred parameters from a previous page (such as character from MainPage.xaml, in this case)


        //Set to be transferred to other pages
        public class Sc1Character
        {
            public Sc1Character() { }
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

        PlayerCreation Scenerio1Player = new PlayerCreation();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            //base.OnNavigatedTo will accept the transferred class object from the creation page

            base.OnNavigatedTo(e);

            
            //PlayerParemeters variable accepts the attributes from the creation page and transfers them to the created object of this scenerio

            var PlayerParameters = (PlayerCreation)e.Parameter;

            //Parameters are now being mapped to the new object so it can be transferred over

            Scenerio1Player.pName = PlayerParameters.pName;

            Scenerio1Player.pGender = PlayerParameters.pGender;

            Scenerio1Player.pKarma = PlayerParameters.pKarma;

            Scenerio1Player.ArmorPath =  PlayerParameters.ArmorPath;

            Armor.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio1Player.ArmorPath))

            };

            Scenerio1Player.HairPath = PlayerParameters.HairPath;

            Hair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio1Player.HairPath))

            };

            Scenerio1Player.UniqueHairPath = PlayerParameters.UniqueHairPath;


            UniqueHair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio1Player.UniqueHairPath))

            };

            Scenerio1Player.FacePath = PlayerParameters.FacePath;


            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio1Player.FacePath))

            };

            //Weapon.Fill = new ImageBrush()
            //{
            //    ImageSource = new BitmapImage(new Uri(PlayerParameters.WeaponPath))

            //};


            Scenerio1Player.HandsPath = PlayerParameters.HandsPath;

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio1Player.HandsPath))

            };

            //different genders dictate different pronouns used

            if (Scenerio1Player.pGender == "Male")
            {
                tblkDefaultText.Text = "Once upon a time " + PlayerParameters.pName + " passed a road. Where he discovered a merchant lying under his cart, trapped. The merchant pleaded 'Help brave hero! Bandits attacked me and ran off with all my items and left me here! If you can get my items back I will reward you!'. ";
            }

            if (Scenerio1Player.pGender == "Female")
            {
                tblkDefaultText.Text = "Once upon a time " + PlayerParameters.pName + " passed a road. Where she discovered a merchant lying under his cart, trapped. The merchant pleaded 'Help brave hero! Bandits attacked me and ran off with all my items and left me here! If you can get my items back I will reward you!'. ";
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
                tblkAlteredTextBad.Text = "You decided to laugh at the merchant and steal the rest of his wares!";

                Karma_Point = -1;
                Scenerio1Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio1Player.pKarma.ToString();

            }

            if (DicelNum == GoalNum)
            {
                tblkAlteredTextNeutral.Text = "You decided to walk off without acknowledging the trapped merchant.";
                Karma_Point = 0;
                Scenerio1Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio1Player.pKarma.ToString();

            }

            if (DicelNum > GoalNum)
            {
                tblkAlteredTextGood.Text = "You decided to lift the merchant out from under his cart and announce that you will retrieve his wares!";
                Karma_Point = +1;
                Scenerio1Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio1Player.pKarma.ToString()
;
            }
        }

        private void btnNextSlide_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Scenerio2), Scenerio1Player);

        }
    }
}
