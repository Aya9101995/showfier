/*****************************************************************************/
/* File Name     : AccountCOM.cs                                            */
/* Created By    : Abdulla Hawwash                                         */
/* Creation Date : 19/12/2017                                             */
/* Comment       : Account                                               */
/************************************************************************/

using MawaqaaCodeLibrary;
using MWCore.Areas.MWCore.Models.DBClasses;
using MWCore.Areas.MWCore.Models.DBClasses.Users;
using System.Linq;

namespace MWCore.Areas.MWCore.Models.Modules.Account
{
    public class AccountCOM
    {
        #region Method :: Login
        public MW_Users Login(MW_Users oUser)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Users oLoggedUser = new MW_Users();
                string sPassword = GetMd5Hash(oUser.Password);
                oLoggedUser = db.MW_Users.Where(u => u.Username == oUser.Username && u.Password == sPassword).SingleOrDefault();
                return oLoggedUser;
            }
        }
        #endregion

        #region Method :: GetMd5Hash
        public string GetMd5Hash(string input)
        {
            return Security.GetMd5Hash(input);
        }
        #endregion

        #region Method :: ChangePassword
        public int ChangePassword(MWCoreModel oModel)
        {
            using (MWCoreEntity db = new MWCoreEntity())
            {
                MW_Users User = new MW_Users();
                string sPassword = GetMd5Hash(oModel.oChangePassword.OldPassword);
                User = db.MW_Users.Where(u => u.ID == oModel.oChangePassword.UserID && u.Password == sPassword).FirstOrDefault();
                if (User == null)
                {
                    return -1;
                }
                else
                {
                    string NewPassword = GetMd5Hash(oModel.oChangePassword.NewPassword);
                    User.Password = NewPassword;
                    db.SaveChanges();
                    return 1;

                }
            }
        }
        #endregion

       
    }
}