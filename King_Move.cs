﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
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
   
		public static class King_Move
		{


			public static int right_towerW_first_move = 0, left_towerW_first_move = 0, kingW_first_move = 0;
			public static int right_towerB_first_move = 0, left_towerB_first_move = 0, kingB_first_move = 0;

			// шах білим пішаком
			static int Check_PawnW(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				//std::cout << "ox=" << ox << " oy=" << oy << " kingx=" << kingx << " kingy=" << kingy << "\n\n\n";
				if (board[oy - 1,ox - 1] >= 0)// шах наліво
				{
					if (oy - 1 == kingy && ox - 1 == kingx)
					{
						return 1;
					}
				}
				if (board[oy - 1,ox + 1] >= 0)// шах направо
				{
					//std::cout << "da";
					if (oy - 1 == kingy && ox + 1 == kingx)
					{
						return 1;
					}
				}
				return 0;
			}

			// шах білою турою
			static int Check_TowerW(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				for (int i = ox - 1; i >= 0; i--) // шах наліво
				{
					if (board[oy,i] >= 0 && (kingx == i && kingy == oy))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy - 1; i >= 0; i--) // шах вверх
				{
					if (board[i,ox] >= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				for (int i = ox + 1; i < 8; i++) // шах направо
				{
					if (board[oy,i] >= 0 && (kingy == oy && kingx == i))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy + 1; i < 8; i++) // шах вниз
				{
					if (board[i,ox] >= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				return 0;
			}

			// шах білим слоном
			static int Check_BishopW(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				int j = ox - 1;
				for (int i = oy - 1; i >= 0; i--) // шах наліво вверх 
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy - 1; i >= 0; i--) // шах направо вверх
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				j = ox - 1;
				for (int i = oy + 1; i <= 7; i++) // шах наліво вниз
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy + 1; i <= 7; i++)  // шах направо вниз 
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				return 0;
			}

			// шах білою ферзю
			static int Check_QueenW(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				for (int i = ox - 1; i >= 0; i--) // шах наліво
				{
					if (board[oy,i] >= 0 && (kingx == i && kingy == oy))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy - 1; i >= 0; i--) // шах вверх
				{
					if (board[i,ox] >= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				for (int i = ox + 1; i < 8; i++) // шах направо
				{
					if (board[oy,i] >= 0 && (kingy == oy && kingx == i))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy + 1; i < 8; i++) // шах вниз
				{
					if (board[i,ox] >= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				int j = ox - 1;
				for (int i = oy - 1; i >= 0; i--) // шах наліво вверх
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy - 1; i >= 0; i--) // шах направо вверх
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				j = ox - 1;
				for (int i = oy + 1; i <= 7; i++) // шах наліво вниз
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy + 1; i < 8; i++)  // шах направо вниз
				{
					if (board[i,j] >= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				return 0;
			}

			// шах білим конем 
			static int Check_KnightW(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				if (oy - 1 >= 0 && ox - 2 >= 0 && kingy == oy - 1 && kingx == ox - 2 && board[kingy,kingx] >= 0)
				{
					return 1; // шах наліво вверх --
				}
				if (oy - 2 >= 0 && ox - 1 >= 0 && kingy == oy - 2 && kingx == ox - 1 && board[kingy,kingx] >= 0)
				{
					return 1; // шах наліво вверх |
				}
				if (oy - 2 >= 0 && ox + 1 < 8 && kingy == oy - 2 && kingx == ox + 1 && board[kingy,kingx] >= 0)
				{
					return 1; // шах направо вверх |
				}
				if (oy - 1 >= 0 && ox + 2 < 8 && kingy == oy - 1 && kingx == ox + 2 && board[kingy,kingx] >= 0)
				{
					return 1; // шах направо вверх --
				}
				if (oy + 1 >= 0 && ox + 2 < 8 && kingy == oy + 1 && kingx == ox + 2 && board[kingy,kingx] >= 0)
				{
					return 1; // шах направо вниз --
				}
				if (oy + 2 < 8 && ox + 1 < 8 && kingy == oy + 2 && kingx == ox + 1 && board[kingy,kingx] >= 0)
				{
					return 1; // шах направо вниз |
				}
				if (oy + 2 < 8 && ox - 1 >= 0 && kingy == oy + 2 && kingx == ox - 1 && board[kingy,kingx] >= 0)
				{
					return 1; // шах наліво вниз |
				}
				if (oy + 1 < 8 && ox - 2 >= 0 && kingy == oy + 1 && kingx == ox - 2 && board[kingy,kingx] >= 0)
				{
					return 1; // шах наліво вниз --
				}

				return 0;
			}

			// шах білим королем 
			static int Check_KingW(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				if (ox - 1 >= 0 && oy - 1 >= 0 && kingy == oy - 1 && kingx == ox - 1 && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				if (oy - 1 >= 0 && kingx == ox && kingy == oy - 1 && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				if (oy - 1 >= 0 && ox + 1 < 8 && kingx == ox + 1 && kingy == oy - 1 && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				if (ox + 1 < 8 && kingy == oy && kingx == ox + 1 && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				if (ox + 1 < 8 && oy + 1 < 8 && kingy == oy + 1 && kingx == ox + 1 && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				if (oy + 1 < 8 && kingy == oy + 1 && kingx == ox && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				if (ox - 1 >= 0 && oy + 1 < 8 && kingx == ox - 1 && kingy == oy + 1 && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				if (ox - 1 >= 0 && kingy == oy && kingx == ox - 1 && board[kingy,kingx] <= 0)
				{
					return 1;
				}
				return 0;
			}


			// шах чорним пішаком
			static int Check_PawnB(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				if (board[oy + 1,ox - 1] <= 0)
				{
					if (kingy == oy + 1 && kingx == ox - 1)
					{
						return 1;
					}
				}
				if (board[oy + 1,ox + 1] <= 0)
				{
					if (kingy == oy + 1 && kingx == ox + 1)
					{
						return 1;
					}
				}
				return 0;
			}

			// шах чорною турою
			static int Check_TowerB(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				for (int i = ox - 1; i >= 0; i--) // шах наліво
				{
					if (board[oy,i] <= 0 && (kingx == i && kingy == oy))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy - 1; i >= 0; i--) // шах вверх
				{
					if (board[i,ox] <= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				for (int i = ox + 1; i < 8; i++) // шах направо
				{
					if (board[oy,i] <= 0 && (kingy == oy && kingx == i))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy + 1; i < 8; i++) // шах вниз
				{
					if (board[i,ox] <= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				return 0;
			}

			// шах чорним слоном
			static int Check_BishopB(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				int j = ox - 1;
				for (int i = oy - 1; i >= 0; i--) // шах наліво вверх
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy - 1; i >= 0; i--) // шах направо вверх
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				j = ox - 1;
				for (int i = oy + 1; i <= 7; i++) // шах наліво вниз
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy + 1; i <= 7; i++)  // шах направо вниз
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				return 0;
			}

			// шах чорною ферзю
			static int Check_QueenB(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				for (int i = ox - 1; i >= 0; i--) // шах наліво
				{
					if (board[oy,i] <= 0 && (kingx == i && kingy == oy))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy - 1; i >= 0; i--) // шах вверх
				{
					if (board[i,ox] <= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				for (int i = ox + 1; i < 8; i++) // шах направо
				{
					if (board[oy,i] <= 0 && (kingy == oy && kingx == i))
					{
						return 1;
					}
					else if (board[oy,i] != 0)
					{
						break;
					}
				}
				for (int i = oy + 1; i < 8; i++) // шах врниз
				{
					if (board[i,ox] <= 0 && (kingy == i && kingx == ox))
					{
						return 1;
					}
					else if (board[i,ox] != 0)
					{
						break;
					}
				}
				int j = ox - 1;
				for (int i = oy - 1; i >= 0; i--) // шах наліво вверх
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy - 1; i >= 0; i--) // шах направо вврех 
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				j = ox - 1;
				for (int i = oy + 1; i <= 7; i++) // шах наліво вниз
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j--;
				}
				j = ox + 1;
				for (int i = oy + 1; i < 8; i++)  // шах направо вниз
				{
					if (board[i,j] <= 0 && (kingy == i && kingx == j))
					{
						return 1;
					}
					else if (board[i,j] != 0)
					{
						break;
					}
					j++;
				}
				return 0;
			}

			// шах чорним конем
			static int Check_KnightB(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				if (oy - 1 >= 0 && ox - 2 >= 0 && kingy == oy - 1 && kingx == ox - 2 && board[kingy,kingx] <= 0)
				{
					return 1;// шах наліво вверх -- 
				}
				if (oy - 2 >= 0 && ox - 1 >= 0 && kingy == oy - 2 && kingx == ox - 1 && board[kingy,kingx] <= 0)
				{
					return 1; // шах наліво вверх |
				}
				if (oy - 2 >= 0 && ox + 1 < 8 && kingy == oy - 2 && kingx == ox + 1 && board[kingy,kingx] <= 0)
				{
					return 1; // шах направо вверх |
				}
				if (oy - 1 >= 0 && ox + 2 < 8 && kingy == oy - 1 && kingx == ox + 2 && board[kingy,kingx] <= 0)
				{
					return 1; // шах направо вверх --
				}
				if (oy + 1 >= 0 && ox + 2 < 8 && kingy == oy + 1 && kingx == ox + 2 && board[kingy,kingx] <= 0)
				{
					return 1; // шах направо вниз --
				}
				if (oy + 2 < 8 && ox + 1 < 8 && kingy == oy + 2 && kingx == ox + 1 && board[kingy,kingx] <= 0)
				{
					return 1; // шах направо вниз |
				}
				if (oy + 2 < 8 && ox - 1 >= 0 && kingy == oy + 2 && kingx == ox - 1 && board[kingy,kingx] <= 0)
				{
					return 1; // шах наліво вниз |
				}
				if (oy + 1 < 8 && ox - 2 >= 0 && kingy == oy + 1 && kingx == ox - 2 && board[kingy,kingx] <= 0)
				{
					return 1; // шах наліво вниз --
				}

				return 0;
			}

			// шах чорним королем
			static int Check_KingB(int[,] board, int ox, int oy, int kingx, int kingy)
			{
				if (ox - 1 >= 0 && oy - 1 >= 0 && kingy == oy - 1 && kingx == ox - 1 && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				if (oy - 1 >= 0 && kingx == ox && kingy == oy - 1 && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				if (oy - 1 >= 0 && ox + 1 < 8 && kingx == ox + 1 && kingy == oy - 1 && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				if (ox + 1 < 8 && kingy == oy && kingx == ox + 1 && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				if (ox + 1 < 8 && oy + 1 < 8 && kingy == oy + 1 && kingx == ox + 1 && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				if (oy + 1 < 8 && kingy == oy + 1 && kingx == ox && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				if (ox - 1 >= 0 && oy + 1 < 8 && kingx == ox - 1 && kingy == oy + 1 && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				if (ox - 1 >= 0 && kingy == oy && kingx == ox - 1 && board[kingy,kingx] >= 0)
				{
					return 1;
				}
				return 0;
			}


			//////////////////king////////////////////

			// перевіка на шах чорному королю
			static int Check_Black(int[,] board, int kingx, int kingy)
			{
				int ok = 0;
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (board[i,j] < 0)
						{
							if (board[i,j] == 1)
							{
								ok = Check_PawnW(board, j, i, kingx, kingy);
							}
							if (board[i,j] == 2)
							{
								ok = Check_TowerW(board, j, i, kingx, kingy);
							}
							if (board[i,j] == 3)
							{
								ok = Check_KnightW(board, j, i, kingx, kingy);
							}
							if (board[i,j] == 4)
							{
								ok = Check_BishopW(board, j, i, kingx, kingy);
							}
							if (board[i,j] == 5 )
							{
								ok = Check_QueenW(board, j, i, kingx, kingy);
							}
							if (board[i,j] == 5)
							{
								ok = Check_KingW(board, j, i, kingx, kingy);
							}
							if (ok == 1)
							{
								return 0;
							}
						}
					}
				}
				return 1;
			}

			// хід чоним королем
			public static int Move_KingB(int[,] board, int ox, int oy, int nx, int ny)
			{
				if (ox - 1 >= 0 && oy - 1 >= 0 && ny == oy - 1 && nx == ox - 1 && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board, ox - 1, oy - 1);
					if (ok == 1)
					{
						return 1;  // хід наліво вверх
					}
				}
				if (oy - 1 >= 0 && nx == ox && ny == oy - 1 && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board, ox, oy - 1);
					if (ok == 1)
					{
						return 1; // хід вверх
					}
				}
				if (oy - 1 >= 0 && ox + 1 < 8 && nx == ox + 1 && ny == oy - 1 && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board, ox + 1, oy - 1);
					if (ok == 1)
					{
						return 1; // хід направо вверх
					}
				}
				if (ox + 1 < 8 && ny == oy && nx == ox + 1 && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board, ox + 1, oy);
					if (ok == 1)
					{
						return 1; // хід направо
					}
				}
				if (ox + 1 < 8 && oy + 1 < 8 && ny == oy + 1 && nx == ox + 1 && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board, ox + 1, oy + 1);
					if (ok == 1)
					{
						return 1; // хід направо вниз
					}
				}
				if (oy + 1 < 8 && ny == oy + 1 && nx == ox && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board, ox, oy + 1);
					if (ok == 1)
					{
						return 1; // хід вниз
					}
				}
				if (ox - 1 >= 0 && oy + 1 < 8 && nx == ox - 1 && ny == oy + 1 && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board, ox - 1, oy + 1);
					if (ok == 1)
					{
						return 1; // хід наліво вниз
					}
				}
				if (ox - 1 >= 0 && ny == oy && nx == ox - 1 && board[ny,nx] <= 0)
				{
					int ok = Check_Black(board,ox - 1, oy);
					if (ok == 1)
					{
						return 1; // хід наліво
					}
				}
				// рокіровка чорних направо
				if (right_towerB_first_move == 0 && kingB_first_move == 0 && board[0,5] == 0 && board[0,6] == 0 && ny == 0 && nx == 6)
				{
					int ok = Check_Black(board, 4, 0);
					if (ok == 1)
					{
						ok = Check_Black(board, 5, 0);
						if (ok == 1)
						{
							ok = Check_Black(board, 6, 0);
							if (ok == 1)
							{
								kingB_first_move = 1;
								right_towerB_first_move = 1;
								board[0,7] = 0;
								board[0,5] = 2;
								return 1;
							}
						}
					}
				}
				// рокіровка чорних наліво

				if (left_towerB_first_move == 0 && kingB_first_move == 0 && board[0,3] == 0 && board[0,2] == 0 && board[0,1] == 0 && ny == 0 && nx == 2)
				{
					int ok = Check_Black(board, 4, 0);
					if (ok == 1)
					{
						ok = Check_Black(board, 3, 0);
						if (ok == 1)
						{
							ok = Check_Black(board, 2, 0);
							if (ok == 1)
							{
								ok = Check_Black(board, 1, 0);
								if (ok == 1)
								{
									kingB_first_move = 1;
									left_towerB_first_move = 1;
									board[0,0] = 0;
									board[0,3] =2;
									return 1;
								}
							}
						}
					}
				}
				return 0;
			}

			// перевірка на шах білому королю
			static int Check_White(int[,] board, int kingx, int kingy)
			{
				int ok = 0;
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (board[i,j] > 0)
						{
							if (board[i,j] == -1)
							{
								ok = Check_PawnB(board, j, i, kingx, kingy);
							}
							if (board[i,j] == -2)
							{
								ok = Check_TowerB(board, j, i, kingx, kingy);
							}
							if (board[i,j] == -3)
							{
								ok = Check_KnightB(board, j, i, kingx, kingy);
							}
							if (board[i,j] == -4)
							{
								ok = Check_BishopB(board, j, i, kingx, kingy);
							}
							if (board[i,j] == -5)
							{
								ok = Check_QueenB(board, j, i, kingx, kingy);
							}
							if (board[i,j] == -6)
							{
								ok = Check_KingB(board, j, i, kingx, kingy);
							}
							if (ok == 1)
							{
								//	std::cout << "da" << "\n";
								return 0;
							}
						}
					}
				}
				return 1;
			}

			// хід білим королем
			public static int Move_KingW(int[,] board, int ox, int oy, int nx, int ny)
			{
				if (ox - 1 >= 0 && oy - 1 >= 0 && ny == oy - 1 && nx == ox - 1 && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox - 1, oy - 1);
					if (ok == 1)
					{
						return 1;  // хід наліво вверх
					}
				}
				if (oy - 1 >= 0 && nx == ox && ny == oy - 1 && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox, oy - 1);
					if (ok == 1)
					{
						return 1; // хід вверх
					}
				}
				if (oy - 1 >= 0 && ox + 1 < 8 && nx == ox + 1 && ny == oy - 1 && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox + 1, oy - 1);
					if (ok == 1)
					{
						return 1; // хід направо вверх
					}
				}
				if (ox + 1 < 8 && ny == oy && nx == ox + 1 && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox + 1, oy);
					if (ok == 1)
					{
						return 1; // хід направо
					}
				}
				if (ox + 1 < 8 && oy + 1 < 8 && ny == oy + 1 && nx == ox + 1 && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox + 1, oy + 1);
					if (ok == 1)
					{
						return 1; // хід направо вниз 
					}
				}
				if (oy + 1 < 8 && ny == oy + 1 && nx == ox && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox, oy + 1);
					if (ok == 1)
					{
						return 1; // хід вниз
					}
				}
				if (ox - 1 >= 0 && oy + 1 < 8 && nx == ox - 1 && ny == oy + 1 && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox - 1, oy + 1);
					if (ok == 1)
					{
						return 1; // хід наліво вниз
					}
				}
				if (ox - 1 >= 0 && ny == oy && nx == ox - 1 && board[ny,nx] >= 0)
				{
					int ok = Check_White(board, ox - 1, oy);
					if (ok == 1)
					{
						return 1; // хід наліво
					}
				}
				// Рокірока білими направо
				if (kingW_first_move == 0 && right_towerW_first_move == 0 && board[7,5] == 0 && board[7,6] == 0 && ny == 7 && nx == 6)
				{
					int ok = 1;
					ok = Check_White(board, 4, 7);
					if (ok == 1)
					{
						ok = Check_White(board, 5, 7);
						if (ok == 1)
						{
							ok = Check_White(board, 6, 7);
							if (ok == 1)
							{
								board[7,7] = 0;
								board[7,5] = 2;
								kingW_first_move = 1;
								right_towerW_first_move = 1;
								return 1;
							}
						}
					}
				}
				// Рокірока білими наліво
				if (kingW_first_move == 0 && right_towerW_first_move == 0 && board[7,3] == 0 && board[7,2] == 0 && board[7,1] == 0 && ny == 7 && nx == 2)
				{
					int ok = 1;
					ok = Check_White(board, 4, 7);
					if (ok == 1)
					{
						ok = Check_White(board, 3, 7);
						if (ok == 1)
						{
							ok = Check_White(board, 2, 7);
							if (ok == 1)
							{
								ok = Check_White(board, 1, 7);
								if (ok == 1)
								{
									board[7,0] = 0;
									board[7,3] = 2;
									kingW_first_move = 1;
									left_towerW_first_move = 1;
									return 1;
								}
							}
						}
					}
				}
				return 0;
			}

			// отримати координати білого короля
			//void update_KingW_pos()
			//{
			//	for (int i = 0; i < 8; i++)
			//	{
			//		for (int j = 0; j < 8; j++)
			//		{
			//			if (board[i,j] == KingWHITE)
			//			{
			//				kingW_pos.x = j;
			//				kingW_pos.y = i;
			//				break;
			//			}
			//		}
			//	}
			//}

			////отримати координати чорного короля
			//void update_KingB_pos()
			//{
			//	for (int i = 0; i < 8; i++)
			//	{
			//		for (int j = 0; j < 8; j++)
			//		{
			//			if (board[i,j] == KingBLACK)
			//			{
			//				kingB_pos.y = i;
			//				kingB_pos.x = j;
			//				break;
			//			}
			//		}
			//	}
			//}
		};
	}
