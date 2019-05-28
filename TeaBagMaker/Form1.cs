using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace TeaBagMaker
{
    public partial class Form1 : Form
    {
        int CountOrgNum = 0;
        string[] SList = new string[]{"홍차", "녹차", "루이보스차",
            "국화차"};
        int[] TList = new int[] { 2,3,5,2 };

        string orgStr = ""; // 선택 결과 저장

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < SList.Length; i++)
            {
                this.cbList.Items.Add(this.SList[i]);
            }
            this.orgStr = this.lbl_Time.Text;
            if (this.SList.Length > 0)
            {
                this.cbList.SelectedIndex = 0;
            }
        }

        private void CbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbl_Time.Text = this.orgStr + TList[cbList.Items.IndexOf(cbList.Text)] + "분";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CountOrgNum < 1)
            {
                this.timer.Enabled = false;
                //얘를 안하면 매초마다 알림창이 계속 뜸
                MessageBox.Show("티백을 건지세요!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cbList.Focus();
            }
            else
            {
                this.CountOrgNum--;
                this.txtCountDown.Text = Convert.ToString(this.CountOrgNum/60) + "분" + Convert.ToString(this.CountOrgNum%60) + "초";
            }
        }

        private void Btn_input_Click(object sender, EventArgs e)
        {
            processTimer();
        }
        private void processTimer()
        {
            this.CountOrgNum = TList[cbList.Items.IndexOf(cbList.Text)]*60;
            this.timer.Enabled = true;
        }
    }
}


