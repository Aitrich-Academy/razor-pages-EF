using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HireMeNowWebApi.Entities;

[Table("skills")]
public partial class Skill
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    [Column("Skill")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Skill1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Skills")]
    public virtual User? User { get; set; }
}
