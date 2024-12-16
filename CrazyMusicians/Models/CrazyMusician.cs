using System.ComponentModel.DataAnnotations;

namespace CrazyMusicians.Models;

public class CrazyMusician
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Profession is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Profession must be between 3 and 100 characters")]
    public string Profession { get; set; }
    
    [Required(ErrorMessage = "Fun Feature is required")]
    [StringLength(100, MinimumLength = 20, ErrorMessage = "Fun Feature must be between 20 and 100 characters")]
    public string FunFeature { get; set; }
}