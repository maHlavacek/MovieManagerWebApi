using MovieManager.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Core.Entities
{
    public class EntityObject : IEntityObject
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] Timestamp
        {
            get;
            set;
        }
    }
}
