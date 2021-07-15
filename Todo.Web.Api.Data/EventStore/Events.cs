using System;
using Todo.Web.Api.Models.Enums;
using Todo.Web.Api.Models.Models;

namespace Todo.Web.Api.Data.EventStore
{
    public class Events
    {
        public interface IEvent { };

        public record TodoCreated(string Code, string Title, TodoState State, DateTime DateTime) : IEvent;
        public record TodoUpdated(long TodoId, string Title, TodoState State, DateTime DateTime) : IEvent;
        public record TodoRemoved(long TodoId, DateTime DateTime) : IEvent;
    }
}
