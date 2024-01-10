using PropertyEntity;

namespace PropertyMVC.HTTPAPI.StateHTTPAPI
{
    public interface IStateService
    {
        public Task<IEnumerable<State>> GetAllStateServiceApi();
        Task<State> GetStateById(int stateId);
    }
}
