using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Passless.Modules;

namespace Passless.FormWPF.MVVM.Model
{
    public class SelectedLocationPathModel
    {
        private string _defaultLocationFilePath = Environment.ExpandEnvironmentVariables(@"%userprofile%\AppData\Local\Passless");
        private string _selectedLocationPath;

        public void SetRepositoryLocation(string value)
        {
            _selectedLocationPath = value;
            FileHelper.Writer(_defaultLocationFilePath, _selectedLocationPath, "\\.repository_location");
        }

        public string GetRepositoryLocation()
        {
            _selectedLocationPath = FileHelper.Reader(_defaultLocationFilePath, "\\.repository_location");
            return _selectedLocationPath;
        }

        public string GetDefaultRepositoryLocation() 
        { 
            return _defaultLocationFilePath; 
        }
    }
}
