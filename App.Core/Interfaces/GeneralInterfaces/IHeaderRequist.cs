using App.Core.Interfaces.General.Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Interfaces.GeneralInterfaces
{
    public interface IHeaderRequist:ITransientService
    {
        public Guid? GetUserToken();

    }
}
