using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Timer timer1;
       static int k = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Text = DateTime.Now.ToString("hh:mm:ss");
            //timer1 = new Timer();
            //timer1.Interval = 10;
            //timer1.Enabled = true;
            //timer1.Tick += timer1_Tick;
                
        }

    //    void timer1_Tick(object sender, EventArgs e)
    //    {
    //        Label1.Text = DateTime.Now.ToString("hh:mm:ss");
    //        //throw new NotImplementedException();
    //    }

    //    protected void Timer1_Tick1(object sender, EventArgs e)
    //    {
    //        Label1.Text = DateTime.Now.ToString("hh:mm:ss");
    //    }
    }
}