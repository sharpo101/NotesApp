using Notes.Data;
using Microsoft.EntityFrameworkCore;

namespace NotesApp.Components.Pages
{
    public partial class Home
    {
        public bool ShowCreate { get; set; }
        public bool EditRecord { get; set; }
        public Note? NoteToUpdate { get; set; }

        private NotesDataContext? _context;

        public Note? NewNote { get; set; }

        public void ShowCreateForm()
        {
            NewNote = new Note();
            ShowCreate = true;
        }

        public async Task CreateNewNote()
        {
            _context ??= await NotesDataContextFactory.CreateDbContextAsync();

            if (NewNote is not null)
            {
                _context?.NotesDb.Add(NewNote);
                _context?.SaveChangesAsync();
            }
            ShowCreate = false;
        }

        public List<Note>? Notes { get; set; }

        public async Task ShowNotes()
        {
            _context ??= await NotesDataContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                Notes = await _context.NotesDb.ToListAsync();
            }

            if (_context is not null) await _context.DisposeAsync();
        }
    }
}
