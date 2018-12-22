using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SupportFireCalculator {
	public class EnemyAndAtkInfo : Enemy {

		/*
		 * ダメージ = [[ (キャップ後火力 - 防御力)] * クリティカル補正] * PT補正
		 * 
		 * 防御力 = 装甲 × 0.7 + 整数乱数(0 ～ 装甲-1) × 0.6 － 装甲破砕効果
		 * 最高防御力 = 装甲 × 1.3 - 0.6
		 * 最低防御力 = 装甲 × 0.7
		 * 
		 * キャップ前攻撃力 = 基本攻撃力 × キャップ前補正
		 * キャップ後攻撃力 = キャップ値 ＋ √(キャップ前攻撃力 － キャップ値)
		 * 
		 * 基本攻撃力 = 火力 + 支援艦隊定数(+4)
		 * キャップ前補正 = 交戦隊形補正*陣形補正
		 * 交戦隊形補正   = (T有利:1.2 , 同航:1.0 , 反航;0.8 , T不利:0.6)
		 * 陣形補正(通常) = (単縦:1.0 , 複縦:0.8 , 輪形:0.7 , 梯形:0.6 , 単横:0.6 , 警戒:0.5)
		 * 陣形補正(連合) = (第一:0.8 , 第二:1.0 , 第三:0.7 , 第四:1.0) 
		 * 第四は1.0か1.1かよくわからない
		 *  
		 * キャップ値:150
		 *	
		 * PT補正
		 * 機銃x2以上		1.1倍	
		 * 小口径主砲x2以上	1.2倍	速吸・秋津洲は対象外
		 * 副砲x2以上		1.2倍	軽巡/雷巡は対象外
		 * 三式弾x1以上		1.3倍	2個以上装備しても1.3倍
		 * 
		 * プログラミングっぽく
		 * dmg = [[fire - (arm*1.3-0.6)] * (isCritical ? 1.5 : 1.0)] * (pt)
		 * pt = めんどくさい式
		 * defFire = (atk + 4) * form * course
		 * fire = if (defFire < cap) defFire (cap + sqrt(defFire - cap))
		 * 
		 * fire = cap + sqrt(defFire - cap)
		 * defFire = (fire - cap)^2 + cap
		 * atk = defFire / form / course - 4
		 *     = ((fire - cap)^2 + cap) / form / course - 4
		 * 
		 * 上の逆算っぽく,ptは無視
		 * 切り上げ:{}でかく
		 * arm,hp,isCritical,course,formはとれる
		 * cap = 150
		 * crt = isCritical ? 1.5 : 1.0
		 * armMax = arm*1.3-0.6
		 * fire = {{hp / crt} + armMax} //fireは一意
		 * atk = if (fire < cap) ((fire / form / course) - 4)
		 *		    (((fire - cap)^2 + cap) / form / course - 4)
		 * 
		 * */

		Boolean isCritical;
		Boolean isHalfBroken;
		const int CAP = 150;

		public EnemyAndAtkInfo(String name,int arm,int hp,Boolean isCritical,Boolean isHalfBroken)
			: base(name,hp,arm)
		{
			this.isCritical = isCritical;
			this.isHalfBroken = isHalfBroken;
		}
	}
}
