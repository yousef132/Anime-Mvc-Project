using DAL.Entities;
using OtakuOasis.Entities;
public class Category: BaseEntity
{

    public ICollection<AnimeCategory> AnimeCategories { get; set; }
}
