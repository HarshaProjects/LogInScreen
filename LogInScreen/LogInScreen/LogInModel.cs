using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInScreen
{
    public class LogInModel
    {
        private Dictionary<string, string> UserNameDB;

        public LogInModel()
        {
            this.UserNameDB = new Dictionary<string, string>();
            this.UserNameDB.Add("abc","123");
            this.UserNameDB.Add("xyz", "789");            
        }
        public bool GetApproval(string userName, string password)
        {
            string tempPassword;
            bool available = UserNameDB.TryGetValue(userName, out tempPassword);

            if(available)
            {
                return tempPassword.Equals(password);
            }
            return available;

        }
    }
}
