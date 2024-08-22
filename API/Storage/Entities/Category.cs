namespace Api.Storage.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
