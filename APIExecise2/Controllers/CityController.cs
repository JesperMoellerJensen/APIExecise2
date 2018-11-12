using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIExecise2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIExecise2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CitiesDatabase _db;

        public CityController(CitiesDatabase db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public List<CityDTO> GetAll()
        {
            List<CityDTO> DTOList = new List<CityDTO>();

            var cities = _db.Cities;
            foreach (City city in cities)
            {
                CityDTO dto = new CityDTO
                {
                    Name = city.Name,
                    Description = city.Description,
                    Attractions = _db.Attractions.Where(x => x.CityId == city.Id).ToList()
                };
                DTOList.Add(dto);
            }

            return DTOList;
        }

        [HttpGet]
        [Route("no")]
        public List<City> GetAllNoAttractions()
        {
            List<City> cities = _db.Cities.ToList();

            return cities;
        }

        [HttpGet]
        [Route("{id:int}")]
        public CityDTO Get(int id)
        {
            City city = _db.Cities.First(x => x.Id == id);
            CityDTO dto = new CityDTO
            {
                Name = city.Name,
                Description = city.Description,
                Attractions = _db.Attractions.Where(x => x.CityId == city.Id).ToList()
            };
            return dto;
        }

        [HttpGet]
        [Route("{id:int}/no")]
        public City GetNoAttractions(int id)
        {
            return _db.Cities.First(x => x.Id == id);
        }

        [HttpPost]
        [Route("")]
        public void CreateCity([FromBody]City value)
        {
            _db.Cities.Add(value);
            _db.SaveChanges();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public void DeleteCity(int id)
        {
            City city = _db.Cities.First(x => x.Id == id);
            _db.Cities.Remove(city);
            _db.SaveChanges();
        }

        [HttpPatch]
        [Route("{id:int}")]
        public void PatchCity([FromBody]City value, int id)
        {
            City city = _db.Cities.First(x => x.Id == id);
        }
    }
}