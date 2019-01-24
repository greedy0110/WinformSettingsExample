using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundSettingsEx
{
    public partial class Form1 : Form
    {
        Color[] colorList = new Color[] { Color.White, Color.Yellow, Color.Green, Color.Black, Color.Blue };
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            // Settings 읽기
            BackColor = Properties.Settings.Default.Background;

            // Settings 변경시 이벤트 등록해서 gui 실시간 반영
            Properties.Settings.Default.SettingsSaving += Default_SettingsSaving;

            // SettingsSaving => 저장 된 이후
            // SettingChanging => 저장 할 건데, 저장하기 전 값으로 한다.
        }

        private void Default_SettingsSaving(object sender, CancelEventArgs e)
        {
            // Settings 읽기
            BackColor = Properties.Settings.Default.Background;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Settings 변경시 이벤트 등록해제 해야 한다.
            Properties.Settings.Default.SettingsSaving -= Default_SettingsSaving;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            // Settings 쓰기
            Properties.Settings.Default.Background = colorList[random.Next() % colorList.Length];
            Properties.Settings.Default.Save();
        }
    }
}
