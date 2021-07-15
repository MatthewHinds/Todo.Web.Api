using System;
using System.Collections.Generic;
using Todo.Web.Api.Models.Enums;
using Todo.Web.Api.Models.Models;
using static Todo.Web.Api.Data.EventStore.Events;

namespace Todo.Web.Api.Data.EventStore
{
    /**
     * 
     * https://codeopinion.com/event-sourcing-example-explained-in-plain-english/
     * 
     */
    public class CurrentState : TodoItem { }

    public class TodoItemStore
    {
        public long TodoId { get; }

        private readonly CurrentState _currentState = new();
        private readonly IList<IEvent> _allEvents = new List<IEvent>();
        private readonly IList<IEvent> _uncommittedEvents = new List<IEvent>();

        public TodoItemStore(long todoId)
        {
            TodoId = todoId;
        }

        public void CreateTodo(string code, string title, TodoState state)
        {
            AddEvent(new TodoCreated(code, title, state, DateTime.UtcNow));
        }

        public void UpdateTodo(string title, TodoState state)
        {
            AddEvent(new TodoUpdated(TodoId, title, state, DateTime.UtcNow));
        }

        public void ApplyEvent(IEvent evnt)
        {
            switch (evnt)
            {
                case TodoCreated todoCreated:
                    Apply(todoCreated);
                    break;
                case TodoUpdated todoUpdated:
                    Apply(todoUpdated);
                    break;
                default:
                    throw new InvalidOperationException("Event not supported");
            }

            _allEvents.Add(evnt);
        }

        public void AddEvent(IEvent evnt)
        {
            ApplyEvent(evnt);
            _uncommittedEvents.Add(evnt);
        }

        private void Apply(TodoCreated newTodo)
        {
            _currentState.Code = newTodo.Code;
            _currentState.Title = newTodo.Title;
            _currentState.State = newTodo.State;
        }

        private void Apply(TodoUpdated updatedTodo)
        {
            _currentState.Title = updatedTodo.Title;
            _currentState.State = updatedTodo.State;
        }

        public IList<IEvent> GetUncommittedEvents()
        {
            return new List<IEvent>(_uncommittedEvents);
        }

        public IList<IEvent> GetAllEvents()
        {
            return new List<IEvent>(_allEvents);
        }

        public void EventsCommitted()
        {
            _uncommittedEvents.Clear();
        }
    }
}
