using System;
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

		const int COURSENUM = 4;
		const int FORMATIONNUM = 6;
		const int RENGOFORMATIONNUM = 4;

		Label[,] atkLabel;
		Label[] course;
		Label[] formation;
		Boolean isRengo;

		public Result(Boolean isRengo , List<EnemyAndAtkInfo> ls) {

			InitializeComponent();
			this.isRengo = isRengo;
			makeTable();
			initialLabel();
			setLabel(calcAtk(ls));
			setLabelToTable();
		}
		//体力・装甲から必要火力を計算する
		private int[,] calcAtk(List<EnemyAndAtkInfo> ls){
			int[,] ans = new int[COURSENUM,formationNum()];

			for(int i = 0 ; i < COURSENUM ; i++){
				for(int j = 0 ; j < formationNum() ; j++){
					//todo
					ans[i,j] = 0;
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
		private void setLabel(int[,] atk){
			course[0].Text = "T有利";
			course[1].Text = "同航戦";
			course[2].Text = "反航戦";
			course[3].Text = "T不利";

			if(isRengo){
				formation[0].Text = "第一(対潜警戒)";
				formation[1].Text = "第二(前方警戒)";
				formation[2].Text = "第三(輪形陣)";
				formation[3].Text = "第四(戦闘隊形)";
			}else{
				formation[0].Text = "単縦陣";
				formation[1].Text = "複縦陣";
				formation[2].Text = "輪形陣";
				formation[3].Text = "梯形陣";
				formation[4].Text = "単横陣";
				formation[5].Text = "警戒陣";
			}
			for(int i = 0 ; i < COURSENUM ; i++){
				for(int j = 0 ; j < formationNum() ; j++){
					atkLabel[i,j].Text = atk[i,j].ToString();
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
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			// tableLayoutPanel自体にも高さを加える
			tableLayoutPanel1.Width += 100;
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
