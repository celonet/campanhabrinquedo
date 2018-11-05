﻿using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignRepository _repository;

        public CampaignController(ICampaignRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var campaigns = await _repository.List();
            return Ok(campaigns);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Campaign entity)
        {
            await _repository.CreateAsync(entity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Campaign entity)
        {
            await _repository.UpdateAsync(entity);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}
