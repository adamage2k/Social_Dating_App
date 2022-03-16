using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialDatingApp.Core.Entities
{
    public class Zwierze
    {
        [Key]
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Rasa { get; set; }
    }
}
