using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace category_choise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += CategoryChoiceLoad;
        }
        
        private DataGridView category_data = new DataGridView()
        {
            Size = new Size(1200, 700),
            Location = new Point(200, 100),
            TabIndex = 3,
        };

        Size base_size = new Size(1600, 900), tab_control_size = new Size(600, 600);
        private void CategoryChoiceLoad(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;   //初期フォーム最大化
            this.calcDataGridView(ref category_data, base_size, this.ClientSize);
            this.CategoryDataGridView(ref category_data);
            this.Controls.Add(category_data);
        }
        private void CategoryDataGridView(ref DataGridView data_grid_view)
        {
            data_grid_view.ColumnCount = 1;
            data_grid_view.Columns[0].HeaderText = "カテゴリ";
            data_grid_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private DataGridView calcDataGridView(ref DataGridView data_grid_view, Size base_size, Size ClientSize)
        {
            data_grid_view.Size = new Size(ClientSize.Width * data_grid_view.Width / base_size.Width, ClientSize.Height * data_grid_view.Height / base_size.Height);
            data_grid_view.Location = new Point(ClientSize.Width * data_grid_view.Left / base_size.Width, ClientSize.Height * data_grid_view.Top / base_size.Height);
            return data_grid_view;
        }
    }
}
