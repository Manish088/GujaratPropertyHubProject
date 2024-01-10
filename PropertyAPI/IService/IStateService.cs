using PropertyEntity;

namespace PropertyAPI.IService
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetAllState();
        Task InsertState(State state);
        Task DeleteState(int stateId);
        Task<State> GetStateById(int stateId);
        Task UpdateState(State state);
    }
}
