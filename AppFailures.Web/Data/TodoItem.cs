using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppFailures.Web.Data;

public class TodoItem
{
    public string PartitionKey { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public string? Description { get; set; }

    [DisplayName("Created Date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime CreatedDate { get; set; }
}
