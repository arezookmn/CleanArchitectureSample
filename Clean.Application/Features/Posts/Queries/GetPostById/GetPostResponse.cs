namespace Clean.Application.Features.Posts.Queries.GetPostById;
public record GetPostResponse
{
    public string text { get; set; }
    public string title { get; set; }
    public Guid UserId { get; set; }
}
