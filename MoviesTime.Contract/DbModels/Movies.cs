using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.DbModels;

public class Movies
{
    [Key]
    public int MovieID { get; set; }
    public string MovieTitle { get; set; }

    
    [ForeignKey("TheaterID")]
    public Theaters Theaters { get; set; }
    public int? TheaterID { get; set; }

    public TimeSpan? MovieLength { get; set; }
    public bool IsActive { get; set; }

    public ICollection<MovieGenreMapping> MovieGenreMappings { get; set; }
    public ICollection<MovieLanguageMapping> MovieLanguageMappings { get; set; }

}
