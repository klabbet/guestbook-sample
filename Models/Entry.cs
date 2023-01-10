using System.ComponentModel.DataAnnotations;

namespace guestbook_sample.Models;

public class Entry
{
    public int Id { get; set; }
    public string? Subject { get; set; }
    [DataType(DataType.Date)]
    public DateTime Created { get; set; }
    public string? Content { get; set; }
}