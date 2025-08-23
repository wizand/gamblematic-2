using System.ComponentModel.DataAnnotations;

namespace GambleMaticApi.DatabaseEntities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; internal set; 
        public DateTimeOffset IDate { get; set; }
        public DateTimeOffset UDate { get; set; }


    }
}