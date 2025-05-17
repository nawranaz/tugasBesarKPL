using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TubesKPL_KitaBelajar_API;

[ApiController]
[Route("api/[controller]")]
public class ForumController : ControllerBase
{
    private static List<Komentar> _komentarList = new();

    [HttpGet]
    public ActionResult<IEnumerable<Komentar>> GetKomentar()
    {
        return Ok(_komentarList);
    }

    [HttpPost]
    public IActionResult PostKomentar([FromBody] Komentar komentar)
    {
        komentar.Tanggal = DateTime.Now;
        _komentarList.Add(komentar);
        return CreatedAtAction(nameof(GetKomentar), new { username = komentar.Username }, komentar);
    }
}
