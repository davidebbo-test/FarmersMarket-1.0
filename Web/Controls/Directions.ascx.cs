namespace FarmersMarket.Web.Controls
{
    using System;

    public partial class Directions : System.Web.UI.UserControl
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            linkDirections.NavigateUrl =
                @"http://maps.live.com/OneClickDirections.aspx?rtp=%7epos.pz30gz8dvnvr_1225+Morrisville+Carpenter+Rd%2c+Cary%2c+NC_Carpenter+Village_(919)+460-9191_a_&amp;rsd=35.8342909812927_-78.7689685821533_AdlcDyAOAAAA1T2YAPAAAAA%3d_the+east+(via+Dan+K+Moore+Fwy+W+%2f+I-40)%7e35.900431573391_-78.7816581130028_AdlcDyAOAAAAfz2YAD8BAAA%3d_the+east+(via+Northern+Wake+Expy+W+%2f+I-540)%7e35.9040606021881_-78.8832387328148_AdlcDyAOAAAAfj2YAK4AAAA%3d_the+west+(via+John+Motley+Morehead+III+Fwy+E+%2f+I-40)%7e35.8435714244843_-78.8813397288322_AdlcDyAOAAAA1D2YAHYAAAA%3d_the+west+(via+SR-540+E)&amp;&amp;rtv=0";
        }

        #endregion Methods
    }
}