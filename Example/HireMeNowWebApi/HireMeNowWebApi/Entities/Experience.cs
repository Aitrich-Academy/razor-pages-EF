using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HireMeNowWebApi.Entities;

[Table("experience")]
public partial class Experience
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? JobTitle { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Company { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Duration { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Year { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Experiences")]
    public virtual User? User { get; set; }
}
