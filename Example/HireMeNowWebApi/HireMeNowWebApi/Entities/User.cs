using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HireMeNowWebApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace HireMeNowWebApi.Entities;

[Table("users")]
[Index(nameof(Email), IsUnique = true)]
public partial class User
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Location { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Phone]
    public string? Phone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Password { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public Roles? Role { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? About { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Designation { get; set; }

    public Guid? CompanyId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Image { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [ForeignKey("CompanyId")]
    [InverseProperty("Users")]
    public virtual Company? Company { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    [InverseProperty("User")]
    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    [InverseProperty("User")]
    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

    [InverseProperty("User")]
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
