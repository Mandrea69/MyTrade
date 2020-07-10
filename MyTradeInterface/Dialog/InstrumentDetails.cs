using MyTradeInterface.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTradeInterface.Dialog
{
    public partial class InstrumentDetails : Form
    {
        MyTrade.Core.Model.Result result;
        public MyTrade.Core.Model.Result Result
        {
            set
            {
                result = value;
                this.Text = "Details: " + this.result.DisplayName;
            }
        }
        public InstrumentDetails()
        {
            InitializeComponent();
        

        }

        private void InstrumentDetails_Load(object sender, EventArgs e)
        {
            if (result.InstrumentDetails != null)
            {
                var ema = from x in result.InstrumentDetails.EMAs
                          where x.Period == 21
                          select x;
               
                this.txtCurrentPrice.Text = Math.Round(result.InstrumentDetails.Current, 5).ToString();
                if (ema.FirstOrDefault().Value < this.result.InstrumentDetails.Current)
                {
                    this.imgEma.Image = Resources.up;
                }
                else
                {
                    this.imgEma.Image = Resources.down;
                }
                if (this.result.InstrumentDetails.W_PivotPoints != null)
                {
                    this.txtD_R2.Text = Math.Round(this.result.InstrumentDetails.W_PivotPoints.R2, 5).ToString();
                    this.txtD_R1.Text = Math.Round(this.result.InstrumentDetails.W_PivotPoints.R1, 5).ToString();
                    this.txtD_PP.Text = Math.Round(this.result.InstrumentDetails.W_PivotPoints.PP, 5).ToString();
                    this.txtD_S1.Text = Math.Round(this.result.InstrumentDetails.W_PivotPoints.S1, 5).ToString();
                    this.txtD_S2.Text = Math.Round(this.result.InstrumentDetails.W_PivotPoints.S2, 5).ToString();
                }
                if (this.result.InstrumentDetails.M_PivotPoints != null)
                {
                    this.txtW_R2.Text = Math.Round(this.result.InstrumentDetails.M_PivotPoints.R2, 5).ToString();
                    this.txtW_R1.Text = Math.Round(this.result.InstrumentDetails.M_PivotPoints.R1, 5).ToString();
                    this.txtW_PP.Text = Math.Round(this.result.InstrumentDetails.M_PivotPoints.PP, 5).ToString();
                    this.txtW_S1.Text = Math.Round(this.result.InstrumentDetails.M_PivotPoints.S1, 5).ToString();
                    this.txtW_S2.Text = Math.Round(this.result.InstrumentDetails.M_PivotPoints.S2, 5).ToString();
                }
            }
        }
    }
}
