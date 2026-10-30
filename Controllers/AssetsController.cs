using Microsoft.AspNetCore.Mvc;
using AssetManagement.WebApi.Models;
using AssetManagement.WebApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Tuodaan validointityökalut

namespace AssetManagement.WebApi.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class AssetsController : ControllerBase
    {
        private readonly IAssetRepository _repository;

        public AssetsController(IAssetRepository repository)
        {
            _repository = repository;
        }

        // GET: api/assets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            var assets = await _repository.GetAllAsync();
            return Ok(assets); 
        }

        // GET: api/assets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(string id)
        {
            // Tietoturva/Fiksuus: Estetään tyhjät tai liian pitkät ID-haut suoraan
            if (string.IsNullOrWhiteSpace(id) || id.Length > 50)
            {
                // Palauttaa HTTP 400 virheen
                return BadRequest(new { message = "Virheellinen laite-ID." });
            }

            var asset = await _repository.GetByIdAsync(id);

            if (asset == null)
            {
                return NotFound(new { message = $"Laitetta {id} ei löytynyt." }); 
            }

            return Ok(asset);
        }

        // POST: api/assets/{id}/report-damage
        [HttpPost("{id}/report-damage")]
        public async Task<IActionResult> ReportDamage(string id, [FromBody] DamageReportRequest request)
        {
            // Fiksuus: .NET tarkistaa automaattisesti, täyttääkö pyyntö DamageReportRequestin säännöt
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = await _repository.GetByIdAsync(id);

            if (asset == null)
            {
                return NotFound(new { message = "Laitetta ei löytynyt." });
            }

            asset.Status = "Huollossa";
            asset.LastChecked = System.DateTime.UtcNow;

            var success = await _repository.UpdateAsync(asset);

            if (!success)
            {
                return StatusCode(500, "Tietokannan päivitys epäonnistui.");
            }

            System.Console.WriteLine($"[SECURITY_LOG] Laite {asset.Name} siirretty huoltoon. Ilmoittaja: {request.ReportedBy}");
            return Ok(new { message = $"Laitteen {asset.Name} tila päivitetty.", currentAsset = asset });
        }
    }

    // DTO (Data Transfer Object) validointisäännöillä
    public class DamageReportRequest
    {
        [Required(ErrorMessage = "Ilmoittajan nimi on pakollinen tieto.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Nimen pitää olla 2-100 merkkiä pitkä.")]
        public string ReportedBy { get; set; }
    }
}
