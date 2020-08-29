using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

	public enum e_Soldier
	{
		N,      //Not in game(the cells the soldiers can not to stay them)  
		O,      //Soldier of O
		U,      //King of O
		X,      //Soldier of X
		K,      //King Of X
		E       //Cells is Empty but soldier can to stay here.
	}

	public class Soldier
	{
		public e_Soldier m_typeOfSolder;
		public Position m_soldierPositionOnBoard;

		public Soldier(e_Soldier soldierType, Position soldierPosition)
		{

			this.m_typeOfSolder = soldierType;
			this.m_soldierPositionOnBoard = soldierPosition;




		}
	}
}
