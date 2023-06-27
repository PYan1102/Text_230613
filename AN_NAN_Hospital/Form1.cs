using System.Diagnostics;

namespace OnCube_Switch
{
    public partial class Form1 : Form  //主程式區
    {

        CSVProcess _csvProcess = new CSVProcess();  //創個讀取用的

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {


            TB_CSV.Text = Settings.InputPath;                    //一開始要設定的路徑
            TB_TXT.Text = Settings.OutputPath;
            TB_BackupPath.Text = Settings.BackupPath;
            this.TopMost = true;

            SwitchButtonEnabelState(false);

        }
        private void Select_CSV_Folder_Click(object sender, EventArgs e)     //點擊選擇CSV檔資料夾
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {


                TB_CSV.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box



                bool check = Directory.Exists(TB_CSV.Text);         //確認是否有效路徑

                if (!check)
                {
                    MessageBox.Show("請再次確認路徑是否正確");
                    return;
                }
                else
                {
                    Settings.InputPath = TB_CSV.Text = Folder_BrowserDialog.SelectedPath;

                    Settings.Save();
                }


            }
        }

        private void Select_TXT_Folder_Click(object sender, EventArgs e)           //點擊選擇TXT檔資料夾
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {

                TB_TXT.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                bool check = Directory.Exists(TB_TXT.Text);         //確認是否有效路徑
                if (!check)
                {
                    MessageBox.Show("請再次確認路徑是否正確");
                    return;
                }
                else
                {
                    Settings.OutputPath = TB_TXT.Text = Folder_BrowserDialog.SelectedPath;


                    Settings.Save();
                }


            }
        }

        private void Select_Backup_Folder_Click(object sender, EventArgs e)
        {
            if (Folder_BrowserDialog.ShowDialog() == DialogResult.OK)  //有選擇了
            {
                TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;    //把選擇路徑給Text.box
                Settings.BackupPath = TB_BackupPath.Text = Folder_BrowserDialog.SelectedPath;
                Settings.Save();
            }
        }


        private void STAR_Btn_Click(object sender, EventArgs e)       //開始
        {


            STAR_Btn.Enabled = false;
            STAR_Btn.Text = "正在讀取....";


            STAR_Btn.Enabled = true;
            STAR_Btn.Text = "開始";
        }

        public void ClearTB_CSV()
        {
            TB_CSV.Text = string.Empty;
        }

        private void SwitchButtonEnabelState(bool start)
        {
            STAR_Btn.Enabled = !start;
            STOP_Btn.Enabled = start;
        }

        private void STOP_Btn_Click(object sender, EventArgs e)
        {
            _csvProcess.Stop();
            SwitchButtonEnabelState(false);
        }
    }







}