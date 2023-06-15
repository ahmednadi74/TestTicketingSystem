﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTicketingSystem.Module.BusinessObjects {
    
        public enum TicketStatus {
            Open,
            InProgress,
            Resolved,
            Closed
        }

        public enum TicketPriority {
            Low,
            Medium,
            High,
        }
    }