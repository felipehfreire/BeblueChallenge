﻿using Beblue.Domain.Core.Events;

namespace Beblue.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
            Version = 1;
        }
    }
}
