
using BeatBox.Data;
using BeatBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class SongsController : Controller
{
    private readonly ApplicationDbContext _context;

    public SongsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Songs
    public async Task<IActionResult> Index()
    {
        var songs = await _context.Songs
            .Include(s => s.Playlist)
            .ToListAsync();

        return View(songs);
    }

    // GET: Songs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var song = await _context.Songs
            .Include(s => s.Playlist)
            .FirstOrDefaultAsync(s => s.SongId == id);

        if (song == null)
            return NotFound();

        return View(song);
    }

    // GET: Songs/Create
    public IActionResult Create()
    {
        ViewData["PlaylistId"] = new SelectList(
            _context.Playlists, "PlaylistId", "Name");

        return View();
    }

    // POST: Songs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("SongId,Title,Artist,DurationSeconds,PlaylistId")] Song song)
    {
        if (ModelState.IsValid)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["PlaylistId"] = new SelectList(
            _context.Playlists, "PlaylistId", "Name",
            song.PlaylistId);

        return View(song);
    }

    // GET: Songs/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var song = await _context.Songs.FindAsync(id);

        if (song == null)
            return NotFound();

        ViewData["PlaylistId"] = new SelectList(
            _context.Playlists, "PlaylistId", "Name",
            song.PlaylistId);

        return View(song);
    }

    // POST: Songs/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("SongId,Title,Artist,DurationSeconds,PlaylistId")] Song song)
    {
        if (id != song.SongId)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(song);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(song.SongId))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["PlaylistId"] = new SelectList(
            _context.Playlists, "PlaylistId", "Name",
            song.PlaylistId);

        return View(song);
    }

    // GET: Songs/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var song = await _context.Songs
            .Include(s => s.Playlist)
            .FirstOrDefaultAsync(s => s.SongId == id);

        if (song == null)
            return NotFound();

        return View(song);
    }

    // POST: Songs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var song = await _context.Songs.FindAsync(id);

        if (song != null)
        {
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool SongExists(int id)
    {
        return _context.Songs.Any(s => s.SongId == id);
    }
}
