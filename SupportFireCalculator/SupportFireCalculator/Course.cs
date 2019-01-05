using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	//交戦隊形のenumみたいなもの
	public class Course : MyEnum {

		//enumなにもわからなかったのでやめる
		//public enum CourseName { Tyuri , Douko , Hanko , Tfuri };
		public static readonly int COURSENUM = 4;
		public Course(){
			names = new List<string>{"T有利","同航戦","反航戦","T不利"};
			pows = new List<double>{1.2 , 1.0 , 0.8 , 0.6};
		}
		/*
		//コース名を受け取って名前を返す
		public String getName(CourseName cname){
			int i = (int)cname;
			if(i >= name.Count) return "";//不要そうなエラー処理
			return name[i];
		}
		//コース名を受け取って補正倍率を返す
		public double getPow(CourseName cname){
			int i = (int)cname;
			if(i >= pow.Count) return -1.0;
			return pow[i];
		}
		 * */
	}
}
