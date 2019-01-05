using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	public abstract class MyEnum {

		protected List<String> names;
		protected List<double> pows;

		//何番目かを受け取って名前を返す、オーバーフローなら空列を返す
		public String getName(int num){
			if(num >= names.Count) return "";
			return names[num];
		}
		//何番目かを受け取って補正倍率を返す、オーバーフローなら空列を返す
		public double getPow(int num){
			if(num >= pows.Count) return -1.0;
			return pows[num];
		}
	}
}
