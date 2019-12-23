using Unidux;

public static class Booleans {

  public enum ActionType {
    ToggleSpellsUIOpened
  }

  public class Action {

    public ActionType ActionType;
    // public any ActionPayload;

  }

  public static class ActionCreator {

    public static Action Create(ActionType type) {
      return new Action() {ActionType = type};
    }

  }

  public class Reducer : ReducerBase<State, Action> {

    public override State Reduce(State state, Action action) {
      switch (action.ActionType) {
        case ActionType.ToggleSpellsUIOpened:
          state.IsSpellsUIOpened = !state.IsSpellsUIOpened;

          return state;

        default:
          return state;
      }
    }

  }

}
