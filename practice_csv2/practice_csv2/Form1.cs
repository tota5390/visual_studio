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
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace practice_csv2
{
    public partial class Form1 : Form
    {
        private Button[] many_buttons;

        public Form1()
        {
            InitializeComponent();
            this.many_buttons = null;
        }


        private Size form_size, base_size = new Size(1600, 900);

        BoundsSpecified setting_button_bounds = new BoundsSpecified();

        private const string form1_file_name = "csv_practice";
        private Button[] form1_button;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;   //初期フォーム最大化
            form_size = this.Size;                          //最大化後のサイズ記録

            form1_button = this.loadButtonCSV(form1_file_name);
            this.setButtons(form1_button);

            var data_grid_view = SetDataGridView(ref g_data_grid_view, this.ClientSize);
            this.Controls.Add(data_grid_view);

            form1_button[0].Click += new EventHandler(this.dataButtonClick);
            form1_button[1].Click += new EventHandler(this.setButtonClick);
        }

        private Button[] loadButtonCSV(string file_name)
        {
            const int text = 0, left = 1, top = 2, width = 3, height = 4;
            List<List<string>> button_table = new List<List<string>>();
            button_table = this.readCSV(file_name, true);
            Button[] buttons = new Button[button_table.Count];
            for (int i = 0; i < button_table.Count; i++)
            {
                buttons[i] = new Button();
                buttons[i].Text = button_table[i][text];
                buttons[i].Left = Int32.Parse(button_table[i][left]);
                buttons[i].Top = Int32.Parse(button_table[i][top]);
                buttons[i].Width = Int32.Parse(button_table[i][width]);
                buttons[i].Height = Int32.Parse(button_table[i][height]);
                buttons[i] = calcButton(ref buttons[i], this.ClientSize);
            }
            return buttons;
        }
        
        private void setButtons(Button[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                this.Controls.Add(buttons[i]);
            }
        }

        private void dataButtonClick(object sender, EventArgs e)
        {
            const string file_name = "csv_practice";
            this.outputCSV(g_data_grid_view, file_name);
        }

        //DataGridViewのデータをCSV出力する関数
        private void outputCSV(DataGridView data_grid_view, string file_name)
        {
            string FILE_PATH = @file_name + ".csv";
            string msg = "";
            const int price_col = 2, stock_col = 3;

            if (g_data_grid_view.RowCount <= 1)//行がヘッダー以外ない場合
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

            using (StreamWriter sw = new StreamWriter(FILE_PATH, false, System.Text.Encoding.UTF8))
            {
                int col_cnt = g_data_grid_view.ColumnCount - 1;//削除ボタンの分，列を減らす
                string s = " ";
                //ヘッダーについて
                for (int col_i = 0; col_i < col_cnt; col_i++)
                {
                    String s_cell = g_data_grid_view.Columns[col_i].HeaderCell.Value.ToString();
                    if (col_i > 0)
                    {
                        s += ",";
                    }
                    s += quoteCommaCheck(s_cell);
                }
                sw.WriteLine(s);

                int maxRowsCount = g_data_grid_view.Rows.Count;
                if (g_data_grid_view.AllowUserToAddRows)
                {
                    maxRowsCount = maxRowsCount - 1;// 入力部分の行は含まない
                }

                //入力データについて
                for (int iRow = 0; iRow < maxRowsCount; iRow++)
                {
                    s = "";
                    for (int iCol = 0; iCol < col_cnt; iCol++)
                    {
                        object input_data = g_data_grid_view[iCol, iRow].Value;
                        if(input_data == null)
                        {
                            msg = "入力されていないデータがあります";
                            MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        String s_cell = input_data.ToString();
                        double d = 0;
                        if ((iCol == price_col || iCol == stock_col) && !double.TryParse(s_cell, out d)){
                            msg = "値段と在庫数は数値のみ入力してください";
                            MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (s_cell.Contains(@"""""") || s_cell.Contains(",,"))
                        {
                            msg = @"""や,を連続して入力できません";
                            MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (iCol > 0)
                        {
                            s += ",";
                        }
                        s += quoteCommaCheck(s_cell);
                    }
                    sw.WriteLine(s);
                }
            }
            msg = "CSV出力が完了しました。";
            MessageBox.Show(msg, "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //入力された文にダブルクォートやコンマが含まれているとき文として読み取る処理
        private string quoteCommaCheck(string s_cell)
        {
            const string quote = @"""", comma = @",";
            string[] or_search = new string[] { quote, comma };

            if (or_search.Any(s_cell.Contains)){
                s_cell = s_cell.Replace(quote, quote + quote);
            }
            s_cell = quote + s_cell + quote;
            return s_cell;
        }

        private void setButtonClick(object sender, EventArgs e)
        {
            const string file_name = "csv_practice";
            List<List<string>> table = new List<List<string>>();
            table = this.readCSV(file_name, true);
        }

        private List<List<string>> readCSV(string file_name, bool header)
        {
            List<List<string>> table = new List<List<string>>();
            int table_row = 0;
            StreamReader sr = new StreamReader(file_name + ".csv");
            {
                if (header)
                {
                    sr.ReadLine();
                }
                while (!sr.EndOfStream)
                {
                    List<string> lists = new List<string>();
                    string line = sr.ReadLine();
                    string[] cells = line.Split(',');
                    lists.AddRange(cells);

                    for (int i_col = 0; i_col < lists.Count; i_col++)
                    {
                        if (lists[i_col] != string.Empty && lists[i_col].TrimStart()[0] == '"')
                        {
                            string quote = @"""", quote2 = @"""""";
                            while (lists[i_col].TrimEnd()[lists[i_col].TrimEnd().Length - 1] != '"')
                            {
                                lists[i_col] = lists[i_col] + "," + lists[i_col + 1];
                                lists.RemoveAt(i_col + 1);
                            }
                            if (lists[i_col].Contains(quote2))
                            {
                                lists[i_col] = lists[i_col].Replace(quote2, quote);
                            }
                            lists[i_col] = lists[i_col].Substring(1, lists[i_col].Length - 2);
                        }
                    }
                    table.Add(new List<string>());
                    table[table_row].AddRange(lists);
                    table_row++;
                }
            }
            //this.show2DList(table);
            return table;
        }
        private void show2DList (List<List<string>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                {
                    Console.Write(list[i][j]);
                    if (j != list.Count)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private Button calcButton(ref Button button, Size ClientSize)
        {
            //AdjustBounds(button_set.Width, button_set.Height, button_set.Left, button_set.Top, button, ClientSize);
            button.Size = new Size(ClientSize.Width * button.Width / base_size.Width, ClientSize.Height * button.Height / base_size.Height);
            button.Location = new Point(ClientSize.Width * button.Left / base_size.Width, ClientSize.Height * button.Top / base_size.Height);
            return button;
            //this.Controls.Add(button_set);
        }

        private void InitializationDataGridView(ref DataGridView data_grid_view)
        {
            data_grid_view.ColumnCount = 5;
            data_grid_view.Columns[0].HeaderText = "カテゴリ";
            data_grid_view.Columns[1].HeaderText = "商品名";
            data_grid_view.Columns[2].HeaderText = "値段";
            data_grid_view.Columns[3].HeaderText = "在庫数";
            data_grid_view.Columns[4].HeaderText = "削除";
            data_grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private DataGridView SetDataGridView(ref DataGridView data_grid_view, Size ClientSize)
        {
            data_grid_view.BackColor = data_grid_view.BackColor;
            data_grid_view.Size = new Size(ClientSize.Width * data_grid_view.Width / base_size.Width, ClientSize.Height * data_grid_view.Height / base_size.Height);
            data_grid_view.Location = new Point(ClientSize.Width * data_grid_view.Left / base_size.Width, ClientSize.Height * data_grid_view.Top / base_size.Height);
            this.InitializationDataGridView(ref data_grid_view);
            return data_grid_view;
        }

        private void AdjustBounds(int width, int height, int left, int top, Control g_control, Size ClientSize)
        {
            Control control = new Control();
            width = ClientSize.Width * g_control.Width / base_size.Width;
            height = ClientSize.Height * g_control.Height / base_size.Height;
            left = ClientSize.Width * g_control.Left / base_size.Width;
            top = ClientSize.Height * g_control.Top / base_size.Height;
        }

        private DataGridView g_data_grid_view = new DataGridView()
        {
            Left = 100,
            Top = 100,
            Width = 1400,
            Height = 700
        };
        private Button g_setting_button = new Button()
        {
            BackColor = Color.Red,
            Text = "読み込み",
            Left = 900,
            Top = 800,
            Width = 160,
            Height = 100,
        };

        private Button g_data_button = new Button()
        {
            Text = "書き込み",
            Left = 1060,
            Top = 800,
            Width = 160,
            Height = 100,
        };
        private Button g_reset_button = new Button()
        {
            Text = "リセット",
            Left = 1220,
            Top = 800,
            Width = 160,
            Height = 100,
        };
        private Button g_checkout_button = new Button()
        {
            Text = "会計",
            Left = 1380,
            Top = 800,
            Width = 160,
            Height = 100,
        };
    }
}