using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class Form_Photo : Form
    {
        private int _type = 0;
        private Guid _gid = Guid.Empty;
        private string FileName = string.Empty;
        private string addr = string.Empty;
        private string dbname = string.Empty;
        private string user = string.Empty;
        private string pw = string.Empty;
        private List<Photo> ListP = new List<Photo>();
        private Photo pt = null;
        

        System.Data.SqlClient.SqlConnection oleConnection = null;

        private ContextMenuStrip cms = new ContextMenuStrip();
        private ContextMenuStrip cms2 = new ContextMenuStrip();

        public Form_Photo(int type,Guid gid,bool readOnly=false)
        {
            InitializeComponent();

            _type = type;
            _gid = gid;
            XmlDocument doc = new XmlDocument();
            string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml";
            doc.Load(xmlFile);
            XmlNodeList nodeList = doc.SelectNodes("/SalePriceType/photo");
            addr = nodeList[0].Attributes["Address"].Value.ToString();
            dbname = nodeList[0].Attributes["database"].Value.ToString();
            user = nodeList[0].Attributes["user"].Value.ToString();
            pw = nodeList[0].Attributes["pw"].Value.ToString();

            cms2.Items.Add("放大图片", null, this.toolStripButton3_Click);
            cms2.Items.Add("缩小图片", null, this.toolStripButton4_Click);
            cms2.Items.Add("适合大小", null, this.toolStripButton6_Click);
            cms2.Items.Add("顺时针旋转90°", null, this.toolStripButton5_Click);
            cms2.Items.Add("逆时针旋转90°", null, this.toolStripButton7_Click);
            cms2.Items.Add("-");
            cms2.Items.Add("下载该图片", null,delegate(object o, EventArgs e) { this.DownLoadPic(); });

            if (readOnly) return;
            cms.Items.Add("新增图片", null, AddNewPic);
            cms.Items.Add("修改图片及说明", null, ModPic);
            cms.Items.Add("删除图片", null, DelPic);
        }

        public Byte[] SetImgToByte(string imgPath)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bm = new Bitmap(this.pictureBox1.Image))
                {
                    System.Drawing.Imaging.EncoderParameters encoderP = new System.Drawing.Imaging.EncoderParameters(1);
                    System.Drawing.Imaging.EncoderParameter p = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 8);
                    encoderP.Param[0] = p;

                    System.Drawing.Imaging.ImageCodecInfo[] CodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
                    var c=CodecInfo.Where(r=>r.MimeType=="image/jpeg").FirstOrDefault();
                    
                    bm.Save(ms,c,encoderP);              
                }
                ms.Position = 0;
                Byte[] byteData = new Byte[ms.Length];
                ms.Read(byteData, 0, byteData.Length);
                ms.Close();
                return byteData;
            }
        }

        public bool SaveEmployeeImg2Db(string path)
        {
            try
            {
                bool flag=true;
                Byte[] imgBytes = this.SetImgToByte(path);
                
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "JPG文件|*.jpg|PNG文件|*.png|BMP文件|*.bmp";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(ofd.FileName);
                this.richTextBox1.Text = string.Empty;
            }
            FileName = ofd.FileName;
        }
        /// <summary>
        /// 从 本地文件载入图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (FileName == string.Empty)
            {
                MessageBox.Show("请选择图片！", "警告",MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
                return;
            } 
            if (MessageBox.Show("确定要保存图片吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            Byte[] photo=SetImgToByte(FileName);
            try
            {
                string sql = "Data Source="+addr+";Initial Catalog="+dbname+";User ID="+user+";Password="+pw+";Min Pool Size=1";
                oleConnection = new System.Data.SqlClient.SqlConnection(sql);
                oleConnection.Open();
                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();                
                sqlCommand.Connection = oleConnection;
                sqlCommand.CommandText = "insert into photo(type,puid,photo,memo)values(" + _type + ",'" + _gid + "',@photo,'" + richTextBox1.Text + "')";
                sqlCommand.Parameters.Add("@photo", SqlDbType.Binary);
                sqlCommand.Parameters["@photo"].Value = photo;
                
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！");
            }
            finally
            {
                oleConnection.Close();
            }

            this.loadPic();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_Photo_Activated(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.pictureBox1.Dock = DockStyle.None;
                pictureBox1.Width = Convert.ToInt16(pictureBox1.Width * 1.2);
                pictureBox1.Height = Convert.ToInt16(pictureBox1.Height * 1.2);

                pictureBox1.Top = (splitContainer2.Panel2.Height - pictureBox1.Height) / 2;
                pictureBox1.Left = (splitContainer2.Panel2.Width - pictureBox1.Width) / 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("图片不能再放大了");
            }
        }
                
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Dock = DockStyle.Fill;
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            
        }

        private void Form_Photo_Load(object sender, EventArgs e)
        {
            this.loadPic();
        }
        /// <summary>
        /// 载入图片
        /// </summary>
        private void loadPic()
        { 
            try
            {
                string sql = "Data Source=" + addr + ";Initial Catalog=" + dbname + ";User ID=" + user + ";Password=" + pw + ";Min Pool Size=1";
                oleConnection = new System.Data.SqlClient.SqlConnection(sql);
                oleConnection.Open();
                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
                sqlCommand.Connection = oleConnection;
                sqlCommand.CommandText = "select * from photo where puid='" + _gid + "' and type=" + _type+" ";
                System.Data.SqlClient.SqlDataReader r = sqlCommand.ExecuteReader();
                if (!r.HasRows)
                {
                    ListP.Clear();
                    this.splitContainer2.Panel1.Controls.Clear();

                    pictureBox1.Image = null;
                    this.pt = null;
                    return;
                }

                ListP.Clear();
                while (r.Read())
                {
                    Photo p = new Photo();
                    p.index = r.GetInt32(0);
                    p.type = r.GetInt32(1);
                    p.gid = r.GetString(2);
                    p.phot = (byte[])r.GetValue(3);
                    p.memo = r.GetString(4);
                    ListP.Add(p);
                }
                r.Close();
                this.loadPicBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！");
            }
            finally
            {
                oleConnection.Close();
            }
        }
        /// <summary>
        /// 鼠标点击PIC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pb_MouseClick(object sender, MouseEventArgs e)
        {
                        
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                cms.Show(new Point(MousePosition.X, MousePosition.Y));
                return;
            }
            PictureBox pb = (PictureBox)sender;
            this.pt = ListP.FirstOrDefault(r => r.index == (int)pb.Tag);
            this.pictureBox1.Image = Image.FromStream(new MemoryStream(pt.phot));
            this.richTextBox1.Text = pt.memo;

            foreach (PictureBox p in this.splitContainer2.Panel1.Controls)
            {
                p.Width = p.Height = 55;
            }
            pb.Width = pb.Height = 63;            
        }

        /// <summary>
        /// 右键新增图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewPic(object sender, EventArgs e)
        {
            this.toolStripButton1_Click(sender, e);
        }
        /// <summary>
        /// 修改图片文字说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModPic(object sender, EventArgs e)
        {
            if (this.pt == null)
            {
                MessageBox.Show("请先点击图片，预览图片后在保存修改！"); return;
            }
            int index = pt.index;
            byte[] photoBytes=SetImgToByte(string.Empty);

            try
            {
                string sql = "Data Source=" + addr + ";Initial Catalog=" + dbname + ";User ID=" + user + ";Password=" + pw + ";Min Pool Size=1";
                oleConnection = new System.Data.SqlClient.SqlConnection(sql);
                oleConnection.Open();
                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
                sqlCommand.Connection = oleConnection;
                sqlCommand.CommandText = "update photo set memo='"+this.richTextBox1.Text.Trim()+"',photo=@photo where id=" + index;
                sqlCommand.Parameters.Add("@photo", SqlDbType.Binary);
                sqlCommand.Parameters["@photo"].Value = photoBytes;
                sqlCommand.ExecuteNonQuery();
                this.pt = null;
                MessageBox.Show("修改成功！");
                this.loadPic();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！");
            }
            finally
            {
                oleConnection.Close();
            }
        }
        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelPic(object sender, EventArgs e)
        {
            int index = pt.index;
            try
            {
                string sql = "Data Source=" + addr + ";Initial Catalog=" + dbname + ";User ID=" + user + ";Password=" + pw + ";Min Pool Size=1";
                oleConnection = new System.Data.SqlClient.SqlConnection(sql);
                oleConnection.Open();
                System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
                sqlCommand.Connection = oleConnection;
                sqlCommand.CommandText = "delete from  photo where id=" + index;
                sqlCommand.ExecuteNonQuery();
                
                this.pt = null;
                
                this.loadPic();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！");
            }
            finally
            {
                oleConnection.Close();
            }
        }

        private void DownLoadPic()
        {
            if (this.pictureBox1.Image == null) return;
            if (this.pt == null) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "jpg";
            sfd.FileName = DateTime.Now.Ticks.ToString();
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            string path = sfd.FileName;
            try
            {
                using (System.IO.FileStream fs = new FileStream(path, FileMode.Create))
                {
                    fs.Write(pt.phot, 0, pt.phot.Length);
                    fs.Close();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (MessageBox.Show("下载成功！需要打开路径吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        /// <summary>
        /// 从LISTP中载入图片到PICTUREBOX
        /// </summary>
        private void loadPicBox()
        {
            if (ListP.Count <= 0) return;
            MemoryStream ms = null;
            Image image = null;
            splitContainer2.Panel1.Controls.Clear();
            foreach (var r in ListP)
            {
                PictureBox pb = new PictureBox();
                pb.Width = pb.Height = 52;
                pb.Left = 15;
                pb.BackColor = Color.DimGray;
                pb.BorderStyle = BorderStyle.Fixed3D;
                pb.MouseClick += new MouseEventHandler(pb_MouseClick);
                pb.MouseHover += new EventHandler(pb_MouseHover);
                pb.Cursor = System.Windows.Forms.Cursors.Hand;
                pb.SizeMode = PictureBoxSizeMode.CenterImage;
                if (splitContainer2.Panel1.Controls.Count > 0)
                {
                    pb.Top = splitContainer2.Panel1.Controls[splitContainer2.Panel1.Controls.Count - 1].Top + splitContainer2.Panel1.Controls[splitContainer2.Panel1.Controls.Count - 1].Height + 10;
                }
                else
                {
                    pb.Top = 10;
                }
                
                splitContainer2.Panel1.Controls.Add(pb);

                ms = new MemoryStream(r.phot);
                image = Image.FromStream(ms);
                this.pictureBox1.Image = image;
                pb.Image = image.GetThumbnailImage(55, 55, null, IntPtr.Zero);
                this.richTextBox1.Text = r.memo;
                pb.Tag = r.index;
            }
            ms = new MemoryStream(ListP[0].phot);
            this.pt = ListP[0];
            this.richTextBox1.Text = ListP[0].memo;
            image = Image.FromStream(ms);

            this.pictureBox1.Image = image;
        }

        void pb_MouseHover(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            foreach (PictureBox p in this.splitContainer2.Panel1.Controls)
            {
                p.Width = p.Height = 55;
            }
            pb.Width = pb.Height = 65;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Dock = DockStyle.None;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Width = Convert.ToInt16(pictureBox1.Width * 0.8);
                pictureBox1.Height = Convert.ToInt16(pictureBox1.Height * 0.8);
                pictureBox1.Top = (splitContainer2.Panel2.Height - pictureBox1.Height) / 2;
                pictureBox1.Left = (splitContainer2.Panel2.Width - pictureBox1.Width) / 2;
            }
            catch
            {
                MessageBox.Show("图片无法再缩小!");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null) return;
            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pictureBox1.Refresh();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null) return;
            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.pictureBox1.Refresh();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.pictureBox1.Image == null) return;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            cms2.Show(MousePosition.X, MousePosition.Y);
        }

        private void Form_Photo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._type != 32) return;
            if (this.ListP.Count <= 0)
            {
                if (MessageBox.Show("您还没有上传图片，需要继续退出吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

    }
    public class Photo
    {
        public int index{get;set;}
        public string gid{get;set;}
        public int type{get;set;}
        public byte[] phot{get;set;}
        public string memo{get;set;}
    }

    
}
