using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Manager
{
    /// <summary>
    /// This base class is used to provide standard base operations for business management task such as security and loggin exceptions.
    /// Something like sending out emails would go here as well.
    /// </summary>
    public class ManagerBase
    {
        /// <summary>
        /// This is just here to show that the manager base can handle all security concerns for each manager.
        /// </summary>
        /// <returns></returns>
        public bool isAuthenticated(string userName, string password)
        {
            //We are just emulating security here.
            return true;
        }

        /// <summary>
        /// This is just here to show that the manager base can handle all logging concerns for each manager.
        /// </summary>
        /// <param name="ex"></param>
        public void LogExpection(Exception ex)
        {
            //Add logging code here.
        }
    }
}
