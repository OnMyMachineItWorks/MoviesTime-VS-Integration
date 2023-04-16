using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.DbModels;

public class MovieLanguageMapping
{
    public int ID { get; set; }

    [ForeignKey("LanguageID")]
    public Languages Languages { get; set; }
    public int LanguageID { get; set; }

    [ForeignKey("MovieID")]
    public Movies Movies { get; set; }
    public int MovieID { get; set; }

    public bool IsActive { get; set; }
}
