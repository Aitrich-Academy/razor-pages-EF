using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HireMeNowWebApi.Entities;

[Table("applications")]
public partial class Application
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? JobId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("JobId")]
    [InverseProperty("Applications")]
    public virtual Job? Job { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Applications")]
    public virtual User? User { get; set; }
}
