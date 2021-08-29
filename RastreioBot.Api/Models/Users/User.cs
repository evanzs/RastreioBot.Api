using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RastreioBot.Api.Models.Users
{
    [Table("user")]
    public class User : BaseEntity
    {
        //[Required(ErrorMessage = "Name is required!")]
        [Column("name")]
        public string Name { get; set; }

        [Column("user_token")]
        public string UserToken { get; set; }
    }
}