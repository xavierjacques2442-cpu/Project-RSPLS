using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_RSPLS.Service;
using Project_RSPLS.Models;
using System.Text.RegularExpressions;

namespace Project_RSPLS.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerOne : ControllerBase
    {
        private readonly ServiceOne _service;

        public ControllerOne(ServiceOne service)
        {
            _service = service;
        }
        [HttpGet("cpu")]
       
        public IActionResult GetCpuMove()
        {
            var cpuMove = _service.GetCpuMove();
            return Ok(new { Move = cpuMove });
        }

        [HttpPost("play")]
        public IActionResult PlayCpuRound([FromBody] PlayerMoveRequest request)
        {
         if(request == null || string.IsNullOrWhiteSpace(request.Move))
         {
            return BadRequest("Invalid move.");
         }

            var result = _service.PlayCpuRound(request.Move);
            return Ok(result);
        }

        [HttpPost("play-match")]
        public IActionResult PlayMatchRound([FromBody] MatchPlayRequest request)
        {
            var result = _service.playMatchRound(request.Match, request.PlayerMove);
            return Ok(result);
        }
    }
}