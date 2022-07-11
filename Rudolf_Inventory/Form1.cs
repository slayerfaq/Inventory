using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rudolf_Inventory
{
    public partial class Form1 : Form
    {
        //private bool visibleTextboxes = false;
        List<TextBox> textBoxesInventoryOne = new List<TextBox>();
        List<TextBox> textBoxesInventoryTwo = new List<TextBox>();
        List<TextBox> textBoxesInventoryThree = new List<TextBox>();
        List<TextBox> textBoxesInventoryFour = new List<TextBox>();
        //int previous_index;

        List<List<TextBox>> GRs = new List<List<TextBox>>() { };
        int GR_Number = new Random().Next(0, 4);

        public Form1()
        {
            InitializeComponent();

            textBoxesInventoryOne = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28, textBox29, textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36, textBox37, textBox38, textBox39, textBox40 };

            textBoxesInventoryTwo = new List<TextBox>() { textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48, textBox49, textBox50, textBox51, textBox52, textBox53, textBox54, textBox55, textBox56, textBox57, textBox58, textBox59, textBox60, textBox61, textBox62, textBox63, textBox64, textBox65, textBox66, textBox67, textBox68, textBox69, textBox70, textBox71, textBox72, textBox73, textBox74, textBox75, textBox76, textBox77, textBox78, textBox79, textBox80 };

            textBoxesInventoryThree = new List<TextBox>() { textBox81, textBox82, textBox83, textBox84, textBox85, textBox86, textBox87, textBox88, textBox89, textBox90, textBox91, textBox92, textBox93, textBox94, textBox95, textBox96, textBox97, textBox98, textBox99, textBox100, textBox101, textBox102, textBox103, textBox104, textBox105, textBox106, textBox107, textBox108, textBox109, textBox110, textBox111, textBox112, textBox113, textBox114, textBox115, textBox116, textBox117, textBox118, textBox119, textBox120 };

            textBoxesInventoryFour = new List<TextBox>() { textBox121, textBox122, textBox123, textBox124, textBox125, textBox126, textBox127, textBox128, textBox129, textBox130, textBox131, textBox132, textBox133, textBox134, textBox135, textBox136, textBox137, textBox138, textBox139, textBox140, textBox141, textBox142, textBox143, textBox144, textBox145, textBox146, textBox147, textBox148, textBox149, textBox150, textBox151, textBox152, textBox153, textBox154, textBox155, textBox156, textBox157, textBox158, textBox159, textBox160 };
            //previous_index = textBoxesInventoryFour.Count;
            //FillTextBoxes();

            GRs = new List<List<TextBox>>()
            {
                textBoxesInventoryOne,
                textBoxesInventoryTwo,
                textBoxesInventoryThree,
                textBoxesInventoryFour
            };

            FillTextBoxes();
        }

        /*private void SetVisibleTextBoxes(bool visible)
        {
            GR3.Visible = visible;
            
            foreach (TextBox textBox in textBoxesInventoryThree)
            {
                textBox.Visible = visible;
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (!visibleTextboxes) visibleTextboxes = true;
            else visibleTextboxes = false;
            SetVisibleTextBoxes(visibleTextboxes);*/
            #region
            /*GroupBox GBOX3 = new GroupBox()
            {
                Name = "GBOX3",
                Location = new Point(12, 188),
                Size = new Size(299, 141),
                Padding = new Padding(3, 3, 3, 3),
                Visible = true,
                TabIndex = 400,
                TabStop = false,
                Text = "Инвентарь 3"
            };
            List<TextBox> TextBoxes = new List<TextBox>();
            for (int y = 0, step_y = 25; y < 4; ++y, step_y += 25)
            {
                for (int index = 0, step = 0; index < 10; ++index, step += 25)
                {
                    TextBoxes.Add
                        (new TextBox()
                        {
                            Name = $"name{index + 1}",
                            Text = $"text_{index + 1}",
                            Location = new Point(10 + index + step, 175 + step_y),
                            Size = new Size(23, 23),
                            TabIndex = index + 20,
                            Visible = true,
                        });
                }
            }

            foreach (TextBox elem in TextBoxes)
            {
                GBOX3.Controls.Add(elem);
            }
            Controls.Add(GBOX3);
            */
            #endregion
        }

        private void AddTextBox_Click(object sender, EventArgs e)
        {
            /*if (previous_index == 0) return;
            textBoxesInventoryFour[previous_index-1].Visible = true;
            previous_index--;*/
        }

        private void FillTextBoxes()
        {
            SelectInventoryFrom.Text = GR_Number.ToString();
            foreach (TextBox textBox in GRs[GR_Number])
            {
                textBox.Text = new Random().Next(0, 100).ToString();
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            GR_Number = Convert.ToInt32(SelectInventoryFrom.Text);
            if (string.IsNullOrEmpty(SelectInventoryTo.Text))
            {
                MessageBox.Show("Ошибка ввода");
                return;
            }
            else
            {
                int userSelect = Convert.ToInt32(SelectInventoryTo.Text);
                if (userSelect < 0 || userSelect > GRs.Count - 1)
                {
                    MessageBox.Show("Ошибка ввода");
                    return;
                }
                if (userSelect == GR_Number)
                {
                    MessageBox.Show("Нельзя копируть туда же");
                    return;
                }
                for (int i = 0; i < GRs[userSelect].Count; ++i)
                {
                    GRs[userSelect][i].Text = GRs[GR_Number][i].Text;
                    GRs[GR_Number][i].Clear();
                }
                SelectInventoryFrom.Text = userSelect.ToString();
                SelectInventoryTo.Clear();
            }
        }

        // TODO. Исправить порядок добавления текст боксов
        private void Shuffle_Click(object sender, EventArgs e)
        {
            int userSelect = new Random().Next(0, 4);
            for (int i = 0; i < GRs[userSelect].Count; ++i)
            {
                GRs[userSelect][i].Text = "A"; //GRs[GR_Number][i].Text;
                GRs[GR_Number][i].Clear();
            }
            SelectInventoryFrom.Text = userSelect.ToString();
        }
    }
}
