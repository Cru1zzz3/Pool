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

namespace Pool_normal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    static class myGlobal{

        public static double Mouse_X = .0;
        public static double Mouse_Y = .0;

        public static double Center_X = .0;
        public static double Center_Y = .0;

        public static double BC = .0;
        public static double CA = .0;

        public static double arctan = .0;
        public static double gradus = .0;

        public static bool stateOnBall = false;
        public static bool stateAim = false;
        public static bool stateOnField = false;

        public static bool firstClick = true;

        public static double ProgressSpeed = 20;
        public static int maxProgressValue = 300;

        public static int countOfPower = 0;

        public static bool onFieldLock = false;




    };

    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
    
           
            



        //    int row = Grid.GetRow(button1); // вторая строка
        //    int col = Grid.GetColumn(button1); // второй столбец
            
            
        }

        public class Balls {

      //  int Vx = this.Resources["DynamicPower"];
      //  int Vy = this.Resources["DynamicPower"] ;       
        };

        private void Progress_Bar()
        {
            if (myGlobal.stateOnField == true && myGlobal.onFieldLock == false && myGlobal.firstClick == false)
            {


                Outer_Power_Bar.Visibility = System.Windows.Visibility.Visible;

                if (myGlobal.onFieldLock == false)
                {
                    System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(myGlobal.ProgressSpeed);

                    int minValue = 0;
                    int maxValue = myGlobal.maxProgressValue;

                    Inner_Power_Bar.Height = minValue;
                    timer.Tick += (ss, ee) =>
                    {
                        myGlobal.onFieldLock = true;

                        if (Inner_Power_Bar.Height < maxValue)
                        {
                            Inner_Power_Bar.Height += 4;
                        }

                        if (Inner_Power_Bar.Height == maxValue)
                            maxValue = minValue;

                        if (Inner_Power_Bar.Height > maxValue)
                            Inner_Power_Bar.Height -= 4;

                        if (Inner_Power_Bar.Height == minValue)
                            maxValue = myGlobal.maxProgressValue;

                        if (myGlobal.stateOnField == false)
                        {
                            timer.Stop();
                            myGlobal.countOfPower--;
                            myGlobal.onFieldLock = false;
                        }

                        if (myGlobal.stateOnField == true)
                        {
                            Output_Power.SetResourceReference(TextBlock.TextProperty, "Dynamic_Power");
                            this.Resources["Dynamic_Power"] = Inner_Power_Bar.Height.ToString();
                        }
                        
                    };
                    timer.Start();
                }
            }
        }
            
        



         public void Mouse_On_Ball(object sender, MouseEventArgs e)
         {
             if (myGlobal.stateOnBall == true && myGlobal.stateAim == true)
                 myGlobal.firstClick = false;

             myGlobal.stateOnBall = true;




             Cue.Visibility = System.Windows.Visibility.Visible;


             Point centerPosition = e.GetPosition(this);

             myGlobal.Center_X = centerPosition.X;
             myGlobal.Center_Y = centerPosition.Y;

             this.Resources["Dynamic_Center_X"] = centerPosition.X.ToString();
             this.Resources["Dynamic_Center_Y"] = centerPosition.Y.ToString();

         }
          
   

         public void Mouse_On_Field(object sender, MouseEventArgs e)
         {

             if (myGlobal.stateOnBall == true && myGlobal.firstClick == false)
             {
                 myGlobal.stateOnField = true;
                 
             }
                    
             
             if (myGlobal.stateOnBall == true)
                    myGlobal.firstClick = false;



             if (e.LeftButton == MouseButtonState.Pressed && myGlobal.stateOnBall == true && myGlobal.stateAim == true && myGlobal.stateOnField == true && myGlobal.firstClick == false)
             {

                 if (myGlobal.stateOnBall == true && myGlobal.stateAim == true && myGlobal.stateOnField == true)
                 {
                     Progress_Bar();
                 }   
             }
   
         }

        
       
         
         public void Mouse_Aim(object sender, MouseEventArgs e)
         {
             myGlobal.stateAim = true;
 
             Point mousePosition = Mouse.GetPosition(this);

             myGlobal.Mouse_X = mousePosition.X;
             myGlobal.Mouse_Y = mousePosition.Y;




             Output_X.SetResourceReference(TextBlock.TextProperty, "Dynamic_Mouse_X");
             Output_Y.SetResourceReference(TextBlock.TextProperty, "Dynamic_Mouse_Y");


             this.Resources["Dynamic_Mouse_X"] = (mousePosition.X.ToString());
             this.Resources["Dynamic_Mouse_Y"] = (mousePosition.Y.ToString());

             // 1 square
             if  ( (myGlobal.Mouse_X <  myGlobal.Center_X) && (myGlobal.Mouse_Y < myGlobal.Center_Y)) 
             {
                 myGlobal.BC = ((myGlobal.Center_X) - (myGlobal.Mouse_X));
                 myGlobal.CA = ((myGlobal.Center_Y) - (myGlobal.Mouse_Y));

                 myGlobal.arctan = (myGlobal.CA / myGlobal.BC);

                 myGlobal.gradus = (Math.Atan(myGlobal.arctan) * 180) / Math.PI;
             }

             // 2 square
             if ((myGlobal.Mouse_X > myGlobal.Center_X) && (myGlobal.Mouse_Y < myGlobal.Center_Y))
             {
                 myGlobal.BC = (myGlobal.Mouse_X) - (myGlobal.Center_X);
                 myGlobal.CA = ((myGlobal.Center_Y) - (myGlobal.Mouse_Y));

                 myGlobal.arctan = ((-myGlobal.CA )/ myGlobal.BC);

                 myGlobal.gradus = ( 180 + ((Math.Atan(myGlobal.arctan) * 180) / Math.PI));
             }

             // 3 square
             if ((myGlobal.Mouse_X > myGlobal.Center_X) && (myGlobal.Mouse_Y > myGlobal.Center_Y))
             {
                 myGlobal.BC = (myGlobal.Mouse_X) - (myGlobal.Center_X);
                 myGlobal.CA = (myGlobal.Mouse_Y) - (myGlobal.Center_Y);

                 myGlobal.arctan = (((myGlobal.CA) / myGlobal.BC));

                 myGlobal.gradus = (180 + ((Math.Atan(myGlobal.arctan) * 180) / Math.PI));
             }

             // 4 square 
             if ((myGlobal.Mouse_X < myGlobal.Center_X) && (myGlobal.Mouse_Y > myGlobal.Center_Y))
             {
                 myGlobal.BC = (myGlobal.Center_X) - (myGlobal.Mouse_X);
                 myGlobal.CA = (myGlobal.Mouse_Y) - (myGlobal.Center_Y);

                 myGlobal.arctan = (-(myGlobal.CA) / myGlobal.BC);

                 myGlobal.gradus = ( 360 + ((Math.Atan(myGlobal.arctan) * 180) / Math.PI));
             }

             Convert.ToDouble(this.Resources["Dynamic_Rotation"] = myGlobal.gradus);
             this.Resources["Dynamic_Rotation_Text"] = myGlobal.gradus.ToString();

         }


         public void Mouse_Off_Ball(object sender, MouseEventArgs e)
         {
            Cue.Visibility = System.Windows.Visibility.Hidden;
            Outer_Power_Bar.Visibility = System.Windows.Visibility.Hidden;
            myGlobal.stateOnBall = false;
            myGlobal.stateAim = false;
            myGlobal.stateOnField = false;
            myGlobal.firstClick = true;
         }

         public void Mouse_Off_Field(object sender, MouseEventArgs e)
         {
             Outer_Power_Bar.Visibility = System.Windows.Visibility.Hidden;
             myGlobal.stateOnField = false;
             myGlobal.onFieldLock = false;
             
             
             this.Resources["Dynamic_Power"] = "0";
             Output_Power.SetResourceReference(TextBlock.TextProperty, "Dynamic_Power");
         }

      

       
        
          


        }
    }

