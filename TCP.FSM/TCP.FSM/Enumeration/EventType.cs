namespace TCP.FSM.Enumeration {

  /// <summary>
  /// Possible events for the TCP FSM.
  /// </summary>
  public enum EventType : byte {
    APP_PASSIVE_OPEN = 0,
    APP_ACTIVE_OPEN = 1,
    APP_SEND = 2,
    APP_CLOSE = 3,
    APP_TIMEOUT = 4,
    RCV_SYN = 5,
    RCV_ACK = 6,
    RCV_SYN_ACK = 7,
    RCV_FIN = 8,
    RCV_FIN_ACK = 9
  }
}
