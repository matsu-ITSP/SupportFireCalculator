using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	class EnemyAndAtkInfo {

		String name;
		int arm;
		int hp;
		Boolean isCritical;
		Boolean isHalfBroken;

		EnemyAndAtkInfo(String name,int arm,int hp,Boolean isCritical,Boolean isHalfBroken){
			this.name = name;
			this.arm = arm;
			this.hp = hp;
			this.isCritical = isCritical;
			this.isHalfBroken = isHalfBroken;
		}
	}
}
