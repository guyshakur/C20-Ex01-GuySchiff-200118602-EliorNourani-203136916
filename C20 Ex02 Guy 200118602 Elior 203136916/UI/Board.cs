using System;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Ex02.ConsoleUtils;


namespace UI
{
    class Board
    {
        private int m_Col;
        private int m_Row;
        private string[,] m_BoardMat;
        private StringBuilder m_Shave = new StringBuilder(" ");
        private StringBuilder m_BoardToPrint =new StringBuilder("");
        

        public Board(int i_Size)
		{
            m_Col = i_Size * 4 + 2;
            m_Row = i_Size * 2 + 2;
            m_BoardMat = new string[m_Row, m_Col];
            
            for(int i=0;i<m_Col -1;i++)
			{
                m_Shave.Append("=");
			}
            for(int i = 0; i<m_Row;i++)
			{
                if(i==0)
				{
                    char bigLetter = 'A';
                    StringBuilder column = new StringBuilder("");
                    for(int j = 0; j < m_Col/4 ; j++)
					{
                        column.Append("   ");
                        column.Append(bigLetter);
                        bigLetter = (char)(((int)bigLetter) + 1);
					}
					m_BoardToPrint.AppendLine(column.ToString());
                }
                else if (i%2==1)
				{
                    m_BoardToPrint.AppendLine(m_Shave.ToString());  
				}
				else
				{
                    
                }
                
			}

        }
        public void ShowBoard()
		{
            Screen.Clear(); //clear screen
            //col = size of array need to m_size * 4 + 2
            //row = size of array need to m_size * 2 + 2
            Console.WriteLine(m_BoardToPrint);

            
        }
        
    }
}
