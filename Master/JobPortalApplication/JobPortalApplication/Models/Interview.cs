using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortalApplication.Models;

public partial class Interview
{
    public Guid Id { get; set; }
    [ForeignKey(nameof(Company))]
	public Guid? CompanyId { get; set; }

  
	public Guid? JobId { get; set; }

    public Guid? JobseekerId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public string? Location { get; set; }

    public string? Status { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Job? Job { get; set; }

	public virtual Company? Company { get; set; }

  public virtual User? Jobseeker { get; set; }
} 
