using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Ex02.ConsoleUtils;
using Logic;


namespace UI
{



	public enum e_ColPosition
	{
		A,
		B,
		C,
		D,
		E,
		F,
		G,
		H,
		I,
		J,
		K,
		L,
		M,
		N,
		O,
		P,
		Q,
		R,
		S,
		T,
		U,
		V,
		W,
		X,
		Y,
		Z
	}
	public enum e_RowPosition
	{
	a,
	b,
	c,
	d,
	e,
	f,
	g,
	h,
	i,
	j,
	k,
	l,
	m,
	n,
	o,
	p,
	q,
	r,
	s,
	t,
	u,
	v,
	w,
	x,
	y,
	z
	}


	public enum e_Squares
    {
		B, //available for soldier to walk in
		W  //not available for soldier to walk in
    }

class Board
	{
		private e_Squares [,] m_squareColor;
		private int m_ColBoardToPrint;
		private int m_RowBoardToPrint;
		private e_Soldier[,] m_BoardMat;
		private int m_SizeBoard;
		private List<Soldier> soldiersOfPlayer1;
		private List<Soldier> soldiersOfPlayer2;
		private Position posOfSquareOnBoard;
		private int indexToRow = 0;
		private int indexToCol = 0;
		private StringBuilder m_BoardToPrint = new StringBuilder("");

		public Board(int i_Size)
		{
            soldiersOfPlayer1 = new List<Soldier>();
			soldiersOfPlayer2 = new List<Soldier>();
			m_ColBoardToPrint = i_Size * 4 + 2;
			m_RowBoardToPrint = i_Size * 2 + 2;
			m_SizeBoard = i_Size;
			m_squareColor = new e_Squares[i_Size, i_Size];
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
						m_squareColor[i, j] = e_Squares.W;
						
					}
					else if (i < m_SizeBoard / 2 - 1)
					{
						Position position = new Position(i, j);
						Soldier s = new Soldier(e_Soldier.O,position);
						m_squareColor[i, j] = e_Squares.B;
						m_BoardMat[i, j] = s.m_typeOfSolder;
						soldiersOfPlayer2.Add(s);
					}
					else if (i > (m_SizeBoard / 2))
					{
						Position position = new Position(i, j);
						Soldier s = new Soldier(e_Soldier.X,position);
						m_squareColor[i, j] = e_Squares.B;
						m_BoardMat[i, j] = s.m_typeOfSolder;
						soldiersOfPlayer1.Add(s);
					}
					else
					{
						m_squareColor[i, j] = e_Squares.B;
					
					}
				}
			}
			
		}

		public void showBoard()
		{
			Screen.Clear(); //clear screen
			StringBuilder m_Shave = new StringBuilder(" ");
			m_BoardToPrint = new StringBuilder("");
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
		public void updateSoldiersOnBoard()
        {
			showBoard();
			Screen.Clear(); //clear screen
			//m_BoardToPrint.
			Console.WriteLine(m_BoardToPrint);


		}


	}

	}



