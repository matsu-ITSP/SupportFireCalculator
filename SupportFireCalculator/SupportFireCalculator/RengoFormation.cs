using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	class RengoFormation : MyEnum{
		public static readonly int RENGOFORMATIONNUM = 4;

		public RengoFormation(){
			name = new List<string>{"第一(対潜警戒)","第二(前方警戒)","第三(輪形陣)","第四(戦闘隊形)"};
			pow = new List<double>{0.8 , 1.0 , 0.7 , 1.0};//4つ目は1.0か1.1か不明
		}
	}
}
