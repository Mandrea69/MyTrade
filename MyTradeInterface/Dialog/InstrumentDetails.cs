using MyTrade.Alpaca;
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
                this.Text = "Details: " + this.result.Instrument.DisplayName;
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
                SetImages(this.result.InstrumentDetails);

            }

            if (this.result.Instrument.Type != "NASDAQ")
            {
                MyTrade.Core.Model.InstrumentDetails iDetails = MyTrade.Core.Strategy.HA_EMAs.Weekly.WeeklyinstrumentDetails(this.result.Instrument);
                SetImagesWeeklyReference(iDetails);

            }
            else
            {
                this.gbWeekly.Visible = false;
            }
            if (this.result.InstrumentDetails!=null)
            {
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
        public void SetImages(MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            var emas = (from x in instrumentDetails.EMAs
                        orderby x.Period
                        select x).ToList();

            if (emas.Count() > 0)
            {
                this.txtCurrentPrice.Text = Math.Round(instrumentDetails.Current, 5).ToString();
                for (int i = 0; i < emas.Count(); i++)
                {
                    if (i == 0)
                    {
                        this.lblEma1.Text = "Ema " + emas[i].Period + " periods";
                        if (emas[i].Value < instrumentDetails.Current)
                        {
                            this.imgEma1.Image = Resources.up;
                        }
                        else
                        {
                            this.imgEma1.Image = Resources.down;
                        }
                    }
                    else
                    {
                        this.lblEma2.Text = "Ema " + emas[i].Period + " periods";
                        if (emas[i].Value < instrumentDetails.Current)
                        {
                            this.imgEma2.Image = Resources.up;
                        }
                        else
                        {
                            this.imgEma2.Image = Resources.down;
                        }

                    }


                }

            }



        }
        public void SetImagesWeeklyReference(MyTrade.Core.Model.InstrumentDetails instrumentDetails)
        {
            var emas = (from x in instrumentDetails.EMAs
                        orderby x.Period
                        select x).ToList();

            if (emas.Count() > 0)
            {
               
                for (int i = 0; i < emas.Count(); i++)
                {
                    if (i == 0)
                    {
                        this.lblEmaW1.Text = "Ema " + emas[i].Period + " periods";
                        if (emas[i].Value < instrumentDetails.Current)
                        {
                            this.imgEmaW1.Image = Resources.up;
                        }
                        else
                        {
                            this.imgEmaW1.Image = Resources.down;
                        }
                    }
                    else
                    {
                        this.lblEmaW2.Text = "Ema " + emas[i].Period + " periods";
                        if (emas[i].Value < instrumentDetails.Current)
                        {
                            this.imgEmaW2.Image = Resources.up;
                        }
                        else
                        {
                            this.imgEmaW2.Image = Resources.down;
                        }

                    }


                }

            }



        }
    }


}
