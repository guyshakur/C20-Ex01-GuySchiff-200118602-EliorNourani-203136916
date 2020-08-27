using System;

namespace UI
{
	class Program
	{

		public static void Main()
		{

			runningGameCheckers();
		}

		private static void runningGameCheckers()
		{
			NewGame game = new NewGame();
			Board board = new Board(game.SizeBoard);

		}


	}

	class NewGame
	{
		private String m_UserName;
		private String m_UserName2;
		private int m_SizeBoard;
		private bool m_TwoPlayers;

		public NewGame()
		{

			m_UserName = getFromUserTheUserName();
			m_SizeBoard = getFromUserTheSizeOfBoard();
			m_TwoPlayers = getFromUserIfHaveTwoPlayersInTheGame();
			if (m_TwoPlayers)
			{
				m_UserName2 = getFromUserTheUserName();
			}

		}

		private bool getFromUserIfHaveTwoPlayersInTheGame()
		{
			bool twoPlayers = false;
			int players;
			do
			{
				Console.Write("please choose how many player have in the game(1/2):");

			} while (!int.TryParse(Console.ReadLine(), out players) && (players == 1 || players == 2));

			if (players == 2)
			{
				twoPlayers = true;
			}
			return twoPlayers;
		}

		private int getFromUserTheSizeOfBoard()
		{

			int size;
			do
			{
				Console.Write("Please choose size of board (6,8,10):");
				int.TryParse(Console.ReadLine(), out size);

			} while (size != 6 && size != 8 && size != 10);

			return size;
		}

		private string getFromUserTheUserName()
		{
			String name;
			do
			{
				Console.WriteLine("Please enter your user name (please the name was without spaces and up to 20):");
				name = Console.ReadLine();

			} while (name.Length >= 20 || name.Contains(" ") || name.Length < 1);


			return name;
		}
		public int SizeBoard
		{
			get{ return m_SizeBoard; }
			
		}

	}
}
