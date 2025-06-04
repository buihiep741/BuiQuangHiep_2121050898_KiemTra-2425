using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("ca2")]
    public class ca2
    {
        [Key]
        public string ten { get; set; }
        public string diachi { get; set; }
        public int tuoi { get; set; }
    }
}