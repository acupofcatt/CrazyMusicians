using CrazyMusicians.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrazyMusicianController : ControllerBase
    {
        //Create list for project database
        private static List<CrazyMusician> _musicians = new()
        {
            new CrazyMusician
            {
                Id = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar",
                FunFeature = "Her zaman yanlış nota çalar, ama çok eğlenceli."
            },
            new CrazyMusician
            {
                Id = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı",
                FunFeature = "Şarkıları yanlış anlaşılır ama çok popüler."
            },
            new CrazyMusician
            {
                Id = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist",
                FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli."
            },
            new CrazyMusician
            {
                Id = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi",
                FunFeature = "Nota üretirken sürekli sürprizler hazırlar."
            },
            new CrazyMusician
            {
                Id = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı",
                FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir."
            },
            new CrazyMusician
            {
                Id = 6, Name = "Elif Armoni", Profession = "Armoni Ustası",
                FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır."
            },
            new CrazyMusician
            {
                Id = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı",
                FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir."
            },
            new CrazyMusician
            {
                Id = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı",
                FunFeature = "Rezonans konusunda uzman, ama bazen çok gurultu çıkarır."
            },
            new CrazyMusician
            {
                Id = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı",
                FunFeature = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç."
            },
            new CrazyMusician
            {
                Id = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı",
                FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır."
            }
        };
        
        //Get list all musicians
        [HttpGet("list")]
        public IEnumerable<CrazyMusician> GetAll()
        {
            return _musicians;
        }
        
        //Get musician data by Id
        [HttpGet("{id:int:min(1)}")]
        public ActionResult<CrazyMusician> GetById(int id)
        {
            var musician = _musicians.FirstOrDefault(t => t.Id == id);

            if (musician is null)
            {
                return NotFound($"Musician {id} not found");
            }
            
            return Ok(musician);
        }
        
        //Page all musicians
        [HttpGet("list/{index:int:min(1)}/{count:int:min(1)}")]
        public IEnumerable<CrazyMusician> GetAll(int index, int count)
        {
            return _musicians.Skip(index * count).Take(count);
        }
        
        //create a musician
        [HttpPost("create-musician")]
        public ActionResult<CrazyMusician> Create([FromBody] CrazyMusician musician)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var id = _musicians.Max(x => x.Id) + 1;
            musician.Id = id;
            
            _musicians.Add(musician);
            
            return CreatedAtAction(nameof(GetById), new { id = musician.Id }, musician);
        }
        
        //Update musician data
        [HttpPut("update-musician")]
        public ActionResult<CrazyMusician> Update([FromBody] CrazyMusician musician)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var existingMusician = _musicians.FirstOrDefault(x => x.Id == musician.Id);
            if (existingMusician is null)
            {
                return NotFound($"Musician {musician.Id} not found");
            }
            
            existingMusician.Name = musician.Name;
            existingMusician.Profession = musician.Profession;
            existingMusician.FunFeature = musician.FunFeature;
            
            _musicians.Add(musician);
            
            return CreatedAtAction(nameof(GetById), new { id = musician.Id }, musician);
        }
        
        //Update musician profession data
        [HttpPatch("update/{id:int:min(1)}/{profession}")]
        public IActionResult UpdateTMusician(int id, string profession)
        {
            var musician = _musicians.FirstOrDefault(t => t.Id == id);
            if (musician is null)
            {
                return NotFound("Musician not found");
            }
            
            musician.Profession = profession;
            
            return NoContent();
        }

        //Delete musician
        [HttpDelete("delete/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            var musician = _musicians.FirstOrDefault(t => t.Id == id);
            if (musician is null)
            {
                return NotFound("Musician not found");
            }
            
            _musicians.Remove(musician);
            
            return NoContent();
        }
        
        
        
        
        
        
        
    }
}