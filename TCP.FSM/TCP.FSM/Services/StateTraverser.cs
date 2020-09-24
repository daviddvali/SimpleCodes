using System.Collections.Generic;
using System.Linq;
using TCP.FSM.Enumeration;
using TCP.FSM.Helpers;

namespace TCP.FSM.Services {

  /// <summary>
  /// TCP FSM states traverser
  /// </summary>
  public class StateTraverser {
    private readonly EventsMapper _eventsMapper;

    public StateTraverser() {
      _eventsMapper = new EventsMapper();
    }

    public StateType TraverseEvents(params EventType[] events) {
      return TraverseEvents(events as IEnumerable<EventType>);
    }

    private StateType TraverseEvents(IEnumerable<EventType> events, StateType startingState = StateType.CLOSED) {
      var state = startingState;
      foreach (var e in events) {
        if (state != StateType.ERROR) {
          var nextState = _eventsMapper[state].FirstOrDefault(s => s.EventName == e);
          state = nextState != default ? nextState.NextState : StateType.ERROR;
        }
      }

      return state;
    }
  }
}
