using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Hunter_And_Prey
{
    class Kutu : Button
    {

        public Kutu(int id)
        {
            this.Size = new Size(50, 50);
            this.Name = "btn" + id;
            this.Text = "";
            this.BackColor = Color.White;
            this.ForeColor = Color.White;
            this.Font = new Font("Georgia", 12, FontStyle.Italic);
        }


    }
}
