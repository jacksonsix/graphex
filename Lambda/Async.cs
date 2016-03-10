using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    using System.Windows.Forms;

    //partial class AsyncForm : Form
    //{
    //    private TextBox textbox1;
    //    public AsyncForm()
    //    {
    //        textbox1 = new TextBox();
    //    }

    //    private async void button1_Click(object sender, EventArgs e)
    //    {
    //        await MethodAsync();
    //        textbox1.Text += "returned to lick event";
    //    }

    //    private async Task MethodAsync()
    //    {
    //        await Task.Delay(1000);
    //    }
    //}

    partial class AsyncForm : Form
    {
        private Button button1;
        public AsyncForm()
        {
            button1 = new Button();
            button1.Click += async (sender,e) =>
                    {
                        await MethodAsync2();
                       // textbox1.Text += "return from lambda";
                    }
                     ;

        }

        private async Task MethodAsync2()
        {
            await Task.Delay(1000);
        }
    }
}
