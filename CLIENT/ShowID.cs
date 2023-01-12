using System;
using System.Windows.Forms;

namespace CLIENT
{
    public partial class ShowID : Form
    {
        public ShowID(string id)
        {
            InitializeComponent();
            TBId.Text = id;
        }

        private void BOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
