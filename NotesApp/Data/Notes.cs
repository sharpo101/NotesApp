using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.Data
{
    public class Note
    {
        public int? Id { get; set; }
        
        public string? Contents { get; set; }

    }
}

