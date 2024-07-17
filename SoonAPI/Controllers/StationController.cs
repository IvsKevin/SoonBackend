﻿using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(StationListResponse.Get());
        }
    }
}
