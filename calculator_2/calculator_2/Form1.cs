using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator_2
{
    public partial class Form1 : Form
    {
        double num1 = 0;
        double num2 = 0;
        string ope = " ", str_num = "";
        bool num_input = false, zero_ok = false, decimal_point = false, ope_ok = false, equal_ok = false, div_zero = false, minus_ok = false;

        public Form1()
        {
            //コンポーネント初期化
            InitializeComponent();
        }

        void buttonNum_Clicked(object sender, EventArgs e)
        {
            //object型をbutton型に変換
            Button button = (Button)sender;
            //＝の演算直後は数値を追加できない
            if (!equal_ok)
            {
                //先頭に0がある状態で数字を入力すると小数点も同時に入力
                if(zero_ok && !decimal_point)
                {
                    textBoxInput.Text += ".";
                    str_num += ".";
                    decimal_point = true;
                    zero_ok = false;
                }

                //数字を入力
                textBoxInput.Text += button.Text;
                str_num += button.Text;
                zero_ok = false;

                //入力なしの状態で最初に0が入力された場合小数点のフラグが立つ
                if (!num_input && button.Text == "0")
                {
                    zero_ok = true;
                }

                //0以外の数値が入力された場合、0除算フラグ解除
                if(button.Text != "0")
                {
                    div_zero = false;
                }

                //数字が入力されたらtrue
                num_input = true;
            }
        }

        void buttonDot_Clicked(object sender, EventArgs e)
        {
            //小数点は1回のみ入力可、さらに＝の演算直後は追加できない
            if (!decimal_point && !equal_ok)
            {
                //数字が入力されていない場合は0も追加
                if (!num_input)
                {
                    textBoxInput.Text += "0";
                    str_num += "0";
                    num_input = true;
                }

                //小数点の追加
                textBoxInput.Text += ".";
                str_num += ".";
                decimal_point = true;
            }
        }

        void buttonOperator_Clicked(object sender, EventArgs e)
        {
            //入力された演算子の型変換
            Button button = (Button)sender;
            //符号として－を入力した場合(数値入力なし、－入力なし、演算直後でない)
            if (button.Text == "－" && !num_input && !minus_ok && !equal_ok)
            {
                textBoxInput.Text += "-";
                str_num += "-";
                minus_ok = true;
            }
            //数値が入力されていれば演算子を追加可能、
            else if (num_input)
            {
                zero_ok = false;
                //画面上に符号がある場合はまず計算をする
                if (ope_ok)
                {
                    num2 = double.Parse(str_num);
                    if(ope == "＋")
                    {
                        num1 += num2;
                    }
                    else if(ope == "－")
                    {
                        num1 -= num2;
                    }
                    else if(ope == "×")
                    {
                        num1 *= num2;
                    }
                    else if(ope == "÷")
                    {
                        //割る数が0じゃないときのみ計算
                        if (num2 != 0)
                        {
                            num1 /= num2;
                        }
                        //0で徐算のフラグが立つ
                        else
                        {
                            div_zero = true;
                        }
                    }
                    //0徐算じゃないときは計算結果を出力、0徐算の時はそのまま
                    if (!div_zero)
                    {
                        textBoxInput.Text = "";
                        textBoxInput.Text = num1.ToString();
                        num2 = 0;
                        ope_ok = false;
                    }
                }

                //0除算でなければ計算後の結果に演算子を追加
                if (!div_zero)
                {
                    //入力された演算子を記録
                    ope = button.Text;
                    num1 = double.Parse(textBoxInput.Text);
                    //入力が＝以外の場合符号を追加、＝の時は計算した結果のみが表示される
                    if (ope != "＝")
                    {
                        textBoxInput.Text += button.Text;
                        ope_ok = true;
                        decimal_point = false;
                        num_input = false;
                        minus_ok = false;
                        equal_ok = false;
                    }
                    //＝が入力された場合、画面上に演算子はなくなる
                    else
                    {
                        equal_ok = true;
                        ope_ok = false;
                    }

                    str_num = "";
                }
            }
        }

        void buttonAllClear_Clicked(object sender, EventArgs e)
        {
            num1 = num2 = 0;
            decimal_point = false;
            num_input = false;
            zero_ok = false;
            decimal_point = false;
            ope_ok = false;
            equal_ok = false;
            div_zero = false;
            minus_ok = false;
            textBoxInput.Text = "";
        }

        void buttonClear_Clicked(object sender, EventArgs e)
        {
            decimal_point = false;
            decimal_point = false;
            num_input = false;
            zero_ok = false;
            decimal_point = false;
            ope_ok = false;
            equal_ok = false;
            div_zero = false;
            minus_ok = false;
            textBoxInput.Text = "";
        }
    }
}
