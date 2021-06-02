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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int[,] board = new int[8, 8]

		   {
			{-2,-3,-4,-5,-6,-4,-3,-2 },
			{-1,-1,-1,-1,-1,-1,-1,-1 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 1, 1, 1, 1, 1, 1, 1 },
			{ 2, 3, 4, 5, 6, 4, 3, 2 },
		   };
		int Click1 = 0;
		int Click2 = 0;

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
		BitmapImage Img_B_Rook = new BitmapImage(new Uri(@"image\RookBLACK.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_B_Pawn = new BitmapImage(new Uri(@"image\PawnBLACK.png", UriKind.RelativeOrAbsolute));

		BitmapImage Img_W_SuperPawn = new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));
		BitmapImage Img_B_SuperPawn = new BitmapImage(new Uri(@"image\TransformW.png", UriKind.RelativeOrAbsolute));
		
		public MainWindow()
		{
			InitializeComponent();
			//test.ItemsSource = board[6, 0].ToString();
			draw();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//board[2, 0] = 7;
			//draw();


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