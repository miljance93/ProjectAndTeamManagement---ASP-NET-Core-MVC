using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProjectStatus
    {
        public int ProjectStatusId { get; set; }
        public string? ProjectStatusName { get; set; }

    }
}
