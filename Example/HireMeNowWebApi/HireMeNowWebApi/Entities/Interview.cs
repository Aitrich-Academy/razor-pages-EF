using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HireMeNowWebApi.Entities;

[Table("interviews")]
public partial class Interview
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid? JobId { get; set; }

    public Guid? UserId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Location { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Interviews")]
    public virtual User? User { get; set; }
}
