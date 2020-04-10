using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ColourAPI.Models;
using System.Collections.Generic;

namespace ColourAPI.Controllers
{

    [Route("api/colours")]
    public class ColoursController : ControllerBase
    {

        private readonly ColourContext _context;

        ILogger<ColoursController> _logger;

        public ColoursController(ILogger<ColoursController> logger, ColourContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Colour>> Get()
        {
            try
            {
                return _context.ColourItems;
            }
            catch (Exception)
            {
                _logger.LogError("Failed to Get Colours");
                return BadRequest();
            }
        }
    }
}