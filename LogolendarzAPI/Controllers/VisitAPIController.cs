using AutoMapper;
using Azure;
using LogolendarzAPI.Data;
using LogolendarzAPI.Models;
using LogolendarzAPI.Models.Dto;
//using Logolendarz.Services.VisitAPI.Data;
//using Logolendarz.Services.VisitAPI.Models;
//using Logolendarz.Services.VisitAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LogolendarzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public VisitAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Visit> objList = _db.Visits.ToList();
                _response.Result = _mapper.Map<IEnumerable<VisitDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Messaege = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Visit obj = _db.Visits.First(x => x.VisitId == id);
                _response.Result = _mapper.Map<VisitDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Messaege = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] VisitDto visitDto)
        {
            try
            {
                Visit obj = _mapper.Map<Visit>(visitDto);
                _db.Visits.Add(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<VisitDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Messaege = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] VisitDto visitDto)
        {
            try
            {
                Visit obj = _mapper.Map<Visit>(visitDto);
                _db.Visits.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<VisitDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Messaege = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Visit obj = _db.Visits.First(u => u.VisitId == id);
                _db.Visits.Remove(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.Messaege = ex.Message;
            }
            return _response;
        }
    }
}

