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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
    
            Button button1 = new Button();
            button1.Width = 50;
            button1.Height = 50;

            gameField.Children.Add(button1);



        //    int row = Grid.GetRow(button1); // вторая строка
        //    int col = Grid.GetColumn(button1); // второй столбец
            
            
        }

        public class Balls { 
        
        
        
        
        
        };


              

         public void button1_Click (object sender, RoutedEventArgs e)
            {
               // int row = Grid.GetRow(); // вторая строка
              //  int col = Grid.GetColumn(); // второй столбец
              
              //  MessageBox.Show("Amount of rows" + row.ToString() + " " + "Amount of rows" + " " + col.ToString());
                
            }

         public void Text_Box_Change(object sender, TextChangedEventArgs e)
         {
             TextBox textBox = (TextBox)sender;
             MessageBox.Show(textBox.Text);
         }

         private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
         {
            
         }
         
          
               public void Mouse_On_Ball(object sender, MouseEventArgs e)
             {
                // Cue.Visibility = System.Windows.Visibility.Visible;
                 Point centerPosition = e.GetPosition(Three_Ball);



                 this.Resources["DynamicRotation"] = (centerPosition.X + centerPosition.Y);
                              
             }
         

         public void Mouse_Off_Ball(object sender, MouseEventArgs e)
         {
            // Cue.Visibility = System.Windows.Visibility.Hidden;
             Point mousePosition = Mouse.GetPosition(this);
             Point centerPosition = e.GetPosition(NumberOfBall);

             MessageBox.Show("Координаты центра шара x=" + centerPosition.X + "y = " + centerPosition.Y);  


            this.Resources["DynamicPositon_X"] = centerPosition.X;
            this.Resources["DynamicPositon_Y"] = centerPosition.Y;


            // this.Resources["DynamicCenter"] = ();
             MessageBox.Show("Координата мышки x=" + mousePosition.X.ToString() + " y=" + mousePosition.Y.ToString());
             MessageBox.Show("Координаты центра шара x=" + centerPosition.X + "y = "  + centerPosition.Y );  
         }

       
        
          


        }
    }

