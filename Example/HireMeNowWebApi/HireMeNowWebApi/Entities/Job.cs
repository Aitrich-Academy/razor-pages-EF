using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HireMeNowWebApi.Entities;

[Table("job")]
public partial class Job
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Location { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Experience { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TypeOfWorkPlace { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Salary { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Responsibilities { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? JobType { get; set; }

    public int? VacanciesCount { get; set; }

    public int? AppliedCount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    public Guid? CompanyId { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [ForeignKey("CompanyId")]
    [InverseProperty("Jobs")]
    public virtual Company? Company { get; set; }
}
