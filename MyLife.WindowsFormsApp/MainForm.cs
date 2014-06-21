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

        private void playBtn_Click(object sender, EventArgs e)
        {
            isPlay = true;
            UpdateControlState();

            Play(1, () =>
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
    }
}
