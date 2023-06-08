using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passless.FormWPF.MVVM.Model
{
    public class KeyOwnerModel
    {
        private string _keyOwner;

        public void SetKeyOwner(string value)
        {
            _keyOwner = value;
        }

        public string GetKeyOwner()
        {
            return _keyOwner;
        }
    }
}
