using PropertyEntity;

namespace PropertyAPI.IRepository
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllState();
        Task InsertState(State state);
        Task DeleteState(int stateId);
        Task<State> GetStateById(int stateId);
        Task UpdateState(State state);
    }
}
