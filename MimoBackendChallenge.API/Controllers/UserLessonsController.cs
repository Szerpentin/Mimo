using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using System.Threading.Tasks;

namespace MimoBackendChallenge.API.Controllers
{
    public class UserLessonsController : Controller
    {
        private readonly IUserLessonsService userLessonsService;
        private readonly IMapper mapper;
        public UserLessonsController(IUserLessonsService userLessonsService, IMapper mapper)
        {
            this.userLessonsService = userLessonsService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Inserts one lesson completion for a user
        /// </summary>
        /// <param name="userLessonModel">Complex model to insert</param>
        /// <returns></returns>
        [HttpPut]
        [Route("userlessons/")]
        public async Task<ActionResult<UserLessonsModel>> Put([FromBody] UserLessonsCreateModel userLessonModel)
        {
            // ToDo validate input!
            var mappedModel = mapper.Map<UserLessonsModel>(userLessonModel);
            return await userLessonsService.CreateAsync(mappedModel);
        }
    }
}
