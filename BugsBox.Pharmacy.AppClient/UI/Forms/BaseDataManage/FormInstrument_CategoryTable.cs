using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public delegate void SelectInstrumentTypeEventHandler(object sender, InstrumentTypeStrArgs e);
    public partial class FormInstrument_CategoryTable : Form
    {
        public event SelectInstrumentTypeEventHandler SelectInstrument;
        InstrumentTypeStrArgs InArgs = new InstrumentTypeStrArgs();
        public FormInstrument_CategoryTable( string str)
        {
            InitializeComponent();

            for (int i = 0; i < 11; i++)
            {
                this.dataGridView1.Columns[i].DataPropertyName = "a" + (i + 1).ToString();
            }

            #region 数据
            List<Dd> ListD = new List<Dd>();
            Dd d = new Dd
            {
                a1 = 1,
                a2 = "药液输送保存器械",
                a3 = "2",
                a4 = "2",
                a5 = "3",
                a6 = "2",
                a7 = "2",
                a8 = "3",
                a9 = "2",
                a10 = "3",
                a11 = "3"
            };
            ListD.Add(d);
            d = new Dd
            {
                a1 = 2,
                a2 = "用于改变血液体液器械",
                a3 = "-",
                a4 = "-",
                a5 = "3",
                a6 = "-",
                a7 = "-",
                a8 = "3",
                a9 = "-",
                a10 = "-",
                a11 = "3"
            };
            ListD.Add(d);
            d = new Dd
            {
                a1 = 3,
                a2 = "医用敷料",
                a3 = "1",
                a4 = "2",
                a5 = "2",
                a6 = "1",
                a7 = "2",
                a8 = "2",
                a9 = "-",
                a10 = "-",
                a11 = "-"
            };
            ListD.Add(d);
            d = new Dd
            {
                a1 = 4,
                a2 = "外科器械(侵入)",
                a3 = "1",
                a4 = "2",
                a5 = "3",
                a6 = "2",
                a7 = "2",
                a8 = "3",
                a9 = "2",
                a10 = "3",
                a11 = "3"
            };
            ListD.Add(d);
            d = new Dd
            {
                a1 = 5,
                a2 = "重复使用外科手术器械",
                a3 = "1",
                a4 = "1",
                a5 = "2",
                a6 = "-",
                a7 = "-",
                a8 = "-",
                a9 = "-",
                a10 = "-",
                a11 = "-"
            };
            ListD.Add(d);
            d = new Dd
            {
                a1 = 6,
                a2 = "一次性无菌外科器械",
                a3 = "1",
                a4 = "2",
                a5 = "3",
                a6 = "2",
                a7 = "3",
                a8 = "3",
                a9 = "2",
                a10 = "3",
                a11 = "3"
            };
            ListD.Add(d);

            d = new Dd
            {
                a1 = 7,
                a2 = "植入器械",
                a3 = "-",
                a4 = "-",
                a5 = "-",
                a6 = "-",
                a7 = "-",
                a8 = "-",
                a9 = "3",
                a10 = "3",
                a11 = "3"
            };
            ListD.Add(d);

            d = new Dd
            {
                a1 = 8,
                a2 = "避孕计生器械",
                a3 = "2",
                a4 = "2",
                a5 = "3",
                a6 = "2",
                a7 = "3",
                a8 = "3",
                a9 = "3",
                a10 = "3",
                a11 = "3"
            };
            ListD.Add(d);

            d = new Dd
            {
                a1 = 9,
                a2 = "消毒清洁器械",
                a3 = "2",
                a4 = "2",
                a5 = "2",
                a6 = "2",
                a7 = "2",
                a8 = "2",
                a9 = "2",
                a10 = "2",
                a11 = "2"
            };
            ListD.Add(d);

            d = new Dd
            {
                a1 = 10,
                a2 = "其他无源接触器械",
                a3 = "1",
                a4 = "2",
                a5 = "3",
                a6 = "2",
                a7 = "2",
                a8 = "3",
                a9 = "2",
                a10 = "3",
                a11 = "3"
            };
            ListD.Add(d);

            this.dataGridView1.DataSource = ListD;
            #endregion                       

            #region 初始化字符
            Action<string> InitStr = s =>
            {                
                this.tabControl1.SelectedIndex = s[0] == 'A' ? 0 : 1;
                if (this.tabControl1.SelectedIndex == 0)
                {
                    if (s[1] == 'A')//第二个字符为A时
                    {
                        int rIdx =s.Length==6? int.Parse(s[2].ToString()) - 1:int.Parse(s.Substring(2,2))-1;
                        int lastIdx = int.Parse(s[s.Length-1].ToString());
                        int midIdx = int.Parse(s[s.Length-2].ToString());
                        foreach (DataGridViewCell c in this.dataGridView1.Rows[rIdx].Cells)
                        {
                            if (c.ColumnIndex < 2 || c.Value.ToString() == "-") continue;
                            if (midIdx == 1)
                            {
                                if (c.ColumnIndex >= 2 && c.ColumnIndex <= 4)
                                {
                                    if (int.Parse(c.Value.ToString()) == lastIdx)
                                    {
                                        c.Style = new DataGridViewCellStyle { BackColor = Color.Red };
                                        break;
                                    }
                                }
                            }
                            if (midIdx == 2)
                            {
                                if (c.ColumnIndex >= 5 && c.ColumnIndex <= 7)
                                {
                                    if (int.Parse(c.Value.ToString()) == lastIdx)
                                    {
                                        c.Style = new DataGridViewCellStyle { BackColor = Color.Red };
                                        break;
                                    }
                                }
                            }
                            if (midIdx == 3)
                            {
                                if (c.ColumnIndex >= 8 && c.ColumnIndex <= 10)
                                {
                                    if (int.Parse(c.Value.ToString()) == lastIdx)
                                    {
                                        c.Style = new DataGridViewCellStyle { BackColor = Color.Red };
                                        break;
                                    }
                                }
                            }

                        }
                    }
                    else if (s[1] == 'B')//第二个字符为B时
                    {
                        int idx = (int.Parse(s[2].ToString()) - 1) * 3 + int.Parse(s[4].ToString()) - 1;
                        foreach (Control c in this.tableLayoutPanel3.Controls)
                        {
                            if (c.TabIndex == idx)
                            {
                                c.BackColor = Color.Red;
                            }
                        }
                    }
                }
                else if (this.tabControl1.SelectedIndex == 1)
                {
                    if (s[1] == 'A')//第二个字符为A时
                    {
                        int idx = (int.Parse(s[2].ToString()) - 1) * 3 + int.Parse(s[4].ToString()) - 1;
                        foreach (Control c in this.tableLayoutPanel4.Controls)
                        {
                            if (c.TabIndex == idx)
                            {
                                c.BackColor = Color.Red;
                            }
                        }
                    }
                    if (s[1] == 'B')//第二个字符为B时
                    {
                        int idx = (int.Parse(s[2].ToString()) - 1) * 2 + int.Parse(s[4].ToString()) - 1;
                        foreach (Control c in this.tableLayoutPanel5.Controls)
                        {
                            if (c.TabIndex == idx)
                            {
                                c.BackColor = Color.Red;
                            }
                        }
                    }
                }
                
            };
            

            
            #endregion

            #region 接触式无源事件
            this.dataGridView1.CellMouseClick += (sender, e) =>
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Left) return;

                if (e.ColumnIndex < 2) return;

                if (this.dataGridView1.CurrentCell.Value.ToString() == "-") return;

                DataGridViewCellStyle DefaultDgvcstyle = new DataGridViewCellStyle { BackColor = Color.White };

                this.RefreshBackColor();

                DataGridViewCellStyle CustomDgvcstyle = new DataGridViewCellStyle { BackColor = Color.Red };

                this.dataGridView1.CurrentCell.Style = CustomDgvcstyle;

                var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Dd;
                string Idx = e.ColumnIndex < 5 ? "-1" : e.ColumnIndex < 8 ? "-2" : "-3";
                
                string s = "AA" + c.a1.ToString()+Idx+this.dataGridView1.CurrentCell.Value.ToString();

                if (this.SelectInstrument != null)
                {
                    this.InArgs.InstrumentTypeStr = s;

                    this.SelectInstrument(this, this.InArgs);
                }
            };
            #endregion

            #region 接触式有源事件
            foreach (Control c in this.tableLayoutPanel3.Controls)
            {
                if ((c.GetType() == typeof(Label)))
                {
                    Label lab = (Label)c;
                    if (lab.TabIndex < 14)
                    {
                        lab.Click += (sender, e) =>
                        {
                            this.RefreshBackColor();
                            lab.BackColor = Color.Red;

                            string s = "AB";
                            s += ((int)(lab.TabIndex / 3)+1).ToString();
                            s += lab.TabIndex % 3 == 0 ? "-1" : lab.TabIndex % 3 == 1 ? "-2" : "-3";
                            s += lab.Text;

                            if (this.SelectInstrument != null)
                            {
                                this.InArgs.InstrumentTypeStr = s;

                                this.SelectInstrument(this, this.InArgs);
                            }
                        };
                    }
                }
            }
            #endregion

            #region 非接触式无源
            foreach (Control c in this.tableLayoutPanel4.Controls)
            {
                if ((c.GetType() == typeof(Label)))
                {
                    Label lab = (Label)c;
                    if (lab.TabIndex < 8 && lab.TabIndex!=2)
                    {
                        lab.Click += (sender, e) =>
                        {
                            this.RefreshBackColor();
                            lab.BackColor = Color.Red;

                            string s = "BA";
                            s += ((int)(lab.TabIndex / 3) + 1).ToString();
                            s += lab.TabIndex % 3 == 0 ? "-1" : lab.TabIndex % 3 == 1 ? "-2" : "-3";
                            s += lab.Text;

                            if (this.SelectInstrument != null)
                            {
                                this.InArgs.InstrumentTypeStr = s;

                                this.SelectInstrument(this, this.InArgs);
                            }
                        };
                    }
                }
            }
            #endregion

            #region 非接触式有源
            foreach (Control c in this.tableLayoutPanel5.Controls)
            {
                if ((c.GetType() == typeof(Label)))
                {
                    Label lab = (Label)c;
                    if (lab.TabIndex < 6)
                    {
                        lab.Click += (sender, e) =>
                        {
                            this.RefreshBackColor();
                            lab.BackColor = Color.Red;

                            string s = "BB";
                            s += ((int)(lab.TabIndex / 2) + 1).ToString();
                            s += lab.TabIndex % 2 == 0 ? "-1" :  "-2" ;
                            s += lab.Text;

                            if (this.SelectInstrument != null)
                            {
                                this.InArgs.InstrumentTypeStr = s;

                                this.SelectInstrument(this, this.InArgs);
                            }
                        };
                    }
                }
            }
            #endregion

            this.Load += (sender, e) =>
            {
                if (str != string.Empty)
                    InitStr(str);
            };
            
        }
        private void RefreshBackColor()
        {
            this.dataGridView1.ClearSelection();
            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {
                DataGridViewCellStyle st = new DataGridViewCellStyle
                {
                    BackColor=Color.White
                };
                foreach (DataGridViewCell c in r.Cells)
                {
                    c.Style = st;
                }
            }

            foreach (Control c in tableLayoutPanel3.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    Label l = ((Label)c);
                    if(l.Text!="-")
                        l.BackColor = Color.White;
                }
            }

            foreach (Control c in tableLayoutPanel4.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    Label l = ((Label)c);
                    if (l.Text != "-")
                        l.BackColor = Color.White;
                }
            }

            foreach (Control c in tableLayoutPanel5.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    Label l = ((Label)c);
                    if (l.Text != "-")
                        l.BackColor = Color.White;
                }
            }

        }
    }

    
    public class InstrumentTypeStrArgs:EventArgs
    {
        public string InstrumentTypeStr { get; set; }
    }
    public class Dd
    {
        public int a1 { get; set; }
        public string a2 { get; set; }

        public string a3 { get; set; }
        public string a4 { get; set; }
        public string a5 { get; set; }
        public string a6 { get; set; }
        public string a7 { get; set; }
        public string a8 { get; set; }
        public string a9 { get; set; }
        public string a10 { get; set; }
        public string a11 { get; set; }
    }
}
