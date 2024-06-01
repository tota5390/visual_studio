using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice1_setting
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        Size form_size, base_size = new Size(1600, 900);

        BoundsSpecified setting_button_bounds = new BoundsSpecified();

        
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             */
            this.WindowState = FormWindowState.Maximized;   //初期フォーム最大化
            this.Location = new Point(0, 0);
            this.Size = new Size(1600, 900);
            form_size = this.Size;                          //最大化後のサイズ記録
            Console.WriteLine("画面サイズ{0}", form_size);  //サイズ表示 
            SetButton(g_setting_button, this.ClientSize);
        }

        private void SetButton(Button button, Size ClientSize)
        {
            Button button_set = new Button();
            button_set.Text = button.Text;
            button_set.Size = new Size(ClientSize.Width * button.Width / base_size.Width, ClientSize.Height * button.Height / base_size.Height);
            button_set.Location = new Point(ClientSize.Width * button.Left / base_size.Width, ClientSize.Height * button.Top / base_size.Height);
            this.Controls.Add(button_set);
        }

        private Button g_setting_button = new Button()
        {
            Text = "設定",
            Left = 1000,
            Top = 800,
            Width = 160,
            Height = 100,
        };
    }
}
