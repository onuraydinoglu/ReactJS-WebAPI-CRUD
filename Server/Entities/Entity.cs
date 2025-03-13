using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public abstract class Entity<TId>
    {
        [Key]
        public TId? Id { get; set; }
    }
}