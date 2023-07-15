using System;
using System.Collections.Generic;

namespace JobPortalApplication.Models;

public partial class Application
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? JobId { get; set; }
	public Guid? CompanyId { get; set; }
	public DateTime? AppliedDate { get; set; }

    public string? Status { get; set; }

    public virtual Job? Job { get; set; }

    public virtual User? User { get; set; }
	 public virtual Company? Company { get; set; }
}
