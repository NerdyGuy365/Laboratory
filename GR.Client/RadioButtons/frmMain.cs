using GR.Business;
using GR.Contracts.DataContracts;
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
        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            //Declare local variables.
            List<Person> people = null;

            //We want to get a reference to the client.
            RadioButton radioButton = (RadioButton)sender;

            //Determine which control are we dealing with.
            switch(radioButton.Name.ToUpper())
            {
                case "RDOGENDER": //User has requested to sort by gender.
                    people = _serviceClient.GetGenders().Result;

                    break;

                case "RDOBIRTHDATE": //User has requested to sort by birth dates.
                    people = _serviceClient.GetBirthDates().Result;

                    break;

                case "RDONAME": //User has requested to sort by names.
                    people = _serviceClient.GetNames().Result;

                    break;
            }            
            
            //Refresh the people data grid view.
            RefreshData(people);
        }
    }
}
