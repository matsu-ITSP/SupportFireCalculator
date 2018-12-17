using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SupportFireCalculator {
	public partial class Form1 : Form {

		private CheckBox[] criticals;
		private CheckBox[] halfBrokens;
		private TextBox[] enemyForm;
		private List<Enemy> enemys;
		private const int COLUMNMAX = 10;
		private const int ENEMYSMAX = 10000;
		private AutoCompleteStringCollection source;

		/*
		 * CSVをパースしてEnemyクラスの配列に格納
		 * searchNameを配列に
		 * textboxのautoCompに入れる
		 * 入力されたものをEnemyクラスの配列で検索
		 * ヒットしたものをEnemyAndAtkInfoに入れる
		 * 送る
		 * */

		public Form1() {
			InitializeComponent();
			criticals = new CheckBox[COLUMNMAX];
			halfBrokens = new CheckBox[COLUMNMAX];
			enemyForm = new TextBox[COLUMNMAX];
			enemys = new List<Enemy>();
			source = new AutoCompleteStringCollection();
			parser();
			addPanelColumn();
			
		}
		private void parser(){
			char[] cut = {','};
			List<String> lineEnemy = readFileList("csv_data.csv");
			String name;
			int hp;
			int arm;
			for(int i = 0 ; i < lineEnemy.Count ; i++){
				String[] temp = lineEnemy[i].Split(cut);
				//要素数3じゃなきゃバグったデータ
				//3でも２つ目、３つ目が数字じゃなきゃバグ
				if(temp.Count() == 3 && Int32.TryParse(temp[1],out hp) 
									 && Int32.TryParse(temp[2],out arm)){
					name = temp[0];
					enemys.Add(new Enemy(name,hp,arm));
				}
				//敵多すぎたら中断
				if(i > ENEMYSMAX){
					break;
				}
			}
			for(int i = 0 ; i < enemys.Count ; i++){
				source.Add(enemys[i].getsearchName());
			}
		}
		private List<string> readFileList(string path)
        {
            List<string> ret = new List<string>(); ;

            string str = null;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(
                path, System.Text.Encoding.GetEncoding("Shift-jis"))){
                while ((str = sr.ReadLine()) != null){
                    ret.Add(str);
                }
            }
            return ret;
        }
		private void buttonAdd_Click(object sender, EventArgs e) {
			addPanelColumn();
		}

		private void buttonCalc_Click(object sender, EventArgs e) {
			/*
			 * 送信データは
			 * ・連合か否か
			 * ・入力された敵と詳細情報をオブジェクトにしたものの配列
			 * */
			Result form = new Result(false,null);
			form.Show();
		}

		private void addPanelColumn(){
			if(tableLayoutPanel1.ColumnCount+1 > COLUMNMAX){
				return;
			}
			/*
			foreach (Control c in tableLayoutPanel1.Controls){
				TableLayoutPanelCellPosition pos =
				tableLayoutPanel1.GetPositionFromControl(c);
				tableLayoutPanel1.SetCellPosition(c, pos);
				if (tableLayoutPanel1.ColumnCount <= pos.Column)
					tableLayoutPanel1.ColumnCount = pos.Column + 1;
				if (tableLayoutPanel1.ColumnCount <= pos.Column)
					tableLayoutPanel1.ColumnCount = pos.Column + 1;
			}*/
			
			tableLayoutPanel1.ColumnCount++;
			int ccnt = tableLayoutPanel1.ColumnCount;
			criticals[ccnt-1] = new CheckBox();
			tableLayoutPanel1.Controls.Add(criticals[ccnt-1],ccnt-2,0);
			halfBrokens[ccnt-1] = new CheckBox();
			tableLayoutPanel1.Controls.Add(halfBrokens[ccnt-1],ccnt-2,1);
			enemyForm[ccnt-1] = new TextBox();
			tableLayoutPanel1.Controls.Add(enemyForm[ccnt-1],ccnt-2,2);
			//オートコンプリート設定
			enemyForm[ccnt-1].AutoCompleteMode = AutoCompleteMode.Suggest;
			enemyForm[ccnt-1].AutoCompleteSource = AutoCompleteSource.CustomSource;
			enemyForm[ccnt-1].AutoCompleteCustomSource = source;

			tableLayoutPanel1.Width += 200;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			// tableLayoutPanel自体にも高さを加える
			
		}

	}
}
