using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.DbModels;

public class Tickets
{
    [Key]
    public int TicketID { get; set; }
    public String CustomerName { get; set; }
    public String CustomerContact { get; set; }
    public MovieShows ShowID { get; set; }
    public Byte TicketsCount { get; set; }
    public int FinalPrice { get; set; }
    public DateTime MovieStartTime { get; set; }
    public DateTime MovieEndTime { get; set; }
    public string? TransactionID { get; set; }
    public Users RegisteredUserID { get; set; }
    public bool IsActive { get; set; }
}
