using App.Core.Interfaces.General.Scrutor;

namespace App.Core.Interfaces.GeneralInterfaces
{
    public interface IHeaderRequest : ITransientService
    {
        public Guid? GetUserToken();
    }
}