using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSound.Models
{
    public class User
    {
         private string _credit = null;
        private string _imageCredit = null;
        public string Credit
        {
            get
            {
                return _credit;
            }
            set
            {
                _credit = value;
                CreditUpdated(this, EventArgs.Empty);
            }
        }

        public string imageCredit
        {
            get
            {
                return _imageCredit;
            }
            set
            {
                _imageCredit = value;
                imageCreditUpdated(this, EventArgs.Empty);
            }
        }

        public static User instance = new User();

        public event EventHandler CreditUpdated;
        public event EventHandler imageCreditUpdated;
    }
}
