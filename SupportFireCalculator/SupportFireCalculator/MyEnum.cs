using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	public abstract class MyEnum {

		protected List<String> name;
		protected List<double> pow;

		//何番目かを受け取って名前を返す、オーバーフローなら空列を返す
		public String getName(int num){
			if(num >= name.Count) return "";
			return name[num];
		}
		//何番目かを受け取って補正倍率を返す、オーバーフローなら空列を返す
		public double getPow(int num){
			if(num >= pow.Count) return -1.0;
			return pow[num];
		}
	}
}
