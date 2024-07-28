using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ticketing
{
    public partial class TicketsForm : Form
    {
        TicketPrice mTicketPrice;
        int mSection = 2;
        int mQuantity = 0;
        bool mDiscount = false;
        decimal mDiscountAmt = 0m;

        public TicketsForm()
        {
            InitializeComponent();
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {

        }

        private void cmdCalculate_Click(object sender, EventArgs e)
        {
            mQuantity = int.Parse(txtQuantity.Text);

            if (radBalcony.Checked)
                { mSection = 1; }
            if (radGeneral.Checked)
                { mSection = 2; }
            if (radBox.Checked)
                { mSection = 3; }

            mTicketPrice = new TicketPrice(mSection, mQuantity, mDiscount, mDiscountAmt);

            mTicketPrice.calculatePrice();
            lblAmount.Text = System.Convert.ToString(mTicketPrice.AmountDue);
        }

        private void chkDiscount_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked) {
                chkChild.Checked = false;
                txtDiscount.Text = "5"; 
                mDiscount = true;
                mDiscountAmt = 5m;
            }
            else { txtDiscount.Text = ""; mDiscount = false; }
        }

        private void chkChild_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkChild.Checked) {
                chkDiscount.Checked = false;
                txtDiscount.Text = "10"; 
                mDiscount = true;
                mDiscountAmt = 10m;
            }
            else { txtDiscount.Text = ""; mDiscount = false; }
        }
    }
}
