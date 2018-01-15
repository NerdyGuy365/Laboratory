using GR.Business;
using GR.Contracts.DataContracts;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GR.Client
{
    /// <summary>
    /// NOTE: I see someone else seperate the controls into folders like this.
    /// I like the idea from an organization standpoint.
    /// 
    /// I thought this would be a great idea to discussion with other devs about the approach.
    /// </summary>
    public partial class frmMain : Form
    {
        //Form scoper variables section.
        private List<Person> _people = new List<Person>();
        private PersonServiceClient _serviceClient = new PersonServiceClient();

        public frmMain()
        {
            InitializeComponent();

            this.Load += frmMain_Load;
        }

        /// <summary>
        /// React to the loading of the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //See Actions Folder in project.

                //Pull out the data from each file and display it to the user.
                _people.AddRange(PersonHelpers.ParsePersonDataFromFile(Application.StartupPath + @"\LocalData\FileStructure1.txt"));
                _people.AddRange(PersonHelpers.ParsePersonDataFromFile(Application.StartupPath + @"\LocalData\FileStructure2.txt"));
                _people.AddRange(PersonHelpers.ParsePersonDataFromFile(Application.StartupPath + @"\LocalData\FileStructure3.txt"));
                
                //Refresh the datagrid of people.
                RefreshData(_people, false);
            }
            catch
            {
                //An exception can occur when dealing with files. 
                //Since this is a demo. Just throw a dummy message.
                MessageBox.Show("It looks like you might have have a file in the correct place. Please double check the LocalData folder.");
            }
        }
    }
}
