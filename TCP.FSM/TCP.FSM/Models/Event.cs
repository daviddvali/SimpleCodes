using TCP.FSM.Enumeration;

namespace TCP.FSM.Models {

  /// <summary>
  /// Event model with it's subsequent event.
  /// </summary>
  public class Event {
    public Event() { } // Just to support creating an object with no parameters.

    public Event(EventType eventName, StateType nextState) : this() {
      EventName = eventName;
      NextState = nextState;
    }

    public EventType EventName { get; set; }

    public StateType NextState { get; set; }
  }
}
