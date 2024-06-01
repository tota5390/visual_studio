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
        private Button[] many_buttons;
        public Form1()
        {
            InitializeComponent();
            this.many_buttons = null;
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

            this.many_buttons = new Button[10];
            for(int i = 0; i < 10; i++)
            {
                this.many_buttons[i] = new Button();
                this.many_buttons[i].Name = "button" + i;

            }
            SetButton(g_setting_button, this.ClientSize);
            SetButton(g_data_button, this.ClientSize);
            SetButton(g_reset_button, this.ClientSize);
            SetButton(g_checkout_button, this.ClientSize);
        }


        private void SetButton(Button button, Size ClientSize)
        {
            Button button_set = new Button();
            button_set.BackColor = button.BackColor;
            button_set.Text = button.Text;
            button_set.Size = new Size(ClientSize.Width * button.Width / base_size.Width, ClientSize.Height * button.Height / base_size.Height);
            button_set.Location = new Point(ClientSize.Width * button.Left / base_size.Width, ClientSize.Height * button.Top / base_size.Height);
            this.Controls.Add(button_set);
        }

        private Button g_setting_button = new Button()
        {
            BackColor = Color.Red,
            Text = "設定",
            Left = 900,
            Top = 800,
            Width = 160,
            Height = 100,
        };

        private Button g_data_button = new Button()
        {
            Text = "データ",
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
