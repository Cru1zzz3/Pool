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


              

         public void button1_Click (object sender, RoutedEventArgs e)
            {
               // int row = Grid.GetRow(); // вторая строка
              //  int col = Grid.GetColumn(); // второй столбец
              
              //  MessageBox.Show("Amount of rows" + row.ToString() + " " + "Amount of rows" + " " + col.ToString());
                
            }

         private void Progress_Bar()
         {
             gameField.MouseEnter += (ss, ee) =>
             {

                 Power_Bar.Height = 0;

                 System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                 timer.Interval = TimeSpan.FromMilliseconds(20);

                 int minValue = 0;
                 int maxValue = 200;

                 timer.Tick += (sss, eee) =>
                 {
                     //int match = 0;

                     if (Power_Bar.Height != maxValue)
                     {
                         if (maxValue == 100)
                             Power_Bar.Height += 1;

                         else if (maxValue == 0)
                             Power_Bar.Height -= 1;
                     }

                     else if (Power_Bar.Height == maxValue)
                         maxValue = minValue;

                     if (myGlobal.stateOnField == false)
                         timer.Stop();

                 };
                 timer.Start();
             };
         }
    
        
         
          
         public void Mouse_On_Ball(object sender, MouseEventArgs e)
             {
                 Progress_Bar();
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
             

             if (e.LeftButton == MouseButtonState.Pressed)
             {
                 if (myGlobal.stateOnBall == true && myGlobal.stateAim == true && myGlobal.stateOnField == true)
                 {
                     Power_Bar.Visibility = System.Windows.Visibility.Visible;
                 }
                 myGlobal.stateOnField = true;
                 
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


         public void checkPowerState() {
             if (myGlobal.stateOnBall == true && myGlobal.stateAim == true && myGlobal.stateOnField == true )
             {  
                 MessageBox.Show("Вы нажали на поле!");
             }
             myGlobal.stateAim = false;
         }


         public void Mouse_Off_Ball(object sender, MouseEventArgs e)
         {
            Cue.Visibility = System.Windows.Visibility.Hidden;
            Power_Bar.Visibility = System.Windows.Visibility.Hidden;
            myGlobal.stateOnBall = false;
            myGlobal.stateAim = false;
            myGlobal.stateOnField = false;            
         }

         public void Mouse_Off_Field(object sender, MouseEventArgs e)
         {
             Power_Bar.Visibility = System.Windows.Visibility.Hidden;
             myGlobal.stateOnField = false;
         }

      

       
        
          


        }
    }

