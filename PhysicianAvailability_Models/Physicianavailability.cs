using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Models
{
    public class Physicianavailability
    {
        public string? physician_email
        {
            get; set;
        }
        public string? availablefrom
        {
            get; set;
        }
        public string? availableTo
        {
            get; set;
        }
    }
}