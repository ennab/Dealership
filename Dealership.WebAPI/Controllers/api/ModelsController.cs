using AutoMapper;
using Dealership.BLL;
using Dealership.DomainEntities;
using Dealership.WebAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Dealership.WebAPI.Controllers.api
{
    public class ModelsController : ApiController
    {
        IUnitOfWork _unitOfWork;
        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<ModelDto> GetAllModels()
        {
            var models = _unitOfWork.Models.GetAllWithMakers().ToList().Select(Mapper.Map<Model, ModelDto>);
            return models;
        }

        [HttpGet]
        public IHttpActionResult GetModel(int Id)
        {
            var model = _unitOfWork.Models.SingleOrDefault(m => m.Id == Id);
            if (model == null) return NotFound();
            return Ok(Mapper.Map<Model, ModelDto>(model));
        }

        [HttpPost]
        public IHttpActionResult CreateModel(ModelDto modelDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var model = _unitOfWork.Models.Add(Mapper.Map<ModelDto, Model>(modelDto));
            _unitOfWork.Complete();
            return Created(new Uri(Request.RequestUri + "/" + model.Id), Mapper.Map<Model, ModelDto>(model));
        }

        [HttpPut]
        public IHttpActionResult UpdateModel(int Id, ModelDto modelDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var model = _unitOfWork.Models.SingleOrDefault(m => m.Id == Id);
            if (model == null) return NotFound();
            Mapper.Map<ModelDto, Model>(modelDto, model);
            _unitOfWork.Complete();

            return Ok(modelDto);
        }

        [HttpDelete]
        public IHttpActionResult DeleteModle(int Id)
        {
            var model = _unitOfWork.Models.SingleOrDefault(m => m.Id == Id);
            if (model == null) NotFound();
            _unitOfWork.Models.Remove(model);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
