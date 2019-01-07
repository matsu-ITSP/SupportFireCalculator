using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	public class Enemy {

		protected String name;
		protected int hp;
		protected int arm;
		private String searchName;

		public Enemy(String name,int hp,int arm){
			this.name = name;
			this.hp = hp;
			this.arm = arm;
			this.searchName = name + "<耐久:" + hp.ToString() + "," +
									 "装甲:" + arm.ToString() + ">";
		}
		public String getsearchName(){
			return searchName;
		}
		public String getName(){
			return name;
		}
		public int getHp(){
			return hp;
		}
		public int getArm(){
			return arm;
		}
	}
}
