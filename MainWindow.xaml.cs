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

namespace ChessOnline
{
    public partial class MainWindow : Window
    {
       public int[,] board = new int[8, 8]

           {
            {-2,-3,-4,-5,-6,-4,-3,-2 },
            {-1,-1,-1,-1,-1,-1,-1,-1 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 3,-3, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 3, 4, 5, 6, 4, 3, 2 },
           };
        public int[] Click1 = {1, 1};
        bool Click1Made = false;
        bool FigrAreSelect = false;
        int fromWhere = 1;
        int fromWhere1 = 1;
        int whereTo = -1;
        int whereTo1 = -1;

        public bool? turnMove = true;

        BitmapImage Img_W_King = new BitmapImage(new Uri(@"image\KingWHITE.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_W_Queen = new BitmapImage(new Uri(@"image\QueenWHITE.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_W_Bishop = new BitmapImage(new Uri(@"image\BishopWHITE.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_W_Knight = new BitmapImage(new Uri(@"image\KnightWHITE.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_W_Rook = new BitmapImage(new Uri(@"image\RookWHITE.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_W_Pawn = new BitmapImage(new Uri(@"image\PawnWHITE.png", UriKind.RelativeOrAbsolute));

		BitmapImage Img_B_King = new BitmapImage(new Uri(@"image\KingBLACK.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_B_Queen = new BitmapImage(new Uri(@"image\QueenBLACK.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_B_Bishop = new BitmapImage(new Uri(@"image\BishopBLACK.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_B_Knight = new BitmapImage(new Uri(@"image\KnightBLACK.png", UriKind.RelativeOrAbsolute));
		//BitmapImage Img_B_Rook = new BitmapImage(new Uri(@"image\RookBLACK.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_B_Pawn = new BitmapImage(new Uri(@"image\PawnBLACK.png", UriKind.RelativeOrAbsolute));

		BitmapImage Img_W_SuperPawn = new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_B_SuperPawn = new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));

        BitmapImage Img_B_Rook =  new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));

		public MainWindow()
		{
			InitializeComponent();
            testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]);
            draw();
		}
		public void testPos(string i, string j) 
        {
            test.ItemsSource =  i + j;
        }
        public void testItem(int i, int j)
        {
            test2.ItemsSource = board[i,j].ToString();
            test3.ItemsSource = Click1Made.ToString();
            
        }

        BitmapImage drawByNum(int i)
		{
			switch (i)
			{
				case 1: return Img_W_Pawn;
				case 2: return Img_W_Rook;
				case 3: return Img_W_Knight;
				case 4: return Img_W_Bishop;
				case 5: return Img_W_Queen;
				case 6: return Img_W_King;

				case 7: return Img_W_SuperPawn;

				case -1: return Img_B_Pawn;
				case -2: return Img_B_Rook;
				case -3: return Img_B_Knight;
				case -4: return Img_B_Bishop;
				case -5: return Img_B_Queen;
				case -6: return Img_B_King;

				case -7: return Img_B_SuperPawn;
				default: return null;
			}
		}
		void draw()
		{
			a8.Source = drawByNum(board[0, 0]); b8.Source = drawByNum(board[0, 1]); c8.Source = drawByNum(board[0, 2]); d8.Source = drawByNum(board[0, 3]); e8.Source = drawByNum(board[0, 4]); f8.Source = drawByNum(board[0, 5]); g8.Source = drawByNum(board[0, 6]); h8.Source = drawByNum(board[0, 7]);
			a7.Source = drawByNum(board[1, 0]); b7.Source = drawByNum(board[1, 1]); c7.Source = drawByNum(board[1, 2]); d7.Source = drawByNum(board[1, 3]); e7.Source = drawByNum(board[1, 4]); f7.Source = drawByNum(board[1, 5]); g7.Source = drawByNum(board[1, 6]); h7.Source = drawByNum(board[1, 7]);
			a6.Source = drawByNum(board[2, 0]); b6.Source = drawByNum(board[2, 1]); c6.Source = drawByNum(board[2, 2]); d6.Source = drawByNum(board[2, 3]); e6.Source = drawByNum(board[2, 4]); f6.Source = drawByNum(board[2, 5]); g6.Source = drawByNum(board[2, 6]); h6.Source = drawByNum(board[2, 7]);
			a5.Source = drawByNum(board[3, 0]); b5.Source = drawByNum(board[3, 1]); c5.Source = drawByNum(board[3, 2]); d5.Source = drawByNum(board[3, 3]); e5.Source = drawByNum(board[3, 4]); f5.Source = drawByNum(board[3, 5]); g5.Source = drawByNum(board[3, 6]); h5.Source = drawByNum(board[3, 7]);
			a4.Source = drawByNum(board[4, 0]); b4.Source = drawByNum(board[4, 1]); c4.Source = drawByNum(board[4, 2]); d4.Source = drawByNum(board[4, 3]); e4.Source = drawByNum(board[4, 4]); f4.Source = drawByNum(board[4, 5]); g4.Source = drawByNum(board[4, 6]); h4.Source = drawByNum(board[4, 7]);
			a3.Source = drawByNum(board[5, 0]); b3.Source = drawByNum(board[5, 1]); c3.Source = drawByNum(board[5, 2]); d3.Source = drawByNum(board[5, 3]); e3.Source = drawByNum(board[5, 4]); f3.Source = drawByNum(board[5, 5]); g3.Source = drawByNum(board[5, 6]); h3.Source = drawByNum(board[5, 7]);
			a2.Source = drawByNum(board[6, 0]); b2.Source = drawByNum(board[6, 1]); c2.Source = drawByNum(board[6, 2]); d2.Source = drawByNum(board[6, 3]); e2.Source = drawByNum(board[6, 4]); f2.Source = drawByNum(board[6, 5]); g2.Source = drawByNum(board[6, 6]); h2.Source = drawByNum(board[6, 7]);
			a1.Source = drawByNum(board[7, 0]); b1.Source = drawByNum(board[7, 1]); c1.Source = drawByNum(board[7, 2]); d1.Source = drawByNum(board[7, 3]); e1.Source = drawByNum(board[7, 4]); f1.Source = drawByNum(board[7, 5]); g1.Source = drawByNum(board[7, 6]); h1.Source = drawByNum(board[7, 7]);
		}
        int selFigr(int i)
        {
            if(turnMove == true)
                switch (i)
                {
                    case 1: return Move.Move_PawnW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 2: return Move.Move_RookW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 3: return Move.Move_KnightW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 4: return Move.Move_BishopW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case 5: return Move.Move_QueenW(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    //case 6: return Img_W_King;

                    //case 7: return Img_W_SuperPawn;
                    default: test3.ItemsSource = "LOOOOOL"; return 0;
                }
            
            if (turnMove == false)
                switch (i)
                {
                    case -1: return Move.Move_PawnB(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case -2: return Move.Move_RookB(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case -3: return Move.Move_KnightB (board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case -4: return Move.Move_BishopB(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    case -5: return Move.Move_QueenB(board, fromWhere1, fromWhere, whereTo1, whereTo);
                    //case -6: return Img_B_King;

                    //case -7: return Img_B_SuperPawn;
                    default: test3.ItemsSource = "LOOOOOL"; return 0;
            }
            return 0;
        }
        void OnClick() // коли я це написав як це працювало знав я і бог, тепер знає тільки бог. 
        {
            
            if (Click1Made) 
            {
                fromWhere = Click1[0];
                fromWhere1 = Click1[1];
                FigrAreSelect = true;
            }
            if (!Click1Made)
            {
                whereTo = Click1[0];
                whereTo1 = Click1[1];
                if (selFigr(board[fromWhere, fromWhere1])==1)
                {
                    int temp = board[whereTo, whereTo1];
                    int temp2 = board[fromWhere, fromWhere1];
                    
                    board[whereTo, whereTo1] = board[fromWhere, fromWhere1];
                    if (temp != board[fromWhere, fromWhere1]) board[fromWhere, fromWhere1] = 0;
                    draw();
                    //if (temp2 > 0) turnMove = false;
                    //if (temp2 < 0) turnMove = true;
                    turnMove = !turnMove;
                    test4.ItemsSource = turnMove.ToString();
                }
            }


        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            //board[0, 0] = 7;
            //draw();
           Click1[0] = 0;
           Click1[1] = 0;
            if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
           testItem(Click1[0], Click1[1]); OnClick();  
           
           // a.Background = Color.;

        }
		

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Click1[0] = 0;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Click1[0] = 0;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 0;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            Click1[0] = 1;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 0;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            Click1[0] = 2;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 0;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_26(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 


        }

        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            Click1[0] = 3;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 


        }

        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 0;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 


        }

        private void Button_Click_33(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_34(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_35(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_36(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 


        }

        private void Button_Click_37(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_38(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 


        }

        private void Button_Click_39(object sender, RoutedEventArgs e)
        {
            Click1[0] = 4;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 


        }

        private void Button_Click_40(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 0;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_41(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 

        }

        private void Button_Click_42(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_43(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_44(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_45(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_46(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_47(object sender, RoutedEventArgs e)
        {
            Click1[0] = 5;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_48(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 0;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_49(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_50(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_51(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_52(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_53(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_54(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_55(object sender, RoutedEventArgs e)
        {
            Click1[0] = 6;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_56(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 0;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_57(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 1;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_58(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 2;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_59(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 3;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_60(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 4;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_61(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 5;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_62(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 6;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_Click_63(object sender, RoutedEventArgs e)
        {
            Click1[0] = 7;
            Click1[1] = 7;
              if ( board[Click1[0], Click1[1]] != 0 || Click1Made == true){ Click1Made = !Click1Made; }  testPos(Click1[0].ToString(), Click1[1].ToString());
            testItem(Click1[0], Click1[1]); OnClick(); 
        }

        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {

        }
    }


}
//int Check_Black(int kingx, int kingy)
//{
//    int ok = 0;
//    for (int i = 0; i < 8; i++)
//    {
//        for (int j = 0; j < 8; j++)
//        {
//            if (board[i, j] < 0)
//            {
//                if (board[i, j] == PawnWHITE)
//                {
//                    ok = Check_PawnW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == TowerWHITE)
//                {
//                    ok = Check_TowerW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == KnightWHITE)
//                {
//                    ok = Check_KnightW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == BishopWHITE)
//                {
//                    ok = Check_BishopW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == QueenWHITE)
//                {
//                    ok = Check_QueenW(j, i, kingx, kingy);
//                }
//                if (board[i, j] == KingWHITE)
//                {
//                    ok = Check_KingW(j, i, kingx, kingy);
//                }
//                if (ok == 1)
//                {
//                    return 0;
//                }
//            }
//        }
//    }
//    return 1;
//}