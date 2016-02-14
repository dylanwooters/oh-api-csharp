using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OHAPICSharp
{
    public abstract class OHService
    {
        protected string UserID;
        protected string SecretKey;

        //Constructors
        protected OHService() 
        {
            this.UserID = ConfigurationManager.AppSettings["OHUserId"];
            this.SecretKey = ConfigurationManager.AppSettings["OHSecretKey"];
        }

        protected OHService(string userID, string secretKey)
        {
            this.UserID = userID;
            this.SecretKey = secretKey;
        }
    }
}
