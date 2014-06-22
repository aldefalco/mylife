using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLife.WindowsFormsApp
{
    public partial class MainForm : Form
    {
        private bool isPlay = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            gameControl.Turn();
        }

        private async void playBtn_Click(object sender, EventArgs e)
        {
            isPlay = true;
            UpdateControlState();

            await Play(1, () =>
            {
                gameControl.Turn();   
                return isPlay;
            });
        }

        private void UpdateControlState()
        {
            nextBtn.Enabled = !isPlay;
            playBtn.Enabled = !isPlay;
            stopBtn.Enabled = isPlay;
            saveBtn.Enabled = !isPlay;
            loadBtn.Enabled = !isPlay;
            clearBtn.Enabled = !isPlay;
        }

        private async Task Play(int delay,
                              Func<bool> update)
        {
            var play = true;
            while (play)
            {
                await Task.Delay(TimeSpan.FromSeconds(delay));
                play = update();
            }

            UpdateControlState();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            isPlay = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                UseWaitCursor = true;
                gameControl.SaveToFile(dlg.FileName);
                UseWaitCursor = false;
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                UseWaitCursor = true;
                gameControl.LoadFromFile(dlg.FileName);
                UseWaitCursor = false;
            }
        }
    }
}
