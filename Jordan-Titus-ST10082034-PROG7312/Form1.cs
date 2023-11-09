using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jordan_Titus_ST10082034_PROG7312
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIdentifyAreas_Click(object sender, EventArgs e)
        {
            Identifying_Areas areas = new Identifying_Areas();
            areas.Show();
            this.Hide();
        }

        //Couldn't figure out how to get this to play
        //Got this
        private void playSoundFromResource(object sender, EventArgs e)
        {
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream s = a.GetManifestResourceStream("C418  - Sweden - Minecraft Volume Alpha.wav");
            SoundPlayer player = new SoundPlayer(s);
            player.PlayLooping();
        }
    }
}
