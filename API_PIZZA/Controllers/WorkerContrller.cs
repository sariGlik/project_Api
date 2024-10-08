﻿
using AllModels;
using AllModels.Interfaces;
using AllService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_PIZZA.Controllers;
    [ApiController]
    [Route("Api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class WorkerContrller:ControllerBase
    {
        private IWorker _workerService;
        public WorkerContrller(IWorker workerService)
        {
            _workerService = workerService;
            _workerService.createDate = DateTime.Now;   
        }
        [HttpGet]
        public List  <Worker> Get()
        {
            return _workerService.GetWorkers();
        }
    }  
        //[HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     _workerService.DeleteWorker(id);
        //     return Ok();
        // }



