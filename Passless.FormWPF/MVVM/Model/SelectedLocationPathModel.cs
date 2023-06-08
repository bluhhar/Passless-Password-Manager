using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passless.FormWPF.MVVM.Model
{
    public class SelectedLocationPathModel
    {
        private string _selectedLocationPath = Environment.ExpandEnvironmentVariables(@"%userprofile%\.passless\");

        public void SetRepositoryLocation(string value)
        {
            _selectedLocationPath = value;
        }

        public string GetRepositoryLocation()
        {
            return _selectedLocationPath;
        }
    }
}
