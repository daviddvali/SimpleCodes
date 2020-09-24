namespace TCP.FSM.Enumeration {

  /// <summary>
  /// Possible states for the TCP FSM.
  /// </summary>
  public enum StateType : byte {
    CLOSED = 0,
    LISTEN = 1,
    SYN_SENT = 2,
    SYN_RCVD = 3,
    ESTABLISHED = 4,
    CLOSE_WAIT = 5,
    LAST_ACK = 6,
    FIN_WAIT_1 = 7,
    FIN_WAIT_2 = 8,
    CLOSING = 9,
    TIME_WAIT = 10,
    ERROR = 11,
  }
}
