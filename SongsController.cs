using Microsoft.AspNetCore.Mvc;
using MoodBasedPlaylistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MoodBasedPlaylistApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly MoodBasedPlaylistDbContext _context;

        public SongsController(MoodBasedPlaylistDbContext context)
        {
            _context = context;
        }

        // GET api/songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET api/songs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSongById(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return song;
        }

        // POST api/songs
        [HttpPost]
        public async Task<ActionResult<Song>> CreateSong(Song song)
        {
            if (!song.IsValidMood())
            {
                return BadRequest("Invalid mood");
            }
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSongById), new { id = song.Id }, song);
        }

        // PUT api/songs/{id}
        [HttpPut("{id}")]
        public async Task song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }
            if (!song.IsValidMood())
            {
                return BadRequest("Invalid mood");
            }
            _context.Entry(song).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/songs/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET api/songs/mood/{mood}
        [HttpGet("mood/{mood}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsByMood(string mood)
        {
            return await _context.Songs.Where(s => s.Mood == mood).ToListAsync();
        }

        // GET api/songs/artist/{artist}
        [HttpGet("artist/{artist}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsByArtist(string artist)
        {
            return await _context.Songs.Where(s => s.Artist == artist).ToListAsync();
        }

        // GET api/songs/genre/{genre}
        [HttpGet("genre/{genre}")]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongsByGenre(string genre)
        {
            return await _context.S
