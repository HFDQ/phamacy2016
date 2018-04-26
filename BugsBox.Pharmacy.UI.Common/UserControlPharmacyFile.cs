using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.PS;
using Microsoft.SqlServer.Server;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.UI.Common
{
    public partial class UserControlPharmacyFile : Form
    {
        public UserControlPharmacyFile():this(false)
        { 
            InitializeComponent();
            this.TopLevel = false;
            if (!DesignMode)
            {
                service = ServicesProvider.Instance.PharmacyDatabaseService;
                RunForm = runForm;
                this.Mode = FormRunMode.Edit;
            }
        }

        private FormRunMode mode = FormRunMode.Edit;

        public FormRunMode Mode
        {
            set
            {
                mode = value;
                buttonSelect.Visible =
                    buttonUpload.Visible = buttonReset.Visible = buttonOK.Visible = mode == FormRunMode.Edit;
            }

        }

        public UserControlPharmacyFile(bool runForm)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                service = ServicesProvider.Instance.PharmacyDatabaseService;
                RunForm = runForm; 
            }
        }

        #region 属性与字段

        private bool runForm = false;

        private bool RunForm
        {
            get
            {
                return runForm;
            }
            set
            {
                runForm = value;
                if (!runForm)
                {
                    this.buttonCancel.Hide();
                    this.buttonOK.Hide();
                }

            }
        }


        [Description("设置或获取图片预览标题")]
        public string Title
        {
            get { return this.groupBoxPreView.Text; }
            set
            {
                this.groupBoxPreView.Text = value;
                this.Text = string.Format("[{0}]编辑", value);
            }
        }

        private PharmacyFile oldPharmacyFile;

        [Browsable(false)]
        public PharmacyFile OldPharmacyFile
        {
            get
            {
                return oldPharmacyFile;
            }
            set
            {
                oldPharmacyFile = value;
                this.PharmacyFile = oldPharmacyFile;
            }
        }
        [Browsable(false)]
        public PharmacyFile PharmacyFile
        {
            get
            {
                return pharmacyFile;
            }
            private set
            {
                pharmacyFile = value;
                if (!DesignMode)
                {
                        LoadPharmacyFile();
                        PreviewPicture(false);
                }
            }
        }

        private PharmacyFile pharmacyFile;

        private IPharmacyDatabaseService service { get; set; }

        private string selectedFile { get; set; }

        #endregion 属性与字段

        #region 事件处理

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonReset_Click(null, null);
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        } 

        /// <summary>
        /// 选择本地图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK
                && !string.IsNullOrWhiteSpace(openFileDialog1.FileName)
                && File.Exists(openFileDialog1.FileName)
                )
            {
                DeleteNotUsedFile();
                selectedFile = openFileDialog1.FileName;
                pharmacyFile = new PharmacyFile();
                pharmacyFile.Id = Guid.NewGuid();
                pharmacyFile.UpdateUserId = AppClientContext.CurrentUser==null?Guid.Empty:AppClientContext.CurrentUser.Id;
                pharmacyFile.FileName = Path.GetFileName(selectedFile);
                pharmacyFile.UpdateTime = DateTime.Now;
                pharmacyFile.CreateTime = pharmacyFile.UpdateTime;
                pharmacyFile.CreateUserId = pharmacyFile.UpdateUserId;
                pharmacyFile.Extension = Path.GetExtension(selectedFile);
                PreviewPicture(true);
                this.buttonUpload.Enabled = true;
                this.buttonReset.Enabled = true;

            }

        } 

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (pharmacyFile != null)
                {
                    byte[] fileBytes = null;
                    using (var stream = new FileStream(selectedFile, FileMode.Open, FileAccess.ReadWrite))
                    {
                        BinaryReader r = new BinaryReader(stream); 
                        r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开 
                        fileBytes = r.ReadBytes((int)r.BaseStream.Length); 
                    }
                    if (fileBytes != null && fileBytes.Count() > 0)
                    {
                        pharmacyFile.FileStream = fileBytes;
                    }
                    string msg;
                    bool result = service.AddPharmacyFile(out msg, pharmacyFile);
                    if (result && string.IsNullOrWhiteSpace(msg))
                    {
                        MessageBox.Show("上传成功", "上传", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.buttonUpload.Enabled = false;
                        this.buttonReset.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("上传失败", "上传", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            { 
                LoggerHelper.Instance.Error(ex);
                MessageBox.Show("文件上传失败:" + ex.Message, "上传", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        } 

        #endregion

        #region 从服务端获取数据

        /// <summary>
        /// 从服务端获取证书
        /// </summary>
        /// <returns></returns>
        private bool LoadPharmacyFile()
        {
            try
            {
                if (pharmacyFile != null && pharmacyFile.Id != Guid.Empty)
                {
                    //
                    string msg;
                    ////pharmacyFile = service.GetPharmacyFile(out msg, pharmacyFile.Id);
                    //if (pharmacyFile == null || !string.IsNullOrWhiteSpace(msg))
                    //{
                    //    MessageBox.Show("该证书不存在" + msg, "文件上传", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //}
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                pharmacyFile = null;
                LoggerHelper.Instance.Error(ex);
                MessageBox.Show("从服务器获取证书失败" + ex.Message, "上传", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        #endregion

        #region 数据到服务器

        public void DeleteNotUsedFile()
        {
            if ((pharmacyFile != null&&oldPharmacyFile!=null&&pharmacyFile.Id!=oldPharmacyFile.Id)
                ||(pharmacyFile != null && pharmacyFile.Id!=Guid.Empty))
                
            {
                
                try
                {
                    string msg;
                    //service.DeletePharmacyFile(out msg, pharmacyFile.Id);
                }
                catch (Exception ex)
                { 
                    LoggerHelper.Instance.Error(ex);
                }
            }
               
        }

        #endregion

        #region 数据到控件


        public void PreviewPicture(bool local = true)
        {
            if (DesignMode)
                return;
            this.pictureBox1.CreateGraphics().Clear(pictureBox1.BackColor);
            Stream stream = null;
            if (local && File.Exists(selectedFile))
            {
                //取本地图片预览
                if (CanPreview(Path.GetExtension(selectedFile)))
                {
                    try
                    {
                        stream = new FileStream(selectedFile, FileMode.Open, FileAccess.ReadWrite);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("图片读取失败:" + ex.Message, "上传", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                  
                }
            }
            if (!local && pharmacyFile != null
                && !string.IsNullOrWhiteSpace(pharmacyFile.FileName)
                && !string.IsNullOrWhiteSpace(pharmacyFile.Extension)
                && pharmacyFile.FileStream != null
                && pharmacyFile.FileStream.Count() > 0
                )
            {
                //远程图片预览 
                if (CanPreview(Path.GetExtension(pharmacyFile.Extension)))
                {
                    stream = new MemoryStream(pharmacyFile.FileStream);
                }
            }
            if (stream != null && stream.Length > 0)
            {
                try
                {
                    Image image = Image.FromStream(stream);
                    this.pictureBox1.Image = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("预览图片失败" + ex.Message, "上传", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            if (stream != null)
            {
                try
                {
                    stream.Dispose();
                }
                catch (Exception ex)
                {
                   
                }
            }
        }

        #endregion 数据到控件

        #region 控件到数据

        #endregion 控件到数据

        #region 内部方法

        private const string PictureFileExtentsion = ".jpg.jpeg.png.bmp";

        /// <summary>
        /// 是否是图片
        /// </summary>
        /// <param name="extentsion"></param>
        /// <returns></returns>
        private static bool CanPreview(string extentsion)
        {
            if (string.IsNullOrWhiteSpace(extentsion))
                return false;
            return PictureFileExtentsion.Contains(extentsion.ToLower());
        }

        #endregion 内部方法

        private void buttonReset_Click(object sender, EventArgs e)
        {
            selectedFile = string.Empty; 
            pharmacyFile = oldPharmacyFile;
            DeleteNotUsedFile(); 
            PreviewPicture(false);
        
        }

        private void UserControlPharmacyFile_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.buttonUpload.Enabled = false;
            this.buttonReset.Enabled = false;
            PharmacyFile = oldPharmacyFile; 
        } 
    }
}
