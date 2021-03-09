using Microsoft.AspNetCore.Mvc;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MimoBackendChallenge.API.Controllers
{
    [Route("api")]
    public class AchievementsController : Controller
    {
        private readonly IObjectiveEvaluator objectiveEvaluator;
        public AchievementsController(IObjectiveEvaluator objectiveEvaluator)
        {
            this.objectiveEvaluator = objectiveEvaluator;
        }
        /// <summary>
        /// Returns the progresses of all the achievements in the system for one user
        /// </summary>
        /// <param name="userId">Identifier of the user</param>
        /// <returns></returns>
        [HttpGet]
        [Route("achievements/users/{userId}")]
        public async Task<ActionResult<List<ObjectiveProgressModel>>> GetByUserId([FromRoute] int userId)
        {
            return await objectiveEvaluator.GetAllObjectivesProgressByUser(userId);
        }
    }
}
