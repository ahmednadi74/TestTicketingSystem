using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTicketingSystem.Module.BusinessObjects {

    public enum TicketStatus {
        New = 0,
        InProgress = 1,
        Resolved = 99,
    }

    public enum TicketPriority {
        Low,
        Medium,
        High,
    }
}
