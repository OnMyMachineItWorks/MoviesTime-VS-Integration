using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.DbModels;

public class MovieShows
{
    [Key]
    public int ShowID { get; set; }
    public TheaterScreen ScreenID { get; set; }
    public Movies MovieID { get; set; }
    public Languages LanguageID { get; set; }
    public int TicketPrice { get; set; }
    public DateTime ShowStartTime { get; set; }
    public DateTime ShowEndTime { get; set; }
    public bool IsActive { get; set; }
}
