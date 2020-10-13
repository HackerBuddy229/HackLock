using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HackLock.Server.Data.Models
{
    public class EntryLogItem
    {
        [Key]
        public string Id { get; set; }

        public string Timestamp { get; set; } = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }

        public string Action { get; set; }
    }
}
