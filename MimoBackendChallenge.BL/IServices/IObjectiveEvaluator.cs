using MimoBackendChallenge.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MimoBackendChallenge.BL.IServices
{
    public interface IObjectiveEvaluator
    {
        Task<List<ObjectiveProgressModel>> GetAllObjectivesProgressByUser(int userId);
    }
}
