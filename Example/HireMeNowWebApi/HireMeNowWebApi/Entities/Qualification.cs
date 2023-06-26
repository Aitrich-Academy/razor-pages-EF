using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HireMeNowWebApi.Entities;

[Table("qualifications")]
public partial class Qualification
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Mark { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? YearOfPassout { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? University { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Qualifications")]
    public virtual User? User { get; set; }
}
