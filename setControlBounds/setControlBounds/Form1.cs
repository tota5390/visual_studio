using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace setControlBounds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_load;
        }

        private Size form_size, base_size = new Size(1600, 900);
        private void Form1_load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;   //初期フォーム最大化
            form_size = this.Size;                          //最大化後のサイズ記録
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = !this.MaximizeBox;
            this.MinimizeBox = !this.MinimizeBox;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.LocationChanged += new EventHandler(this.Form1LocationChanged);
        }

        private void Form1LocationChanged(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            Console.WriteLine("フォームが({0}, {1})に移動しました", c.Left, c.Top);
        }

        //DataGridViewのデータをCSV出力する関数
        private void outputCSV(DataGridView data_grid_view, string file_name)
        {
            string FILE_PATH = @file_name + ".csv";
            string msg = "";
            if (data_grid_view.RowCount <= 1)//行がヘッダー以外ない場合
            {
                msg = "出力データがありません。";
                MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            msg = "CSVファイルを出力します。" + "\n" + "宜しいですか？";
            DialogResult result = MessageBox.Show(msg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }
            using (StreamWriter sw = new StreamWriter(FILE_PATH, false, System.Text.Encoding.Default))
            {
                int col_cnt = data_grid_view.ColumnCount - 1;//削除ボタンの分，列を減らす
                string s = " ";
                for (int col_i = 0; col_i < col_cnt; col_i++)
                {
                    String s_cell = data_grid_view.Columns[col_i].HeaderCell.Value.ToString();
                    if (col_i > 0)
                    {
                        s += ",";
                    }
                    s += quoteCommaCheck(s_cell);
                }
                sw.WriteLine(s);
                int maxRowsCount = data_grid_view.Rows.Count;
                if (data_grid_view.AllowUserToAddRows)
                {
                    maxRowsCount = maxRowsCount - 1;// 入力部分の行は含まない
                }
                for (int iRow = 0; iRow < maxRowsCount; iRow++)
                {
                    s = "";
                    for (int iCol = 0; iCol < col_cnt; iCol++)
                    {
                        object input_data = data_grid_view[iCol, iRow].Value;
                        if (input_data == null)
                        {
                            msg = "入力されていないデータがあります";
                            MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        String sCell = input_data.ToString();
                        if (iCol > 0)
                        {
                            s += ",";
                        }
                        s += quoteCommaCheck(sCell);
                    }
                    sw.WriteLine(s);
                }
            }
            msg = "CSV出力が完了しました。";
            MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //入力された文にダブルクォートやコンマが含まれているとき文として区切る関数
        private string quoteCommaCheck(string s_cell)
        {
            const string quote = @"""";
            const string comma = @",";
            string[] or_search = new string[] { quote, comma };
            if (or_search.Any(s_cell.Contains))
            {
                s_cell = s_cell.Replace(quote, quote + quote);
                s_cell = quote + s_cell + quote;
            }
            return s_cell;
        }
    }
}
