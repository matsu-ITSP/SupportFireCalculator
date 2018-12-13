using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	public class Enemy {

		String name;
		int arm;
		int hp;
		String searchName;

		public Enemy(String name,int arm,int hp){
			this.name = name;
			this.arm = arm;
			this.hp = hp;
			this.searchName = name + "耐久:" + hp.ToString() + 
									 "装甲:" + arm.ToString();
		}
	}
}
