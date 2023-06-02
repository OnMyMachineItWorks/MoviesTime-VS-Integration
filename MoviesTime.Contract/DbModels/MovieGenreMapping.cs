using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.DbModels;

public class MovieGenreMapping
{
    public int? ID { get; set; }

    [ForeignKey("MovieID")]
    public Movies? Movies { get; set; }
    public int MovieID { get; set; }

    [ForeignKey("GenreID")]
    public Genres? Genre { get; set; }
    public int GenreID { get; set; }

    public bool IsActive { get; set; }


}
