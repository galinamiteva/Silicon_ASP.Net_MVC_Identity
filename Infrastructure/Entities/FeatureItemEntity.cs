

namespace Infrastructure.Entities;

public class FeatureItemEntity
{
    public int Id { get; set; }   
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;

    public int FeatureId { get; set; }
    public FeatureEntity Feature { get; set; } = null!;
}
