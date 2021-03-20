using DraughtsGameAPIModels;
using DraughtsGameAPIService.Instance;
using DraughtsGameAPIService.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DraughtsGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomatedPlayerController : ControllerBase
    {
        // POST api/<AutomatedPlayerController>
        [HttpPost]
        public ActionResult Post(GetNextMove getNextMove)
        {
            int version = getNextMove.Version;
            IAutomatedPlayerService service;

            switch (version)
            {
                case 1:
                    service = new AutomatedPlayerServiceV1();
                    break;
                case 2:
                    service = new AutomatedPlayerServiceV2();
                    break;
                case 3:
                    service = new AutomatedPlayerServiceV3();
                    break;
                default:
                    service = null;
                    break;
            }

            if (service == null)
            {
                return BadRequest(
                    new Response
                    {
                        Successful = false
                    }
                );
            }

            NextMove nextmove = service.GetNextMoveForAutomatedPlayer(getNextMove);

            return Ok(
                new Response
                {
                    Successful = true,
                    NextMove = nextmove 
                }
            );
        }
    }
}
