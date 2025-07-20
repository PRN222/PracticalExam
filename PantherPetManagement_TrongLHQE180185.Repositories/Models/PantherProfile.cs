using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PantherPetManagement_TrongLHQE180185.Repositories.Models;

public partial class PantherProfile
{
    public int PantherProfileId { get; set; }

    [Required]
    public int PantherTypeId { get; set; }

    [Required]
    [MinLength(4)]
    [RegularExpression(@"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$", ErrorMessage = "Each word must start with a capital letter, no special characters.")] public string PantherName { get; set; } = null!;

    [Required]
    [Range(90, int.MaxValue, ErrorMessage = "Weight must be greater than 90.")]
    public double Weight { get; set; }

    [Required]
    public string Characteristics { get; set; } = null!;

    [Required]
    public string Warning { get; set; } = null!;

    [Required]
    public DateTime ModifiedDate { get; set; }

    public virtual PantherType PantherType { get; set; } = null!;
}
