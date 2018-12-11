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
		private CheckBox[] harfBrokens;
		private TextBox[] enemys;
		private const int COLUMNMAX = 10;
		public Form1() {
			InitializeComponent();
			criticals = new CheckBox[COLUMNMAX];
			harfBrokens = new CheckBox[COLUMNMAX];
			enemys = new TextBox[COLUMNMAX];
			addPanelColumn();
		}

		private void buttonAdd_Click(object sender, EventArgs e) {
			addPanelColumn();
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
			harfBrokens[ccnt-1] = new CheckBox();
			tableLayoutPanel1.Controls.Add(harfBrokens[ccnt-1],ccnt-2,1);
			enemys[ccnt-1] = new TextBox();
			tableLayoutPanel1.Controls.Add(enemys[ccnt-1],ccnt-2,2);

			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			// tableLayoutPanel自体にも高さを加える
			tableLayoutPanel1.Width += 50;
		}



	}
}
