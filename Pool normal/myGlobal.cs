using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pool_normal
{
    class myGlobal
    {
        public static double Mouse_X = .0;
        public static double Mouse_Y = .0;

        public static double Center_X = .250;
        public static double Center_Y = .250;

        public static double BC = .0;
        public static double CA = .0;

        public static double arctan = .0;
        public static double gradus = .0;
        public static double trajectoryAngle = .0;

        public static bool stateOnBall = false;
        public static bool stateAim = false;
        public static bool stateOnField = false;

        public static bool firstClick = true;

        public static double ProgressSpeed = 20;
        public static int maxProgressValue = 300;

        public static int countOfPower = 0;

        public static bool onFieldLock = false;

        public static int playerOne  = 0;
        public static int playerTwo = 0;

        public static bool turn = true;

        public static bool blackFlag = false;

        public static Point LeftTopHole;
        public static Point RightTopHole;

        public static Point MiddleTopHole;
        public static Point MiddleBottomHole;

        public static Point LeftBottomHole;
        public static Point RightBottomHole;

        public static object PlayerOne { get; set; }

        public static object PlayerTwo { get; set; }

        public static object diameter;
        public static object cueHeight;
        public static object cueWidth;


        public static double doubleRadius;
        public static double doubleSemiRadius;
        public static double doubleDiameter;
        public static double doubleCueHeight;
        public static double doubleCueWidth;
    }
}
