using Microsoft.EntityFrameworkCore;
using PropertyAPI.IRepository;
using PropertyEntity;
using PropertyEntity.Data;

namespace PropertyAPI.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StateRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }
        public async Task DeleteState(int stateId)
        {
            var stateDeleteId=await _applicationDbContext.state.FindAsync(stateId);
            if(stateDeleteId != null)
            {
                _applicationDbContext.state.Remove(stateDeleteId);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<State>> GetAllState()
        {
            var stateList=await _applicationDbContext.state.ToListAsync();
            return stateList;
        }

        public async Task<State> GetStateById(int stateId)
        {
            var stateid = await _applicationDbContext.state.FindAsync(stateId);
            return stateid;
        }

        public async Task InsertState(State state)
        {
            _applicationDbContext.state.Add(state);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateState(State state)
        {
            _applicationDbContext.state.Entry(state).State=EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
