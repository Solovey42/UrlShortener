using System.ComponentModel.DataAnnotations;

namespace API.Domain.Models
{
    public class Link
    {
        public int Id { get; set; }
        [RegularExpression(@"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)?[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", ErrorMessage = "Укажите верный url!")]
        [Required(ErrorMessage = "Укажите адрес!")]
        public string LongAddress { get; set; }
        public string Token { get; set; }
    }
}
