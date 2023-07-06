using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalApplication.Models;

public partial class Application
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }
    [ForeignKey(nameof(Job))]
    public Guid? JobId { get; set; }

    public DateTime? AppliedDate { get; set; }

    public string? Status { get; set; }

    public virtual Job? Job { get; set; }

    public virtual User? User { get; set; }
}
