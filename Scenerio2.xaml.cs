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
    public partial class Scenerio2 : Page
    {

        public Scenerio2()
        {
            this.InitializeComponent();

        }

        //OnNavigatedTo() function allows us to recieve transferred parameters from a previous page (such as character from MainPage.xaml, in this case)


        //Set to be transferred to other pages
        public class Sc2Character
        {
            public Sc2Character() { }
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

        PlayerCreation Scenerio2Player = new PlayerCreation();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            //base.OnNavigatedTo will accept the transferred class object from the creation page

            base.OnNavigatedTo(e);


            //PlayerParemeters variable accepts the attributes from the creation page and transfers them to the created object of this scenerio

            var Scenerio1Player = (PlayerCreation)e.Parameter;

            //Parameters are now being mapped to the new object so it can be transferred over

            Scenerio2Player.pName = Scenerio1Player.pName;

            Scenerio2Player.pGender = Scenerio1Player.pGender;

            Scenerio2Player.pKarma = Scenerio1Player.pKarma;

            Scenerio2Player.ArmorPath = Scenerio1Player.ArmorPath;

            tblkKarmaPoints.Text = Scenerio2Player.pKarma.ToString();


            Armor.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio2Player.ArmorPath))

            };

            Scenerio2Player.HairPath = Scenerio1Player.HairPath;

            Hair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio2Player.HairPath))

            };

            Scenerio2Player.UniqueHairPath = Scenerio1Player.UniqueHairPath;


            UniqueHair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio2Player.UniqueHairPath))

            };

            Scenerio2Player.FacePath = Scenerio1Player.FacePath;


            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio2Player.FacePath))

            };

            //Weapon.Fill = new ImageBrush()
            //{
            //    ImageSource = new BitmapImage(new Uri(PlayerParameters.WeaponPath))

            //};


            Scenerio2Player.HandsPath = Scenerio1Player.HandsPath;

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio2Player.HandsPath))

            };

            //different genders dictate different pronouns used

            if (Scenerio2Player.pGender == "Male")
            {
                tblkDefaultText.Text = Scenerio2Player.pName + " located the bandits hideout only to find strange items used for draconic rituals. This is when he realized that these were no ordinary bandits, they were a dragon cult! They yell 'Who are you and what the hell do you want?' ";
            }

            if (Scenerio2Player.pGender == "Female")
            {
                tblkDefaultText.Text = Scenerio2Player.pName + " located the bandits hideout only to find strange items used for draconic rituals. This is when she realized that these were no ordinary bandits, they were a dragon cult! They yell 'Who are you and what the hell do you want?' ";
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
                tblkAlteredTextBad.Text = Scenerio2Player.pName + " decided to kill all the cultists without a word. After the slaughter you then read a letter on one of the bodies that mentions the princess of the kingdom is locked away in the Northern Tower. The letter also mentions a powerful sceptor that was given to their leader.";

                Karma_Point = -1;
                Scenerio2Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio2Player.pKarma.ToString();

            }

            if (DicelNum == GoalNum)
            {
                tblkAlteredTextNeutral.Text = Scenerio2Player.pName + " apologizes and leave, tripping on the way out. While on the floor, " + Scenerio2Player.pName + " pins an ear to the floor and hear a few cultists below mentioning that the princess is held captive in the Northern Tower and to fear a certain sceptor….";
                Karma_Point = 0;
                Scenerio2Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio2Player.pKarma.ToString();

            }

            if (DicelNum > GoalNum)
            {
                tblkAlteredTextGood.Text = Scenerio2Player.pName + " asks for the merchant’s wares, the cultists do not listen and a few attack. " + Scenerio2Player.pName + " defeats them with ease and spares the frightened ones. They mentioned one of the stolen artifacts was a sceptor specifically given to the dragon that has captured the princess in the Northern Tower.";
                Karma_Point = +1;
                Scenerio2Player.pKarma += Karma_Point;
                tblkKarmaPoints.Text = Scenerio2Player.pKarma.ToString()
;
            }
        }

        private void btnNextSlide_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Scenerio3), Scenerio2Player);

        }
    }
}