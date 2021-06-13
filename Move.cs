using System;
using System.Collections.Generic;
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
   public static class  Move
    {
		public static int Move_PawnW(int[,] board, int ox, int oy, int nx, int ny)
		{

			if (oy == 6)// ïåðøèé õ³ä íà 2 êë³òèíêè
			{
				if ((ny == oy - 1 && nx == ox &&  board[oy - 1, ox] == 0) || (ny == oy - 2 && nx == ox && board[oy - 1, ox] == 0 && board[oy - 2, ox] == 0))
				{
					return 1;
				}
			}
			else if (ny == oy - 1 && nx == ox && board[oy - 1, ox] == 0)// õ³ä íà îäíó êë³òèíêó
			{
				return 1;
			}
			if (ox != 0 && oy !=0)
			{
				if (board[oy - 1, ox - 1] < 0)// àòàêà íàë³âî
				{
					if (ny == oy - 1 && nx == ox - 1)
					{
						return 1;
					}
				}
			}
			if (ox != 7 && oy != 0) {
				if (board[oy - 1, ox + 1] < 0)// àòàêà íàïðàâî
				{
					if (ny == oy - 1 && nx == ox + 1)
					{
						return 1;
					}
				}
			}
            return 0;
		}
		public static int Move_PawnB(int[,] board, int ox, int oy, int nx, int ny)
		{
			if (oy == 1)// ïåðøèé õ³ä íà 2 êë³òèíêè
			{
				if ((ny == oy + 1 && nx == ox && board[oy + 1, ox] == 0) || (ny == oy + 2 && nx == ox && board[oy + 1, ox] == 0 && board[oy + 2, ox] == 0))
				{
					return 1;
				}
			}
			else if (ny == oy + 1 && nx == ox && board[oy + 1, ox] == 0)// õ³ä íà îäíó êë³òèíêó
			{
				return 1;
			}
			if (ox != 0 && oy != 7)
			{
				if (board[oy + 1, ox - 1] > 0)// àòàêà íàë³âî
			{
				if (ny == oy + 1 && nx == ox - 1)
				{
					return 1;
				}
			}
		}
			if (ox != 7 && oy != 7)
			{
				if (board[oy + 1, ox + 1] > 0)// àòàêà íàïðàâî
				{
					if (ny == oy + 1 && nx == ox + 1)
					{
						return 1;
					}
				}
			}
			return 0;
		}

		public static int Move_RookW(int[,] board, int ox, int oy, int nx, int ny)
		{
			for (int i = ox - 1; i >= 0; i--) // õ³ä íàë³âî
			{
				if (board[oy,i] <= 0 && (nx == i && ny == oy))
				{
					return 1;
				}
				else if (board[oy,i] != 0)
				{
					break;
				}
			}
			for (int i = oy - 1; i >= 0; i--) // õ³ä ââåðõ
			{
				if (board[i,ox] <= 0 && (ny == i && nx == ox))
				{
					return 1;
				}
				else if (board[i,ox] != 0)
				{
					break;
				}
			}
			for (int i = ox + 1; i <= 7; i++) // õ³ä íà ïðàâî
			{
				if (board[oy,i] <= 0 && (ny == oy && nx == i))
				{
					return 1;
				}
				else if (board[oy,i] != 0)
				{
					break;
				}
			}
			for (int i = oy + 1; i <= 7; i++) // õ³ä âíèç
			{
				if (board[i,ox] <= 0 && (ny == i && nx == ox))
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
		public static int Move_RookB(int[,] board, int ox, int oy, int nx, int ny)
		{
			for (int i = ox - 1; i >= 0; i--) // õ³ä íàë³âî
			{
				if (board[oy, i] >= 0 && (nx == i && ny == oy))
				{
					return 1;
				}
				else if (board[oy, i] != 0)
				{
					break;
				}
			}
			for (int i = oy - 1; i >= 0; i--) // õ³ä ââåðõ
			{
				if (board[i, ox] >= 0 && (ny == i && nx == ox))
				{
					return 1;
				}
				else if (board[i, ox] != 0)
				{
					break;
				}
			}
			for (int i = ox + 1; i <= 7; i++) // õ³ä íàïðàâî
			{
				if (board[oy, i] >= 0 && (ny == oy && nx == i))
				{
					return 1;
				}
				else if (board[oy, i] != 0)
				{
					break;
				}
			}
			for (int i = oy + 1; i <= 7; i++) // õ³ä âíèç
			{
				if (board[i, ox] >= 0 && (ny == i && nx == ox))
				{
					return 1;
				}
				else if (board[i, ox] != 0)
				{
					break;
				}
			}
			return 0;
		}

		public static int Move_BishopW(int[,] board, int ox, int oy, int nx, int ny)
		{
			int j = ox - 1;
			for (int i = oy - 1; i >= 0; i--) // õ³ä íàë³âî ââåðõ
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j--;
			}
			j = ox + 1;
			for (int i = oy - 1; i >= 0; i--) // õ³ä íàïðàâî ââåðõ
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j++;
			}
			j = ox - 1;
			for (int i = oy + 1; i <= 7; i++) // õ³ä íàë³âî âíèç
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j--;
			}
			j = ox + 1;
			for (int i = oy + 1; i <= 7; i++)  // õ³ä íàë³âî âïðàâî
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j++;
			}
			return 0;
		}
		public static int Move_BishopB(int[,] board, int ox, int oy, int nx, int ny)
		{
			//MessageBox.Show("M0 ox = " + ox.ToString() + "oy = " + oy.ToString()+ "nx = " +nx.ToString() + "ny = " + ny.ToString());
			int j = ox - 1;
			for (int i = oy - 1; i >= 0; i--) // õ³ä íàë³âî ââåðõ
			{
				//MessageBox.Show("M1 i = " + i.ToString() + "j = " + j.ToString());
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}

					else if (board[i, j] != 0)
					{
						break;
					}
					
				}
				j--;
			}
			j = ox + 1;
            for (int i = oy - 1; i >= 0; i--) // õ³ä íàïðâî ââåðõ
            {
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
                j++;
            }
            j = ox - 1;
            for (int i = oy + 1; i <= 7; i++) // õ³ä íàë³âî âíèç
            {
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
                j--;
            }
            j = ox + 1;
            for (int i = oy + 1; i <= 7; i++)  // õ³ä íàïðàâî âíèç 
            {
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
                j++;
            }
            return 0;
		}

		public static int Move_QueenW(int[,] board,  int ox, int oy, int nx, int ny)
		{
			for (int i = ox - 1; i >= 0; i--) // õ³ä íàë³âî
			{
				if (board[oy,i] <= 0 && (nx == i && ny == oy))
				{
					return 1;
				}
				else if (board[oy,i] != 0)
				{
					break;
				}
			}
			for (int i = oy - 1; i >= 0; i--) // õ³ä ââåðõ
			{
				if (board[i,ox] <= 0 && (ny == i && nx == ox))
				{
					return 1;
				}
				else if (board[i,ox] != 0)
				{
					break;
				}
			}
			for (int i = ox + 1; i <= 7; i++) // õ³ä íàïðàâî
			{
				if (board[oy,i] <= 0 && (ny == oy && nx == i))
				{
					return 1;
				}
				else if (board[oy,i] != 0)
				{
					break;
				}
			}
			for (int i = oy + 1; i <= 7; i++) // õ³ä âíèç
			{
				if (board[i,ox] <= 0 && (ny == i && nx == ox))
				{
					return 1;
				}
				else if (board[i,ox] != 0)
				{
					break;
				}
			}


			int j = ox - 1;
			for (int i = oy - 1; i >= 0; i--) // õ³ä íàë³âî ââåðõ
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j--;
			}
			j = ox + 1;
			for (int i = oy - 1; i >= 0; i--) // õ³ä íàïðàâî ââåðõ
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j++;
			}
			j = ox - 1;
			for (int i = oy + 1; i <= 7; i++) // õ³ä íàë³âî âíèç
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j--;
			}
			j = ox + 1;
			for (int i = oy + 1; i <= 7; i++)  // õ³ä íàïðàâî âíèç
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] <= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j++;
			}
			return 0;
		}
		public static int Move_QueenB(int[,] board,  int ox, int oy, int nx, int ny)
		{
			for (int i = ox - 1; i >= 0; i--) // õ³ä íàë³âî
			{
				if (board[oy,i] >= 0 && (nx == i && ny == oy))
				{
					return 1;
				}
				else if (board[oy,i] != 0)
				{
					break;
				}
			}
			for (int i = oy - 1; i >= 0; i--) // õ³ä ââåðõ
			{
				if (board[i,ox] >= 0 && (ny == i && nx == ox))
				{
					return 1;
				}
				else if (board[i,ox] != 0)
				{
					break;
				}
			}
			for (int i = ox + 1; i <= 7; i++) // õ³ä íàïðàâî
			{
				if (board[oy,i] >= 0 && (ny == oy && nx == i))
				{
					return 1;
				}
				else if (board[oy,i] != 0)
				{
					break;
				}
			}
			for (int i = oy + 1; i <= 7; i++) // õ³ä âíèç
			{
				if (board[i,ox] >= 0 && (ny == i && nx == ox))
				{
					return 1;
				}
				else if (board[i,ox] != 0)
				{
					break;
				}
			}
			int j = ox - 1;
			for (int i = oy - 1; i >= 0; i--) // õ³ä íàë³âî ââåðõ
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j--;
			}
			j = ox + 1;
			for (int i = oy - 1; i >= 0; i--) // õ³ä íàïðàâî ââåðõ
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j++;
			}
			j = ox - 1;
			for (int i = oy + 1; i <= 7; i++) // õ³ä íàë³âî âíèç
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j--;
			}
			j = ox + 1;
			for (int i = oy + 1; i <= 7; i++)  // õ³ä íàïðàâî âíèç
			{
				if (i >= 0 && j >= 0 && i <= 7 && j <= 7)
				{
					if (board[i, j] >= 0 && (ny == i && nx == j))
					{
						return 1;
					}
					else if (board[i, j] != 0)
					{
						break;
					}
				}
				j++;
			}
			return 0;
		}

		public static int Move_KnightB(int[,] board, int ox, int oy, int nx, int ny)
		{
			if (oy - 1 >= 0 && ox - 2 >= 0 && ny == oy - 1 && nx == ox - 2 && board[ny,nx] >= 0)
			{
				return 1;// õ³ä íàë³âî ââåðõ --
			}
			if (oy - 2 >= 0 && ox - 1 >= 0 && ny == oy - 2 && nx == ox - 1 && board[ny,nx] >= 0)
			{
				return 1; // õ³ä íàë³âî ââåðõ |
			}
			if (oy - 2 >= 0 && ox + 1 < 8 && ny == oy - 2 && nx == ox + 1 && board[ny,nx] >= 0)
			{
				return 1; //õ³ä íàïðàâî ââåðõ |
			}
			if (oy - 1 >= 0 && ox + 2 < 8 && ny == oy - 1 && nx == ox + 2 && board[ny,nx] >= 0)
			{
				return 1; // õ³ä íàïðàâî ââåðõ --
			}
			if (oy + 1 >= 0 && ox + 2 < 8 && ny == oy + 1 && nx == ox + 2 && board[ny,nx] >= 0 && board[ny,nx] != 9)
			{
				return 1; // õ³ä íàïðàâî âíèç --
			}
			if (oy + 2 < 8 && ox + 1 < 8 && ny == oy + 2 && nx == ox + 1 && board[ny,nx] >= 0)
			{
				return 1; // õ³ä íàïðàâî âíèç |
			}
			if (oy + 2 < 8 && ox - 1 >= 0 && ny == oy + 2 && nx == ox - 1 && board[ny,nx] >= 0)
			{
				return 1; // õ³ä íàë³âî âíèç |
			}
			if (oy + 1 < 8 && ox - 2 >= 0 && ny == oy + 1 && nx == ox - 2 && board[ny,nx] >= 0)
			{
				return 1; // õ³ä íàë³âî âíèç --
			}
			return 0;
		}
		public static int Move_KnightW(int[,] board, int ox, int oy, int nx, int ny)
		{

			if (oy - 1 >= 0 && ox - 2 >= 0 && ny == oy - 1 && nx == ox - 2 && board[ny,nx] <= 0)
			{
				return 1; //õ³ä íàë³âî ââåðõ -- 
			}
			if (oy - 2 >= 0 && ox - 1 >= 0 && ny == oy - 2 && nx == ox - 1 && board[ny,nx] <= 0)
			{
				return 1; // õ³ä íàë³âî ââåðõ |
			}
			if (oy - 2 >= 0 && ox + 1 < 8 && ny == oy - 2 && nx == ox + 1 && board[ny,nx] <= 0)
			{
				return 1; // õ³ä íàïðàâî ââåðõ |
			}
			if (oy - 1 >= 0 && ox + 2 < 8 && ny == oy - 1 && nx == ox + 2 && board[ny,nx] <= 0)
			{
				return 1; // õ³ä íàïðàâî ââåðõ --
			}
			if (oy + 1 >= 0 && ox + 2 < 8 && ny == oy + 1 && nx == ox + 2 && board[ny,nx] <= 0)
			{
				return 1; // õ³ä íàïðàâî âíèç --
			}
			if (oy + 2 < 8 && ox + 1 < 8 && ny == oy + 2 && nx == ox + 1 && board[ny,nx] <= 0)
			{
				return 1; // õ³ä íàïðàâî âíèç |
			}
			if (oy + 2 < 8 && ox - 1 >= 0 && ny == oy + 2 && nx == ox - 1 && board[ny,nx] <= 0)
			{
				return 1; // õ³ä íàë³âî âíèç |
			}
			if (oy + 1 < 8 && ox - 2 >= 0 && ny == oy + 1 && nx == ox - 2 && board[ny,nx] <= 0)
			{
				return 1; //  õ³ä íàë³âî âíèç --
			}
			return 0;
		}
	}


}
