using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTime.Contract.DbModels;

public class Languages
{
    [Key]
    public int LanguageID { get; set; }
    public string Language { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<MovieLanguageMapping> MovieLanguageMappings { get; set; }
}
