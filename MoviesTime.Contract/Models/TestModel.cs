using System.ComponentModel.DataAnnotations;

namespace MoviesTime.Contract.Models
{
    public class TestModel
    {
        [Key]
        public int TestID { get; set; }

        public string Name { get; set; }
    }
}
