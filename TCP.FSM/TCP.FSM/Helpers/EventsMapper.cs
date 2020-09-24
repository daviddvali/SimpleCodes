using System.Collections.Generic;
using TCP.FSM.Enumeration;
using TCP.FSM.Models;

namespace TCP.FSM.Helpers {

  /// <summary>
  /// Defines the valid events of all states for TCP FSM.
  /// </summary>
  internal class EventsMapper {
    private IDictionary<StateType, IEnumerable<Event>> _eventStates;

    public EventsMapper() {
      InitMapperData();
    }

    public IEnumerable<Event> this[StateType state] => _eventStates[state];

    private void InitMapperData() {
      _eventStates = new Dictionary<StateType, IEnumerable<Event>> {
        {
          StateType.CLOSED,
          new List<Event> {
            new Event(EventType.APP_PASSIVE_OPEN, StateType.LISTEN),
            new Event(EventType.APP_ACTIVE_OPEN, StateType.SYN_SENT),
          }
        },
        {
          StateType.LISTEN,
          new List<Event> {
            new Event(EventType.RCV_SYN, StateType.SYN_RCVD),
            new Event(EventType.APP_SEND, StateType.SYN_SENT),
            new Event(EventType.APP_CLOSE, StateType.CLOSED),
          }
        },
        {
          StateType.SYN_RCVD,
          new List<Event> {
            new Event(EventType.APP_CLOSE, StateType.FIN_WAIT_1),
            new Event(EventType.RCV_ACK, StateType.ESTABLISHED),
          }
        },
        {
          StateType.SYN_SENT,
          new List<Event> {
            new Event(EventType.RCV_SYN, StateType.SYN_RCVD),
            new Event(EventType.RCV_SYN_ACK, StateType.ESTABLISHED),
            new Event(EventType.APP_CLOSE, StateType.CLOSED),
          }
        },
        {
          StateType.ESTABLISHED,
          new List<Event> {
            new Event(EventType.APP_CLOSE, StateType.FIN_WAIT_1),
            new Event(EventType.RCV_FIN, StateType.CLOSE_WAIT),
          }
        },
        {
          StateType.FIN_WAIT_1,
          new List<Event> {
            new Event(EventType.RCV_FIN, StateType.CLOSING),
            new Event(EventType.RCV_FIN_ACK, StateType.TIME_WAIT),
            new Event(EventType.RCV_ACK, StateType.FIN_WAIT_2),
          }
        },
        {
          StateType.CLOSING,
          new List<Event> {
            new Event(EventType.RCV_ACK, StateType.TIME_WAIT),
          }
        },
        {
          StateType.FIN_WAIT_2,
          new List<Event> {
            new Event(EventType.RCV_FIN, StateType.TIME_WAIT),
          }
        },
        {
          StateType.TIME_WAIT,
          new List<Event> {
            new Event(EventType.APP_TIMEOUT, StateType.CLOSED),
          }
        },
        {
          StateType.CLOSE_WAIT,
          new List<Event> {
            new Event(EventType.APP_CLOSE, StateType.LAST_ACK),
          }
        },
        {
          StateType.LAST_ACK,
          new List<Event> {
            new Event(EventType.RCV_ACK, StateType.CLOSED),
          }
        },
      };
    }
  }
}
