﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupportFireCalculator {
	public partial class Result : Form {

		//敵の名前表示したい

		readonly int COURSENUM = Course.COURSENUM;
		readonly int FORMATIONNUM = Formation.FORMATIONNUM;
		readonly int RENGOFORMATIONNUM = RengoFormation.RENGOFORMATIONNUM;

		Label[,] atkLabel;
		Label[] course;
		Label[] formation;
		Boolean isRengo;

		public Result(Boolean isRengo , List<EnemyAndAtkInfo> ls) {

			InitializeComponent();
			this.isRengo = isRengo;
			makeTable();
			initialLabel();
			//setLabel(calcAtk(ls[0]));
			setLabel(makeAtkText(ls));
			setLabelToTable();
		}
		private String[,] makeAtkText(List<EnemyAndAtkInfo> ls){
			String[,] ans = new String[COURSENUM,formationNum()];
			List<int[,]> atk = new List<int[,]>();

			for(int i = 0 ; i < ls.Count ; i++){
				atk.Add(calcAtk(ls[i]));
			}
			for(int i = 0 ; i < COURSENUM ; i++){
				for(int j = 0 ; j < formationNum() ; j++){
					ans[i,j] = null;
					for(int k = 0 ; k < ls.Count ; k++){
						ans[i,j] = ans[i,j] + atk[k][i,j].ToString() + "/";
					}
					ans[i,j] = ans[i,j].Remove(ans[i,j].Length-1);
					if(ans == null){
						ans[i,j] = "0";
					}
				}
			}
			return ans;
		}
		//体力・装甲から必要火力を計算する
		private int[,] calcAtk(EnemyAndAtkInfo enemy){
			int[,] ans = new int[COURSENUM,formationNum()];
			Course c = new Course();
			RengoFormation rf = new RengoFormation();
			Formation f = new Formation();
			
			for(int i = 0 ; i < COURSENUM ; i++){
				for(int j = 0 ; j < formationNum() ; j++){
					//todo
					if(enemy == null){
						ans[i,j] = 0;
					}else if(isRengo){
						ans[i,j] = enemy.getNeedAtk(c.getPow(i),rf.getPow(j));
					}else{
						ans[i,j] = enemy.getNeedAtk(c.getPow(i),f.getPow(j));
					}
				}
			}
			return ans;

		}
		//tableLayoutにラベルを当てはめる
		private void setLabelToTable(){
			for(int i = 0 ; i < COURSENUM ; i++){
				tableLayoutControlAdd(course[i],i+1,0);
			}
			for(int j = 0 ; j < formationNum() ; j++){
				tableLayoutControlAdd(formation[j],0,j+1);
			}
			for(int i = 0 ; i < COURSENUM ; i++){
				for(int j = 0 ; j < formationNum() ; j++){
					tableLayoutControlAdd(atkLabel[i,j],i+1,j+1);
				}
			}
		}
		//ラベルのテキストを入れる
		private void setLabel(String[,] atk){

			Course c = new Course();
			for(int i = 0 ; i < COURSENUM ; i++){
				course[i].Text = c.getName(i);
			}

			if(isRengo){
				RengoFormation rf = new RengoFormation();
				for(int i = 0 ; i < RENGOFORMATIONNUM ; i++){
					formation[i].Text = rf.getName(i);
				}
			}else{
				Formation f = new Formation();
				for(int i = 0 ; i < FORMATIONNUM ; i++){
					formation[i].Text = f.getName(i);
				}
			}
			for(int i = 0 ; i < COURSENUM ; i++){
				for(int j = 0 ; j < formationNum() ; j++){
					atkLabel[i,j].Text = atk[i,j];
				}
			}
		}
		//ラベルの初期化
		private void initialLabel(){
			atkLabel = new Label[COURSENUM ,formationNum()];
			course = new Label[COURSENUM];
			formation = new Label[formationNum()];
			
			for(int i = 0 ; i < COURSENUM * formationNum() ; i++){
				atkLabel[i%COURSENUM , i/COURSENUM] = new Label();
			}
			for(int i = 0 ; i < COURSENUM ; i++){
				course[i] = new Label();
			}
			for(int i = 0 ; i < formationNum() ; i++){
				formation[i] = new Label();
			}
		}
		//tableLayoutの作成
		private void makeTable(){
			for(int i = 0 ; i < formationNum() ; i++){
				tableAddOneColumn();
			}
		}
		//tableLayoutに1Column加える
		private void tableAddOneColumn(){
			tableLayoutPanel1.ColumnCount++;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			// tableLayoutPanel自体にも高さを加える
			tableLayoutPanel1.Width += 200;
		}
		//連合なら4,そうでないなら6を返す
		private int formationNum(){
			if(isRengo){
				return RENGOFORMATIONNUM;
			}else{
				return FORMATIONNUM;
			}
		}
		//tablelayoutの追加の第二引数がcolumn,第三がrowで直観と真逆できれたため
		private void tableLayoutControlAdd(Control control , int row , int column){
			tableLayoutPanel1.Controls.Add(control,column,row);
		}
	}
}
