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
    public partial class Scenerio5 : Page
    {

        public Scenerio5()
        {
            this.InitializeComponent();

        }

        //OnNavigatedTo() function allows us to recieve transferred parameters from a previous page (such as character from MainPage.xaml, in this case)


        //Set to be transferred to other pages
        public class Sc5Character
        {
            public Sc5Character() { }
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

        PlayerCreation Scenerio5Player = new PlayerCreation();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            //base.OnNavigatedTo will accept the transferred class object from the creation page

            base.OnNavigatedTo(e);


            //PlayerParemeters variable accepts the attributes from the creation page and transfers them to the created object of this scenerio

            var Scenerio4Player = (PlayerCreation)e.Parameter;

            //Parameters are now being mapped to the new object so it can be transferred over

            Scenerio5Player.pName = Scenerio4Player.pName;

            Scenerio5Player.pGender = Scenerio4Player.pGender;

            Scenerio5Player.pKarma = Scenerio4Player.pKarma;

            Scenerio5Player.ArmorPath = Scenerio4Player.ArmorPath;

            tblkKarmaPoints.Text = Scenerio5Player.pKarma.ToString();


            Armor.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio5Player.ArmorPath))

            };

            Scenerio5Player.HairPath = Scenerio4Player.HairPath;

            Hair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio5Player.HairPath))

            };

            Scenerio5Player.UniqueHairPath = Scenerio4Player.UniqueHairPath;


            UniqueHair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio5Player.UniqueHairPath))

            };

            Scenerio5Player.FacePath = Scenerio4Player.FacePath;


            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio5Player.FacePath))

            };

            //Weapon.Fill = new ImageBrush()
            //{
            //    ImageSource = new BitmapImage(new Uri(PlayerParameters.WeaponPath))

            //};


            Scenerio5Player.HandsPath = Scenerio4Player.HandsPath;

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri(Scenerio5Player.HandsPath))

            };

            //different genders dictate different pronouns used

            if (Scenerio5Player.pGender == "Male")
            {
                tblkDefaultText.Text = "The princess thanks " + Scenerio5Player.pName + "  and reveals that dragon kept her captured because her power was the only thing that could prevent the use of the sceptor.\n By doing so he was free to do what he wanted....until someone put a stop to him.";
            }

            if (Scenerio5Player.pGender == "Female")
            {
                tblkDefaultText.Text = "The princess thanks " + Scenerio5Player.pName + "  and reveals that dragon kept her captured because her power was the only thing that could prevent the use of the sceptor.\n By doing so he was free to do what he wanted....until someone put a stop to him.";
            }

        }

//        private void btnDice_Click(object sender, RoutedEventArgs e)
//        {
//            //make altered text gender neutral, easier without any if conditions 


//            btnDice.IsEnabled = false;

//            btnNextSlide.Visibility = Visibility.Visible;


//            int Karma_Point;

//            int GoalNum = int.Parse(tblkGoal.Text);

//            Random diceRoll = new Random();

//            int DicelNum = diceRoll.Next(1, 7);

//            if (DicelNum < GoalNum)
//            {
//                tblkAlteredTextBad.Text = "A devious " + Scenerio5Player.pName + " pretends to be  a member of the dragon cult. By winning the Dragon’s trust and waiting till he  goes to sleep… " + Scenerio4Player.pName + " stabs the defenseless dragon in the back! How trecherous!";

//                Karma_Point = -1;
//                Scenerio5Player.pKarma += Karma_Point;
//                tblkKarmaPoints.Text = Scenerio5Player.pKarma.ToString();

//            }

//            if (DicelNum == GoalNum)
//            {
//                tblkAlteredTextNeutral.Text = Scenerio5Player.pName + " is losing terribly and backs up against a balcony, the big fat Dragon charges to finish our challenger off. Just then " + Scenerio4Player.pName + " trips on the floor and the Dragon ends up charging head-first over the balcony…. the dragon was too fat for his wings.";
//                Karma_Point = 0;
//                Scenerio5Player.pKarma += Karma_Point;
//                tblkKarmaPoints.Text = Scenerio5Player.pKarma.ToString();

//            }

//            if (DicelNum > GoalNum)
//            {
//                tblkAlteredTextGood.Text = Scenerio5Player.pName + " takes a stance and gets ready for the challenge at hand. By charging into battle and attacking with the strength of a titan. The dragon falls to the sheer prowress of a warrior and the princess falls into the arms of a hero. Well done " + Scenerio4Player.pName + "!";
//                Karma_Point = +1;
//                Scenerio5Player.pKarma += Karma_Point;
//                tblkKarmaPoints.Text = Scenerio5Player.pKarma.ToString()
//;
//            }
//        }

        private void btnNextSlide_Click(object sender, RoutedEventArgs e)
        {
            //Karma gets totaled in the end to decide which ending the player gets

            if (Scenerio5Player.pKarma > 0)
            {
                Frame.Navigate(typeof(GoodEnding), Scenerio5Player);
            }

            else if(Scenerio5Player.pKarma == 0)
            {
                Frame.Navigate(typeof(NeutralEnding), Scenerio5Player);
            }

            else if (Scenerio5Player.pKarma < 0)
            {
                Frame.Navigate(typeof(BadEnding), Scenerio5Player);
            }

        }
    }
}
