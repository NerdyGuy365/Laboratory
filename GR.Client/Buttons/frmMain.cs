using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GR.Client
{
    /// <summary>
    /// Shared helper class to handle button events for the main form.
    /// </summary>
    public partial class frmMain
    {
        /// <summary>
        /// Generic event handle to handle all button events from the main screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            //Right now there is only one button on the screen.
            var result = UpdateData();

            //We need to find out what happened from our server request.
            if (result.Result.ToUpper() == "OK")
            {
                //SUCCESS!
                MessageBox.Show("Information saved successfully!!!");

                //Now let the user sort the data.
                ShowSortControls();
            }
            else
            {
                //Something unexpected happen.
                //Since this is demo.

                //We will display a more technical message.
                MessageBox.Show(result.Result);
            }

        }
    }
}
