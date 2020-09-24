using System;
using Xunit;
using TCP.FSM.Services;
using TCP.FSM.Enumeration;
using System.Collections.Generic;

namespace TCP.FSM.Tester {

  /// <summary>
  /// Unit Tests for TCP FSM states traverser
  /// </summary>
  public class StateTraverserUnitTest {
    private StateTraverser _stateTraverser;

    public StateTraverserUnitTest() {
      _stateTraverser = new StateTraverser();
    }

    [Theory]
    [InlineData(StateType.ESTABLISHED, EventType.APP_PASSIVE_OPEN, EventType.APP_SEND, EventType.RCV_SYN_ACK)]
    public void TestCase1(StateType expectedEvent, params EventType[] inputEvents) {
      var actualState = _stateTraverser.TraverseEvents(inputEvents);
      Assert.Equal(expectedEvent, actualState);
    }

    [Theory]
    [InlineData(StateType.SYN_SENT, EventType.APP_ACTIVE_OPEN)]
    public void TestCase2(StateType expectedEvent, params EventType[] inputEvents) {
      var actualState = _stateTraverser.TraverseEvents(inputEvents);
      Assert.Equal(expectedEvent, actualState);
    }

    [Theory]
    [InlineData(StateType.ERROR, EventType.APP_ACTIVE_OPEN, EventType.RCV_SYN_ACK, EventType.APP_CLOSE, EventType.RCV_FIN_ACK, EventType.RCV_ACK)]
    public void TestCase3(StateType expectedEvent, params EventType[] inputEvents) {
      var actualState = _stateTraverser.TraverseEvents(inputEvents);
      Assert.Equal(expectedEvent, actualState);
    }
  }
}
