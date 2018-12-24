using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	class Formation : MyEnum{

		public static readonly int FORMATIONNUM = 6;

		public Formation(){
			name = new List<string>{"単縦陣","複縦陣","輪形陣","梯形陣","単横陣","警戒陣"};
			pow = new List<double>{1.0 , 0.8 , 0.7 , 0.6 , 0.6 , 0.5};
		}

	}
}
