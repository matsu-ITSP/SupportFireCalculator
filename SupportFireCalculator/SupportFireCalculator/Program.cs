using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace SupportFireCalculator {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>

		[STAThread]
		/*
		 * textboxのオートコンプリートで調べる
		 * 決定後、実行ボタンを押すと別窓でリストが出る
		 * 追加ボタンで縦列追加、10くらいまで
		 * ホームの要素:(クリティカルチェック、中破チェック、検索テキストボックス)追加ボタン、実行ボタン
		 * テキストボックスでヒットしないのが入力されたらその列は"-"で表示
		 * 実行画面:4*5or4*4表示
		 * */
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new StartForm());

		}
	}
}
