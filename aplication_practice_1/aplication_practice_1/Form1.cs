using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplication_practice_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double num;
        double first_num;
        string display_num = "", str_num = "";
        char ope;
        bool num_ok = false, zero_ok = false, dot_ok = false, equal_ok = false, ans_ok = false, ope_ok = false, div_ok = false, minas_ok = false;

        double ans;
        private void number0_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (num_ok || !zero_ok)                                                 // 数値の後, または0がない後, 0を追加
                {
                    display_num += '0';
                    str_num += '0';
                    if (!zero_ok)
                    {
                        zero_ok = true;                                                 // 先頭に0が追加された判定
                    }
                }
                number_display.Text = display_num;                                      // 入力表示
                num_ok = true;                                                          // 数字が追加された判定
            }
        }

        private void number1_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '1';                                                     // 表示数値追加
                str_num += '1';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number2_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '2';                                                     // 表示数値追加
                str_num += '2';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number3_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '3';                                                     // 表示数値追加
                str_num += '3';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number4_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '4';                                                     // 表示数値追加
                str_num += '4';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number5_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '5';                                                     // 表示数値追加
                str_num += '5';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number6_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '6';                                                     // 表示数値追加
                str_num += '6';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number7_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '7';                                                     // 表示数値追加
                str_num += '7';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number8_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '8';                                                     // 表示数値追加
                str_num += '8';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void number9_Click(object sender, EventArgs e)
        {
            if (!equal_ok)                                                              // =の演算後は数字は追加できない
            {
                if (zero_ok && !dot_ok)
                {
                    display_num += '.';                                                 // 先頭の0の後に数字を入れる場合小数点を追加
                    str_num += '.';
                    dot_ok = true;
                }
                display_num += '9';                                                     // 表示数値追加
                str_num += '9';                                                         // 計算用数値追加
                number_display.Text = display_num;                                      // 数値表示
                zero_ok = false;                                                        // 先頭が0でない
                num_ok = true;                                                          // 数値が入力された
            }
        }

        private void plas_Click(object sender, EventArgs e)
        {
            if (num_ok && !(zero_ok && div_ok))                                         // 数値入力後に演算子追加可能
            {
                if (!ans_ok && !ope_ok)                                                 // 演算される数値を記憶させる一度計算したら, その解に演算していく
                {
                    ans = double.Parse(display_num);
                    str_num = "";
                }
                if (ope_ok)
                {
                    num = double.Parse(str_num);                                        // 数値を追加したものを文字列から数値型にする

                    if (ope == '＋')
                    {
                        ans += num;
                    }
                    else if (ope == '－')
                    {
                        ans -= num;
                    }
                    else if (ope == '×')
                    {
                        ans *= num;
                    }
                    else if (ope == '÷')
                    {
                        ans /= num;
                    }

                    display_num = ans.ToString();                                       // 表示は解
                    number_display.Text = display_num;                                  // 入力表示
                    str_num = "";                                                       // 計算数値の初期化
                    ans_ok = true;                                                      // 解が求められた判定
                }
                ope = '＋';                                                             // 現在の演算子記憶
                display_num += '＋';                                                    // 表示追加 
                number_display.Text = display_num;                                      // 入力表示
                zero_ok = false;                                                        // 先頭が0でない
                equal_ok = false;                                                       // =演算されていない状態
                num_ok = false;                                                         // 数値が追加されていない状態
                ope_ok = true;
                div_ok = false;
                minas_ok = false;
            }
        }

        private void minas_Click(object sender, EventArgs e)
        {
            if (!num_ok && !minas_ok && !equal_ok)
            {
                display_num += '-';
                str_num += '-';
                number_display.Text = display_num;
                minas_ok = true;
            }
            else if (num_ok && !(zero_ok && div_ok))                                         // 数値入力後に演算子追加可能
            {
                if (!ans_ok && !ope_ok)                                                 // 演算される数値を記憶させる一度計算したら, その解に演算していく
                {
                    ans = double.Parse(display_num);
                    str_num = "";
                }
                if (ope_ok)
                {
                    num = double.Parse(str_num);                                        // 数値を追加したものを文字列から数値型にする

                    if (ope == '＋')
                    {
                        ans += num;
                    }
                    else if (ope == '－')
                    {
                        ans -= num;
                    }
                    else if (ope == '×')
                    {
                        ans *= num;
                    }
                    else if (ope == '÷')
                    {
                        ans /= num;
                    }
                    display_num = ans.ToString();                                       // 表示は解
                    number_display.Text = display_num;                                  // 入力表示
                    str_num = "";                                                       // 計算数値の初期化
                    ans_ok = true;                                                      // 解が求められた判定
                }
                ope = '－';                                                             // 現在の演算子記憶
                display_num += '－';                                                    // 表示追加 
                number_display.Text = display_num;                                      // 入力表示
                zero_ok = false;                                                        // 先頭が0でない
                equal_ok = false;                                                       // =演算されていない状態
                num_ok = false;                                                         // 数値が追加されていない状態
                ope_ok = true;
                div_ok = false;
                minas_ok = false;
            }
        }

        private void times_Click(object sender, EventArgs e)
        {
            if (num_ok && !(zero_ok && div_ok))                                         // 数値入力後に演算子追加可能
            {
                if (!ans_ok && !ope_ok)                                                 // 演算される数値を記憶させる一度計算したら, その解に演算していく
                {
                    ans = double.Parse(display_num);
                    str_num = "";
                }
                if (ope_ok)
                {
                    num = double.Parse(str_num);                                        // 数値を追加したものを文字列から数値型にする

                    if (ope == '＋')
                    {
                        ans += num;
                    }
                    else if (ope == '－')
                    {
                        ans -= num;
                    }
                    else if (ope == '×')
                    {
                        ans *= num;
                    }
                    else if (ope == '÷')
                    {
                        ans /= num;
                    }
                    display_num = ans.ToString();                                       // 表示は解
                    number_display.Text = display_num;                                  // 入力表示
                    str_num = "";                                                       // 計算数値の初期化
                    ans_ok = true;                                                      // 解が求められた判定
                }
                ope = '×';                                                             // 現在の演算子記憶
                display_num += '×';                                                    // 表示追加 
                number_display.Text = display_num;                                      // 入力表示
                zero_ok = false;                                                        // 先頭が0でない
                equal_ok = false;                                                       // =演算されていない状態
                num_ok = false;                                                         // 数値が追加されていない状態
                ope_ok = true;
                div_ok = false;
                minas_ok = false;
            }
        }

        private void divide_Click(object sender, EventArgs e)
        {
            if (num_ok && !(zero_ok && div_ok))                                         // 数値入力後に演算子追加可能
            {
                if (!ans_ok && !ope_ok)                                                 // 演算される数値を記憶させる一度計算したら, その解に演算していく
                {
                    ans = double.Parse(display_num);
                    str_num = "";
                }
                if (ope_ok)
                {
                    num = double.Parse(str_num);                                        // 数値を追加したものを文字列から数値型にする

                    if (ope == '＋')
                    {
                        ans += num;
                    }
                    else if (ope == '－')
                    {
                        ans -= num;
                    }
                    else if (ope == '×')
                    {
                        ans *= num;
                    }
                    else if (ope == '÷')
                    {
                        ans /= num;
                    }

                    display_num = ans.ToString();                                       // 表示は解
                    number_display.Text = display_num;                                  // 入力表示
                    str_num = "";                                                       // 計算数値の初期化
                    ans_ok = true;                                                      // 解が求められた判定
                }
                ope = '÷';                                                             // 現在の演算子記憶
                display_num += '÷';                                                    // 表示追加 
                number_display.Text = display_num;                                      // 入力表示
                zero_ok = false;                                                        // 先頭が0でない
                equal_ok = false;                                                       // =演算されていない状態
                num_ok = false;                                                         // 数値が追加されていない状態
                ope_ok = true;
                div_ok = true;
                minas_ok = false;
            }
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (!dot_ok && !equal_ok)
            {
                if (!num_ok)
                {
                    display_num += '0';
                    str_num += '0';
                }
                display_num += '.';
                str_num += '.';
                number_display.Text = display_num;
                dot_ok = true;
            } 
        }

        private void equal_Click(object sender, EventArgs e)
        {
            if (num_ok && !equal_ok && !(zero_ok && div_ok))                                         // 数値入力後に演算子追加可能
            {
                num = double.Parse(str_num);                                            // 数値を追加したものを文字列から数値型にする

                if (ope == '＋')
                {
                    ans += num;
                }
                else if (ope == '－')
                {
                    ans -= num;
                }
                else if (ope == '×')
                {
                    ans *= num;
                }
                else if (ope == '÷')
                {
                    ans /= num;
                }

                display_num = ans.ToString();                                           // 表示は解
                number_display.Text = display_num;                                      // 入力表示
                str_num = "";                                                           // 計算数値の初期化
                ope = ' ';
                zero_ok = false;                                                        // 先頭が0でない
                equal_ok = true;                                                        // 解の表示後である判定
                ans_ok = true;                                                          // 解が求められた判定
                dot_ok = false;
                ope_ok = false;
                div_ok = false;
                minas_ok = false;
            }

        }
        private void all_clear_Click(object sender, EventArgs e)
        {
            num = 0;
            first_num = 0;
            ans = 0;
            display_num = "";
            str_num = "";
            ope = ' ';
            num_ok = false;
            zero_ok = false;
            dot_ok = false;
            equal_ok = false;
            ans_ok = false;
            ope_ok = false;
            div_ok = false;
            minas_ok = false;
            number_display.Text = display_num;
        }
    }
}