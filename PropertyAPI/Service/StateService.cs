using PropertyAPI.IRepository;
using PropertyAPI.IService;
using PropertyEntity;

namespace PropertyAPI.Service
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository _stateRepository)
        {
            this._stateRepository = _stateRepository;
        }
        public async Task DeleteState(int stateId)
        {
            await _stateRepository.DeleteState(stateId);
        }

        public async Task<IEnumerable<State>> GetAllState()
        {
            var StateList=await _stateRepository.GetAllState(); 
            return StateList;
        }

        public async Task<State> GetStateById(int stateId)
        {
            var stateid=await _stateRepository.GetStateById(stateId);
            return stateid;
        }

        public async Task InsertState(State state)
        {
            await _stateRepository.InsertState(state);
        }

        public async Task UpdateState(State state)
        {
            await _stateRepository.UpdateState(state);
        }
    }
}
