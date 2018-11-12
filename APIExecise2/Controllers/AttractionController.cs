using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIExecise2.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIExecise2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttractionController : Controller
    {
        private CitiesDatabase _db;
        public AttractionController(CitiesDatabase db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public List<AttractionDTO> GetAll()
        {
            List<Attraction> attractions = _db.Attractions.ToList();
            List<AttractionDTO> DTOList = new List<AttractionDTO>();
            foreach (var attraction in attractions)
            {
                AttractionDTO dto = new AttractionDTO
                {
                    Name = attraction.Name,
                    Description = attraction.Description,
                    CityName = _db.Cities.First(x => x.Id == attraction.CityId).Name
                };
                DTOList.Add(dto);
            }

            return DTOList;
        }

        [HttpGet]
        [Route("{id:int}")]
        public AttractionDTO Get(int id)
        {
            Attraction attraction = _db.Attractions.First(x => x.Id == id);
            AttractionDTO DTO = new AttractionDTO
            {
                Name = attraction.Name,
                Description = attraction.Description,
                CityName = _db.Cities.First(x => x.Id == attraction.CityId).Name
            };
            return DTO;
        }

        [HttpGet]
        [Route("city/{id:int}")]
        public List<AttractionDTO> GetByCityId(int id)
        {
            List<Attraction> attractions = _db.Attractions.Where(x => x.CityId == id).ToList();
            List<AttractionDTO> DTOList = new List<AttractionDTO>();

            foreach (Attraction attraction in attractions)
            {
                AttractionDTO dto = new AttractionDTO
                {
                    Name = attraction.Name,
                    Description = attraction.Description,
                    CityName = _db.Cities.First(x => x.Id == attraction.CityId).Name
                };
                DTOList.Add(dto);
            }

            return DTOList;
        }
    }
}
