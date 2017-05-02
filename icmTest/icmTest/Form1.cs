using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace icmTest
{
    public partial class Form1 : Form
    {
        ICMCalculator ev = new ICMCalculator();

        public Form1()
        {
            InitializeComponent();

            FormFormat();

            tbPlayer1.Text = "1000";
            tbPlayer2.Text = "1100";
            tbPlayer3.Text = "1200";
            tbPlayer4.Text = "1300";
            tbPlayer5.Text = "1400";
            tbPlayer6.Text = "1500";
            //comment these out to work for 6 man
            tbPlayer7.Text = "0";
            tbPlayer8.Text = "0";
            tbPlayer9.Text = "0";

            tbFirstPlace.Text = "60";
            tbSecondPlace.Text = "40";
            tbThirdPlace.Text = "0";

            tbTotal.Text = "150";

            tbBb.Text = "100";
            tbSb.Text = "50";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int total = Convert.ToInt32(tbTotal.Text);

            int[] chips = 
                {
                Convert.ToInt32(tbPlayer1.Text),
                Convert.ToInt32(tbPlayer2.Text),
                Convert.ToInt32(tbPlayer3.Text),
                Convert.ToInt32(tbPlayer4.Text),
                Convert.ToInt32(tbPlayer5.Text),
                Convert.ToInt32(tbPlayer6.Text),
                //comment these out to work for 6 man
                Convert.ToInt32(tbPlayer7.Text),
                Convert.ToInt32(tbPlayer8.Text),
                Convert.ToInt32(tbPlayer9.Text)
                };

            int[] struc =
                {
                Convert.ToInt32(tbFirstPlace.Text),
                Convert.ToInt32(tbSecondPlace.Text),
                Convert.ToInt32(tbThirdPlace.Text),
                };

            double[] equity = ev.CalcEV(struc, chips);

            int[] chipstwo =
            {
                (Convert.ToInt32(tbPlayer1.Text) + ((Convert.ToInt32(tbSb.Text))+(Convert.ToInt32(tbBb.Text)))/7),
                (Convert.ToInt32(tbPlayer2.Text) + ((Convert.ToInt32(tbSb.Text))+(Convert.ToInt32(tbBb.Text)))/7),
                (Convert.ToInt32(tbPlayer3.Text) + ((Convert.ToInt32(tbSb.Text))+(Convert.ToInt32(tbBb.Text)))/7),
                (Convert.ToInt32(tbPlayer4.Text) + ((Convert.ToInt32(tbSb.Text))+(Convert.ToInt32(tbBb.Text)))/7),
                (Convert.ToInt32(tbPlayer5.Text) + ((Convert.ToInt32(tbSb.Text))+(Convert.ToInt32(tbBb.Text)))/7),
                (Convert.ToInt32(tbPlayer6.Text) + ((Convert.ToInt32(tbSb.Text))+(Convert.ToInt32(tbBb.Text)))/7),
                //comment these out to work for 6 man
                (Convert.ToInt32(tbPlayer7.Text) + ((Convert.ToInt32(tbSb.Text))+(Convert.ToInt32(tbBb.Text)))/7),
                (Convert.ToInt32(tbPlayer8.Text) - (Convert.ToInt32(tbSb.Text))),
                (Convert.ToInt32(tbPlayer9.Text) - (Convert.ToInt32(tbBb.Text)))
            };

            double[] equity2 = ev.CalcEV(struc, chipstwo);

            //lblEquity1.Text = Math.Round(equity[0], 2) + "% or $" + ((Math.Round(equity[0], 2) / 100) * total);
            lblEquity1.Text = Math.Round(equity[0], 2) + "% or $" + Math.Round(((equity[0] / 100) * total), 2);
            lblEquity2.Text = Math.Round(equity[1], 2) + "% or $" + Math.Round(((equity[1] / 100) * total), 2);
            lblEquity3.Text = Math.Round(equity[2], 2) + "% or $" + Math.Round(((equity[2] / 100) * total), 2);
            lblEquity4.Text = Math.Round(equity[3], 2) + "% or $" + Math.Round(((equity[3] / 100) * total), 2);
            lblEquity5.Text = Math.Round(equity[4], 2) + "% or $" + Math.Round(((equity[4] / 100) * total), 2);
            lblEquity6.Text = Math.Round(equity[5], 2) + "% or $" + Math.Round(((equity[5] / 100) * total), 2);
            //comment these out to work for 6 man
            lblEquity7.Text = Math.Round(equity[6], 2) + "% or $" + Math.Round(((equity[6] / 100) * total), 2);
            lblEquity8.Text = Math.Round(equity[7], 2) + "% or $" + Math.Round(((equity[7] / 100) * total), 2);
            lblEquity9.Text = Math.Round(equity[8], 2) + "% or $" + Math.Round(((equity[8] / 100) * total), 2);

            //Future equity worked out incorrectly - TODO
            lblFequity1.Text = Math.Round(equity2[0], 2) + "%";
            lblFequity2.Text = Math.Round(equity2[1], 2) + "%";
            lblFequity3.Text = Math.Round(equity2[2], 2) + "%";
            lblFequity4.Text = Math.Round(equity2[3], 2) + "%";
            lblFequity5.Text = Math.Round(equity2[4], 2) + "%";
            lblFequity6.Text = Math.Round(equity2[5], 2) + "%";
            //comment these out to work for 6 man
            lblFequity7.Text = Math.Round(equity2[6], 2) + "%";
            lblFequity8.Text = Math.Round(equity2[7], 2) + "%";
            lblFequity9.Text = Math.Round(equity2[8], 2) + "%";
        }



        private void FormFormat()
        {
            lblEquity1.Font = new Font(lblEquity1.Font, FontStyle.Bold);
            lblEquity1.ForeColor = System.Drawing.Color.Green;

            lblEquity2.Font = new Font(lblEquity2.Font, FontStyle.Bold);
            lblEquity2.ForeColor = System.Drawing.Color.Green;

            lblEquity3.Font = new Font(lblEquity3.Font, FontStyle.Bold);
            lblEquity3.ForeColor = System.Drawing.Color.Green;

            lblEquity4.Font = new Font(lblEquity4.Font, FontStyle.Bold);
            lblEquity4.ForeColor = System.Drawing.Color.Green;

            lblEquity5.Font = new Font(lblEquity5.Font, FontStyle.Bold);
            lblEquity5.ForeColor = System.Drawing.Color.Green;

            lblEquity6.Font = new Font(lblEquity6.Font, FontStyle.Bold);
            lblEquity6.ForeColor = System.Drawing.Color.Green;

            //enable to work for 6
            //lblPlayer7.Hide();
            //lblPlayer8.Hide();
            //lblPlayer9.Hide();
            //tbPlayer7.Hide();
            //tbPlayer8.Hide();
            //tbPlayer9.Hide();
            //lblEquity7.Hide();
            //lblEquity8.Hide();
            //lblEquity9.Hide();

            //lblThirdPlace.Hide();
            //tbThirdPlace.Hide();
        }


    }
}
