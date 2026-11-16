
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeatBox.Models;
using BeatBox.Data;

public class PlaylistsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PlaylistsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Playlists
    public async Task<IActionResult> Index()
    {
        return View(await _context.Playlists.ToListAsync());
    }

    // GET: Playlists/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var playlist = await _context.Playlists
            .FirstOrDefaultAsync(p => p.PlaylistId == id);

        if (playlist == null)
            return NotFound();

        return View(playlist);
    }

    // GET: Playlists/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Playlists/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Name,Genre,CreatedDate")] Playlist playlist)
    {
        if (ModelState.IsValid)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(playlist);
    }

    // GET: Playlists/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var playlist = await _context.Playlists.FindAsync(id);

        if (playlist == null)
            return NotFound();

        return View(playlist);
    }

    // POST: Playlists/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("PlaylistId,Name,Genre,CreatedDate")] Playlist playlist)
    {
        if (id != playlist.PlaylistId)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(playlist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(playlist.PlaylistId))
                    return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(playlist);
    }

    // GET: Playlists/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var playlist = await _context.Playlists
            .FirstOrDefaultAsync(p => p.PlaylistId == id);

        if (playlist == null)
            return NotFound();

        return View(playlist);
    }

    // POST: Playlists/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var playlist = await _context.Playlists.FindAsync(id);

        if (playlist != null)
        {
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool PlaylistExists(int id)
    {
        return _context.Playlists.Any(p => p.PlaylistId == id);
    }
}
