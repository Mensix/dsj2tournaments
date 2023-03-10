using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dsj2TournamentsServer.Models.Tournament;

public class Tournament
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required]
    public User CreatedBy { get; set; }

    public TournamentSettings Settings { get; set; } = new() { LiveBoard = false };

    [Required]
    public Hill Hill { get; set; }

    public string Code { get; set; } = Guid.NewGuid().ToString()[..6];

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime? StartDate { get; set; } = DateTime.UtcNow.AddMinutes(1);

    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddHours(1);

    [NotMapped]
    public bool IsFinished => DateTime.UtcNow > EndDate.ToUniversalTime();

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Jump> Jumps { get; set; }
}