﻿using Beblue.Domain.Core.Events;
using FluentValidation.Results;
using System;

namespace Beblue.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
