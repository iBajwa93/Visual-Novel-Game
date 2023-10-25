using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Visual_Novel_Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class Female_Creation : Page
    {


        //Set to be transferred to other pages
        public class FemalePlayerCreation
        {
            public FemalePlayerCreation() { }
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

        //New object created, with attributes ready to be filled depending on player choices

        FemalePlayerCreation PlayerParameters = new FemalePlayerCreation();


        public Female_Creation()
        {
            this.InitializeComponent();


        }




        private void chkHeavyArmor_Checked(object sender, RoutedEventArgs e)
        {



            if (chkHeavyArmor.IsChecked == true)
            {
                chkLightArmor.IsChecked = false;

                Armor.Fill = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Heavy_Armor_F.png"))

                };

                PlayerParameters.ArmorPath = "ms-appx:/Character_Parts/Female/Heavy_Armor_F.png";


            }

            if (chkHeavyArmor.IsChecked == true)
            {

                if (chkNormalHair.IsChecked == true || chkUniqueHair.IsChecked == true)
                {
                    btnNextSlide.Visibility = Visibility.Visible;
                }
            }
        }

        private void chkLightArmor_Checked(object sender, RoutedEventArgs e)
        {


            if (chkLightArmor.IsChecked == true)
            {
                chkHeavyArmor.IsChecked = false;

                Armor.Fill = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Suave_Coat_F.png"))
                };

                PlayerParameters.ArmorPath = "ms-appx:/Character_Parts/Female/Suave_Coat_F.png";

            }

            if (chkHeavyArmor.IsChecked == true)
            {

                if (chkNormalHair.IsChecked == true || chkUniqueHair.IsChecked == true)
                {
                    btnNextSlide.Visibility = Visibility.Visible;
                }
            }
        }

        private void chkUniqueHair_Checked(object sender, RoutedEventArgs e)
        {
            if (chkUniqueHair.IsChecked == true)
            {
                chkNormalHair.IsChecked = false;

                if (chkSkinHollow.IsChecked == true)
                {
                    UniqueHair.Fill = new ImageBrush()
                    {
                        ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Ponytail_haircut_F.png"))
                    };

                    PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Female/Ponytail_haircut_F.png";


                    //Filling the HairPath with an empty png prevents a crash
                    PlayerParameters.HairPath = "ms-appx:/Character_Parts/Male/Empty.png";

                }

                else if (chkSkin1.IsChecked == true)
                {
                    UniqueHair.Fill = new ImageBrush()
                    {
                        ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Ponytail_haircut_F.png"))
                    };

                    PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Male/Female/Ponytail_haircut_F.png";
                    PlayerParameters.HairPath = "ms-appx:/Character_Parts/Male/Empty.png";

                }
                else if (chkSkin2.IsChecked == true)
                {
                    UniqueHair.Fill = new ImageBrush()
                    {
                        ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Ponytail_haircut_F.png"))
                    };

                    PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Female/Ponytail_haircut_F.png";
                    PlayerParameters.HairPath = "ms-appx:/Character_Parts/Male/Empty.png";

                }
                else if (chkSkin3.IsChecked == true)
                {
                    UniqueHair.Fill = new ImageBrush()
                    {
                        ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Ponytail_haircut_F.png"))
                    };

                    PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Female/Ponytail_haircut_F.png";
                    PlayerParameters.HairPath = "ms-appx:/Character_Parts/Male/Empty.png";

                }

            }

            if (chkUniqueHair.IsChecked == true)
            {

                if (chkHeavyArmor.IsChecked == true || chkLightArmor.IsChecked == true)
                {
                    btnNextSlide.Visibility = Visibility.Visible;
                }
            }
        }

        private void chkNormalHair_Checked(object sender, RoutedEventArgs e)
        {

            if (chkUniqueHair.IsChecked == true)
            {
                tblkNormalHair.Visibility = Visibility.Collapsed;
                btnBlackHair.Visibility = Visibility.Collapsed;
                btnBrownHair.Visibility = Visibility.Collapsed;
                btnBlondeHair.Visibility = Visibility.Collapsed;
            }

            if (chkNormalHair.IsChecked == true)
            {
                chkUniqueHair.IsChecked = false;

                Hair.Fill = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/MopHead_haircut_Black_F.png"))
                };

                PlayerParameters.HairPath = "ms-appx:/Character_Parts/Female/MopHead_haircut_Black_F.png";

                PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Male/Empty.png";


                tblkNormalHair.Visibility = Visibility.Visible;
                btnBlackHair.Visibility = Visibility.Visible;
                btnBrownHair.Visibility = Visibility.Visible;
                btnBlondeHair.Visibility = Visibility.Visible;

            }


            if (chkNormalHair.IsChecked == true)
            {

                if (chkHeavyArmor.IsChecked == true || chkLightArmor.IsChecked == true)
                {
                    btnNextSlide.Visibility = Visibility.Visible;
                }
            }

        }

        private void btnBlondeHair_Click(object sender, RoutedEventArgs e)
        {
            Hair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/MopHead_haircut_Blonde_F.png"))
            };

            PlayerParameters.HairPath = "ms-appx:/Character_Parts/Female/MopHead_haircut_Blonde_F.png";

            //Filling the UniqueHairPath with an empty png prevents a crash

            PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Male/Empty.png";

        }

        private void btnBrownHair_Click(object sender, RoutedEventArgs e)
        {
            Hair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/MopHead_haircut_Brown_F.png"))
            };
            PlayerParameters.HairPath = "ms-appx:/Character_Parts/Female/MopHead_haircut_Brown_F.png";
            PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Male/Empty.png";

        }

        private void btnBlackHair_Click(object sender, RoutedEventArgs e)
        {
            Hair.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/MopHead_haircut_Black_F.png"))
            };
            PlayerParameters.HairPath = "ms-appx:/Character_Parts/Female/MopHead_haircut_Black_F.png";
            PlayerParameters.UniqueHairPath = "ms-appx:/Character_Parts/Male/Empty.png";

        }


        private void chkSkin1_Checked(object sender, RoutedEventArgs e)
        {

            chkSkin2.IsChecked = false;
            chkSkin3.IsChecked = false;
            chkSkinHollow.IsChecked = false;

            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Face_Peach.png"))
            };

            PlayerParameters.FacePath = "ms-appx:/Character_Parts/Female/Female_Face_Peach.png";

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Hands_Peach.png"))
            };
            PlayerParameters.HandsPath = "ms-appx:/Character_Parts/Female/Female_Hands_Peach.png";



        }

        private void chkSkin2_Checked(object sender, RoutedEventArgs e)
        {
            chkSkin1.IsChecked = false;
            chkSkin3.IsChecked = false;
            chkSkinHollow.IsChecked = false;

            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Face_Tan.png"))
            };

            PlayerParameters.FacePath = "ms-appx:/Character_Parts/Female/Female_Face_Tan.png";

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Hands_Tan.png"))
            };
            PlayerParameters.HandsPath = "ms-appx:/Character_Parts/Female/Female_Hands_Tan.png";

        }

        private void chkSkin3_Checked(object sender, RoutedEventArgs e)
        {

            chkSkin1.IsChecked = false;
            chkSkin2.IsChecked = false;
            chkSkinHollow.IsChecked = false;

            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Face_Dark.png"))
            };

            PlayerParameters.FacePath = "ms-appx:/Character_Parts/Female/Female_Face_Dark.png";

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Hands_Dark.png"))
            };

            PlayerParameters.HandsPath = "ms-appx:/Character_Parts/Female/Female_Hands_Dark.png";
        }


        private void chkSkinHollow_Checked(object sender, RoutedEventArgs e)
        {
            chkSkin1.IsChecked = false;
            chkSkin2.IsChecked = false;
            chkSkin3.IsChecked = false;

            Face.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Face.png"))
            };

            PlayerParameters.FacePath = "ms-appx:/Character_Parts/Female/Female_Face.png";

            Hands.Fill = new ImageBrush()
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:/Character_Parts/Female/Female_Hands.png"))
            };

            PlayerParameters.HandsPath = "ms-appx:/Character_Parts/Female/Female_Hands.png";

        }

        private void btnRandomize_Click(object sender, RoutedEventArgs e)
        {


            var randomName = new Random();

            var mFirstNameList = new List<string> { "Maria", "Shura", "Buxom", "Vamp", "Shadow", "Leah", "Rayne", "Karen", "Astrid", "Mouse", "Raven", "Holly",
                "Blaze", "Light", "Talon", "Foxy", "Mary", "Marrow", "Elise", "Samantha", "Claudia", "Ali", "Eli", "Rinabi", "Sakura" };


            var mLastNameList = new List<string> { "Widow", "Crimson", "Lee", "BiggleBottom", "Sue", "Steelhaven", "BloodyClaw", "Gazelle", "Fox", "The Devoted",
                "The Stupid", "The Genius", "The Sexy", "The Wrathful", "The Loathsome", "The Awakened", "The Shunned" };


            int FirstNameSelection = randomName.Next(mFirstNameList.Count);


            tbxFirstName.Text = mFirstNameList[FirstNameSelection];

            int LastNameSelection = randomName.Next(mLastNameList.Count);

            tbxLastName.Text = mLastNameList[LastNameSelection];



        }


        //This stackpanel of a back button within a stack panel Frame helps make this back button persist across multiple xaml pages

        private void btnNextSlide_Click(object sender, RoutedEventArgs e)
        {




            PlayerParameters.pName = tbxFirstName.Text + " " + tbxLastName.Text;

            PlayerParameters.pGender = "Female";

            PlayerParameters.pKarma = 0;


            //The class object created by the user will transfer over into the story scenerio .xaml files


            Frame.Navigate(typeof(Scenerio1), PlayerParameters);

        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {



            Frame.Navigate(typeof(MainPage));
        }


    }


}