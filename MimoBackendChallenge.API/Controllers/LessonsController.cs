using Microsoft.AspNetCore.Mvc;
using MimoBackendChallenge.BL.IServices;
using MimoBackendChallenge.BL.Models;
using System.Threading.Tasks;

namespace MimoBackendChallenge.API.Controllers
{
    [Route("api")]
    public class LessonsController : Controller
    {
        private ILessonsService lessonsService { get; set; }
        public LessonsController(ILessonsService lessonsService)
        {
            this.lessonsService = lessonsService;
        }
        /// <summary>
        /// Returns one lesson by it's id
        /// </summary>
        /// <param name="id">Identifier of the Lesson</param>
        /// <returns></returns>
        [HttpGet]
        [Route("lessons/{id}")]
        public async Task<ActionResult<LessonModel>> Get([FromRoute] int id)
        {
            return await lessonsService.GetByIdAsync(id);
        }
    }
}
