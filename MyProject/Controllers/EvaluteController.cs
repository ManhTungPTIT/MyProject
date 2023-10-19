using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.AppService.IService;

namespace MyProject.Controllers
{
    [Authorize]
    
    public class EvaluteController : Controller
    {
        private readonly IEvaluteService _service;
        public EvaluteController(IEvaluteService _service)
        {
            this._service = _service;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAll();
            return View(list);
        }
    }
}
