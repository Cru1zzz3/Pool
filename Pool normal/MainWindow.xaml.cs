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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pool_normal
{

    public partial class MainWindow : Window
    {


        public MainWindow()
        {
           
            InitializeComponent();

            
            myGlobal.cueHeight = this.Resources["cueHeight"]; 
            myGlobal.cueWidth = this.Resources["cueWidth"];
            myGlobal.diameter = this.Resources["ballDiameter"];

          //  this.Resources["Dynamic_Center_X"] = myGlobal.Center_X.ToString();
          // this.Resources["Dynamic_Center_Y"] = myGlobal.Center_Y.ToString();

            myGlobal.doubleDiameter = Convert.ToDouble(myGlobal.diameter);
            myGlobal.doubleRadius = (myGlobal.doubleDiameter / 2);
            myGlobal.doubleSemiRadius = (myGlobal.doubleRadius / 2);
            myGlobal.doubleCueHeight = Convert.ToDouble(myGlobal.cueHeight);
            myGlobal.doubleCueWidth = Convert.ToDouble(myGlobal.cueWidth);

        }

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
                            myGlobal.Center_X += 4;
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
            Trajectory.Visibility = System.Windows.Visibility.Visible;

            Point centerPosition = Mouse.GetPosition(this.Game_Canvas);

            myGlobal.Center_X = centerPosition.X;
            myGlobal.Center_Y = centerPosition.Y;
            this.Resources["Dynamic_Center_X"] = centerPosition.X.ToString();
            this.Resources["Dynamic_Center_Y"] = centerPosition.Y.ToString();

            

            this.Resources["Dynamic_Offset_X"] = (myGlobal.Center_X + myGlobal.doubleDiameter);
            this.Resources["Dynamic_Offset_Y"] = (myGlobal.Center_Y - myGlobal.doubleSemiRadius);

        }

        public void Show_Position(object sender, MouseEventArgs e)
        {
            Point thisPosition = e.GetPosition(this);
            MessageBox.Show(thisPosition.ToString());


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


        public void Starting_Position(object sender, MouseEventArgs e)
        {
            myGlobal.LeftTopHole = e.GetPosition(Left_Top_Hole);
            myGlobal.RightTopHole = e.GetPosition(Right_Top_Hole);

            myGlobal.MiddleTopHole = e.GetPosition(Middle_Top_Hole);
            myGlobal.MiddleBottomHole = e.GetPosition(Middle_Bottom_Hole);

            myGlobal.LeftBottomHole = e.GetPosition(Left_Bottom_Hole);
            myGlobal.RightBottomHole = e.GetPosition(Right_Bottom_Hole);

        }

        public void Mouse_Aim(object sender, MouseEventArgs e)
        {
            /*
            
            Point TwoPosition = e.GetPosition(Two_Ball);
            Point ThreePosition = e.GetPosition(Three_Ball);
            Point FouePosition = e.GetPosition(Four_Ball);
            Point FivePosition = e.GetPosition(Five_Ball);
            Point SixPosition = e.GetPosition(Six_Ball);
            Point SevenPosition = e.GetPosition(Seven_Ball);
            Point EightPosition = e.GetPosition(Eight_Ball);
            Point NinePosition = e.GetPosition(Nine_Ball);
            Point TenPosition = e.GetPosition(Ten_Ball);
            Point ElevenPosition = e.GetPosition(Eleven_Ball);
            Point TwelvePosition = e.GetPosition(Twelve_Ball);
            Point ThirteenPosition = e.GetPosition(Thirteen_Ball);
            Point FourteenPosition = e.GetPosition(Fourteen_Ball);
            Point FifthteenPosition = e.GetPosition(Fifthteen_Ball);
             * */
            myGlobal.stateAim = true;

            Point mousePosition = Mouse.GetPosition(Game_Canvas);

            myGlobal.Mouse_X = mousePosition.X;
            myGlobal.Mouse_Y = mousePosition.Y;

            Output_X.SetResourceReference(TextBlock.TextProperty, "Dynamic_Mouse_X");
            Output_Y.SetResourceReference(TextBlock.TextProperty, "Dynamic_Mouse_Y");

            this.Resources["Dynamic_Mouse_X"] = (mousePosition.X.ToString());
            this.Resources["Dynamic_Mouse_Y"] = (mousePosition.Y.ToString());

            // 1 square
            if ((myGlobal.Mouse_X < myGlobal.Center_X) && (myGlobal.Mouse_Y < myGlobal.Center_Y))
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

                myGlobal.arctan = ((-myGlobal.CA) / myGlobal.BC);

                myGlobal.gradus = (180 + ((Math.Atan(myGlobal.arctan) * 180) / Math.PI));
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

                myGlobal.gradus = (360 + ((Math.Atan(myGlobal.arctan) * 180) / Math.PI));

            }

            Convert.ToDouble(this.Resources["Dynamic_Rotation"] = myGlobal.gradus);
            this.Resources["Dynamic_Rotation_Text"] = myGlobal.gradus.ToString();

            myGlobal.trajectoryAngle = (180 + myGlobal.gradus);
            Convert.ToDouble(this.Resources["Dynamic_Trajectory"] = myGlobal.trajectoryAngle);


            Convert.ToDouble(this.Resources["Dynamic_Player_One"] = myGlobal.PlayerOne);
            this.Resources["Dynamic_Player_One_Text"] = myGlobal.playerOne.ToString();

            Convert.ToDouble(this.Resources["Dynamic_Player_Two"] = myGlobal.PlayerTwo);
            this.Resources["Dynamic_Player_Two_Text"] = myGlobal.playerOne.ToString();


        }

        public void Mouse_Off_Ball(object sender, MouseEventArgs e)
        {
            Cue.Visibility = System.Windows.Visibility.Hidden;
            Trajectory.Visibility = System.Windows.Visibility.Hidden;
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

        public void Mouse_Field_Up(object sender, MouseEventArgs e)
        {
            Outer_Power_Bar.Visibility = System.Windows.Visibility.Hidden;


            myGlobal.stateOnField = false;
            myGlobal.onFieldLock = false;

            Storyboard animation = this.TryFindResource("Storyboard1") as Storyboard;
            animation.Begin();

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(myGlobal.ProgressSpeed);

            int minValue = 0;
            int maxValue = myGlobal.maxProgressValue;
            if ( (myGlobal.Center_X != myGlobal.Mouse_X) && (myGlobal.Center_Y != myGlobal.Mouse_Y))
            {

                timer.Tick += (ss, ee) =>
                {

                    if (myGlobal.Center_X != myGlobal.Mouse_X)
                    {
                        myGlobal.Center_X += 4;
                        
                    }

                    if (myGlobal.Center_Y == myGlobal.Mouse_Y)
                    {
                        myGlobal.Center_Y += 4;
                    }



                    if (myGlobal.Center_X == myGlobal.Mouse_X || myGlobal.Center_Y == myGlobal.Mouse_Y )
                    {
                        timer.Stop();
                        
                    }

                };
                timer.Start();
            }
           // DoubleAnimation ball = new DoubleAnimation();
           

            // velocity.X = myGlobal.Center_X + myGlobal.Mouse_X;

        }

/*        private void BallMouseMoving(object sender, MouseEventArgs e)
        {
            this.Resources["Dynamic_Position_X"] = Mouse.GetPosition(this).X;
            this.Resources["Dynamic_Position_Y"] = Mouse.GetPosition(this).Y;
        }
*/
    }


    class Vector3
    {
        private double x, y;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Vector3()
        {
            x = 0.0;
            y = 0.0;
        }

        public Vector3(double x1, double y1)
        {
            x = x1;
            y = y1;
        }

        public Vector3(Vector3 v)
        {
            x = v.x;
            y = v.y;
        }

        public override string ToString()
        {
            return "(" + x.ToString("g3") + "," + y.ToString("g3") + ")";
        }
        // Находим длину вектора
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public bool Equal(Vector3 v2)
        {
            if (x == v2.X && y == v2.Y) // true если все компоненты одного вектора равны всем компонентам другого вектора
                return true;
            else
                return false;
        }

        // Скалярное произведение двух векторов = Скаляр
        public double DotProduct(Vector3 v2)
        {
            return (x * v2.X + y * v2.Y);
        }

        // Векторное произведение двух векторов = Новый вектор
        public Vector3 CrossProduct(Vector3 v2)
        {
            return new Vector3(y * v2.X - x * v2.Y, x * v2.Y - y * v2.X);
        }

        // Угол между векторами
        public double AngleBetween(Vector3 v2)
        {
            double answer = 0;
            double top = this.DotProduct(v2); // Скалярное произведение в числителе
            double under = this.Length() * v2.Length(); // Произведение длин векторов в знаменателе
            double angle;
            if (under != 0)
                answer = top / under;
            else
                return 0;
            if (answer > 1) answer = 1;
            if (answer < -1) answer = -1;

            angle = Math.Acos(answer);
            return (angle * 180 / Math.PI); // переводим в градусы
        }

        public Vector3 Unit()
        {
            double length = Math.Sqrt(x * x + y * y);
            return new Vector3(x / length, y / length);
        }


        public Vector3 ParralelComponent(Vector3 v2)
        {
            double lengthSquared, dotProduct, scale;
            lengthSquared = Length() * Length();
            dotProduct = DotProduct(v2);
            if (lengthSquared != 0)
                scale = dotProduct / lengthSquared;
            else
                return new Vector3();
            return new Vector3(this.Scale(scale));
        }

        public Vector3 PerpendicularComponent(Vector3 v2)
        {
            //subtract the parallel component from the orginal vecot
            //to get the orthogonal bit

            return new Vector3(v2 - this.ParralelComponent(v2)); // perpendicular component = vectorAnswer - parallel component
        }

        public Vector3 Scale(double scale)
        {
            return new Vector3(scale * x, scale * y); //Multiplys by scalar
        }


        public static Vector3 operator *(double k, Vector3 v1)
        {
            return new Vector3(k * v1.x, k * v1.y);
        }

        public static Vector3 operator *(Vector3 v1, double k)
        {
            return new Vector3(k * v1.x, k * v1.y);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y); //adds
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y); //subtracts
        }
       
        public static Vector3 operator -(Vector3 v1)
        {
            return new Vector3(-v1.x, -v1.y);
        }
    }
}
