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
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;
using System.Diagnostics;


namespace category
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += CategoryLoad;
        }
        Size category_tab_size = new Size(1600, 900);
        string category_file = "category";

        private TabControl form1_tab_control = new TabControl()
        {
            Size = new Size(600, 600),
            Location = new Point(500, 150),
            SelectedIndex = 0,
            TabIndex = 3,
            Alignment = TabAlignment.Top
        };

        private DataGridView data_grid_view = new DataGridView()
        {
            Size = new Size(590, 590),
            Location = new Point(0, 0),
            TabIndex = 3,
        };

        Size base_size = new Size(1600, 900), tab_control_size = new Size(600, 600);
        private void CategoryLoad(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;   //初期フォーム最大化

            this.calcTabControl(ref form1_tab_control, base_size,this.ClientSize);
            this.calcDataGridView(ref data_grid_view, tab_control_size, form1_tab_control.Size);
            this.Controls.Add(form1_tab_control);
            
            
            List<string> category_list = new List<string>();
            category_list = this.ReadCSVFile(category_file, false);
            DataGridView[] data_grid_views = new DataGridView[category_list.Count];
            for(int i = 0; i < category_list.Count; i++)
            {
                data_grid_views[i] = this.SetDataGridView(data_grid_view);
                this.ItemDataGridView(ref data_grid_views[i]);
                data_grid_views[i].AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                this.calcTabPage(ref this.category_tab_size, base_size, this.form1_tab_control.Size);
                TabPage category_tab_page = this.MakeTabPage(category_list[i], this.category_tab_size);
                form1_tab_control.Controls.Add(category_tab_page);
                category_tab_page.Controls.Add(data_grid_views[i]);
            }
        }

        private void ItemDataGridView(ref DataGridView data_grid_view)
        {
            data_grid_view.ColumnCount = 5;
            data_grid_view.Columns[0].HeaderText = "カテゴリ";
            data_grid_view.Columns[1].HeaderText = "商品名";
            data_grid_view.Columns[2].HeaderText = "値段";
            data_grid_view.Columns[3].HeaderText = "在庫数";
            data_grid_view.Columns[4].HeaderText = "削除";
            data_grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private DataGridView SetDataGridView(DataGridView data_grid_view)
        {
            DataGridView i_data_grid_view = new DataGridView();
            i_data_grid_view.Size = data_grid_view.Size;
            i_data_grid_view.Location = data_grid_view.Location;
            return i_data_grid_view;
        }

        private TabPage MakeTabPage(string text, Size item_category_size)
        {
            TabPage l_item_category = new TabPage();
            l_item_category.Text = text;
            l_item_category.AutoScroll = true;
            l_item_category.Size = item_category_size;
            l_item_category.Padding = new Padding(3);
            l_item_category.AutoScroll = false;
            return l_item_category;
        }

        private List<string> ReadCSVFile(string file_name, bool header)
        {
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader(file_name + ".csv");
            {
                if (header)
                {
                    sr.ReadLine();
                }
                while (!sr.EndOfStream)
                {
                    string cell = sr.ReadLine();
                    list.Add(cell);
                }
            }
            return list;
        }

        private List<List<string>> ReadCSVFiles(string file_name, bool header)
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
        private TabControl calcTabControl(ref TabControl tabcontrol, Size base_size,Size ClientSize)
        {
            tabcontrol.Size = new Size(ClientSize.Width * tabcontrol.Width / base_size.Width, ClientSize.Height * tabcontrol.Height / base_size.Height);
            tabcontrol.Location = new Point(ClientSize.Width * tabcontrol.Left / base_size.Width, ClientSize.Height * tabcontrol.Top / base_size.Height);
            return tabcontrol;
        }
        private Size calcTabPage(ref Size tabpage_size, Size base_size, Size ClientSize)
        {
            tabpage_size = new Size(ClientSize.Width * tabpage_size.Width / base_size.Width, ClientSize.Height * tabpage_size.Height / base_size.Height);
            return tabpage_size;
        }
        private DataGridView calcDataGridView(ref DataGridView data_grid_view, Size base_size, Size ClientSize)
        {
            data_grid_view.Size = new Size(ClientSize.Width * data_grid_view.Width / base_size.Width, ClientSize.Height * data_grid_view.Height / base_size.Height);
            data_grid_view.Location = new Point(ClientSize.Width * data_grid_view.Left / base_size.Width, ClientSize.Height * data_grid_view.Top / base_size.Height);
            return data_grid_view;
        }
    }
}
