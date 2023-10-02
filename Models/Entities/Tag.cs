using System;
using System.Collections.Generic;

namespace WalletWise.Models.Entities;

public partial class Tag
{
    public int TagId { get; set; }

    public string TagUserId { get; set; }

    public required string TagName { get; set; }

    public string? TagDescription { get; set; }

    public bool? TagIsPublic { get; set; }

    public virtual Expense TagNavigation { get; set; }
}
