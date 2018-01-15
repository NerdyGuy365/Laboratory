using GR.Business;
using GR.Common;
using GR.Contracts.DataContracts;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GR.Client
{
    /// <summary>
    /// Shared helper class to handle general task for the main form.
    /// </summary>
    public partial class frmMain
    {
        /// <summary>
        /// This is a helper method used to determine which sorting command the user has requested.
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        private async Task<List<Person>> GetPeople(SortBy sortBy)
        {
            //In the voice of a factory patter. Determine which action the user has requested and execute that action.
            switch(sortBy)
            {
                case SortBy.Genders:
                    return await _serviceClient.GetGenders().ConfigureAwait(false);

                case SortBy.BirthDates:
                    return await _serviceClient.GetBirthDates().ConfigureAwait(false);

                case SortBy.LastNames:
                    return await _serviceClient.GetNames().ConfigureAwait(false);
            }

            //If the code lands here. It hasn't been coded yet.
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is a helper method used to persistence data back and forth to
        /// </summary>
        /// <returns></returns>
        private async Task<string> UpdateData()
        {
            try
            {
                return await _serviceClient.PostRecords(_people).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                //Since the service will display a friendly error.
                //Let the service message inform the user.
                return ex.ToString();
            }
        }
        /// <summary>
        /// A method using a list of persons to display data.
        /// </summary>
        /// <param name="people"></param>
        private void RefreshData(List<Person> people, bool clearData = true)
        {
            if (people != null)
            {
                if(clearData)
                    dgvProfiles.Rows.Clear();

                foreach (var person in people)
                {
                    dgvProfiles.Rows.Add(new object[] { person.LastName, person.FirstName, person.Gender, person.FavoriteColor, person.DateOfBirth.ToString("M'/'d'/'yyyy") });
                }
            }            
        }

    

        /// <summary>
        /// This is a helper method used to display hidden user controls.
        /// As well as disable the user's ablity to do a double post.
        /// 
        /// This is for demo purposes.
        /// </summary>
        private void ShowSortControls()
        {
            rdoGender.Visible = true;
            rdoBirthDate.Visible = true;
            rdoName.Visible = true;

            lblSortBy.Visible = true;

            btnSave.Enabled = false;
        }
    }
}
