using System;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Ex02.ConsoleUtils;
using Logic;


namespace UI
{
	class Board
	{
		private int m_ColBoardToPrint;
		private int m_RowBoardToPrint;
		private e_Soldier[,] m_BoardMat;
		private int m_SizeBoard;



		public Board(int i_Size)
		{
			m_ColBoardToPrint = i_Size * 4 + 2;
			m_RowBoardToPrint = i_Size * 2 + 2;
			m_SizeBoard = i_Size;
			m_BoardMat = new e_Soldier[i_Size, i_Size];
			setTheSoldierOnTheBoard();
			showBoard();
		}

		private void setTheSoldierOnTheBoard()
		{
			for (int i = 0; i < m_SizeBoard; i++)
			{
				for (int j = 0; j < m_SizeBoard; j++)
				{
					if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
					{
						m_BoardMat[i, j] = e_Soldier.N;
					}
					else if (i < m_SizeBoard / 2 - 1)
					{
						m_BoardMat[i, j] = e_Soldier.O;
					}
					else if (i > (m_SizeBoard / 2))
					{
						m_BoardMat[i, j] = e_Soldier.X;
					}
					else
					{
						m_BoardMat[i, j] = e_Soldier.E;
					}
				}
			}
		}

		public void showBoard()
		{
			Screen.Clear(); //clear screen
			StringBuilder m_Shave = new StringBuilder(" ");
			StringBuilder m_BoardToPrint = new StringBuilder("");
			for (int i = 0; i < m_ColBoardToPrint - 1; i++)
			{
				m_Shave.Append("=");
			}
			char smallLetter = 'a';
			int iToMatBoard = 0, jToMatBoard = 0;
			for (int i = 0; i < m_RowBoardToPrint; i++)
			{
				if (i == 0)
				{
					char bigLetter = 'A';
					StringBuilder column = new StringBuilder("");
					for (int j = 0; j < m_SizeBoard; j++)
					{
						column.Append("   ");
						column.Append(bigLetter);
						bigLetter = (char)(((int)bigLetter) + 1);
					}
					m_BoardToPrint.AppendLine(column.ToString());
				}
				else if (i % 2 == 1)
				{
					m_BoardToPrint.AppendLine(m_Shave.ToString());
				}
				else
				{

					for (int j = 0; j < m_ColBoardToPrint; j++)
					{
						if (j == 0)
						{
							m_BoardToPrint.Append(smallLetter);
							smallLetter = (char)(((int)smallLetter) + 1);
						}
						else if (j % 4 == 1)
						{
							m_BoardToPrint.Append('|');
						}
						else if ((j % 4 == 3 && i % 2 == 0) || (i % 2 == 2 && j % 4 == 7))
						{ 
							if (m_BoardMat[iToMatBoard, jToMatBoard] == e_Soldier.O ||
								m_BoardMat[iToMatBoard, jToMatBoard] == e_Soldier.X ||
								m_BoardMat[iToMatBoard, jToMatBoard] == e_Soldier.K ||
								m_BoardMat[iToMatBoard, jToMatBoard] == e_Soldier.U)
							{
								m_BoardToPrint.Append(m_BoardMat[iToMatBoard, jToMatBoard]);
							}
							else
							{
								m_BoardToPrint.Append(" ");
							}
							if (jToMatBoard < m_SizeBoard - 1)
							{
								jToMatBoard++;
							}
							else
							{
								jToMatBoard = 0;
								iToMatBoard++;
							}

						}
						else
						{
							m_BoardToPrint.Append(" ");
						}
					}
					m_BoardToPrint.AppendLine("");
				}

			}
			Console.WriteLine(m_BoardToPrint);


		}

	}
}
