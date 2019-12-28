using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {

  public static State _ = new State();

  // UI
  public ObservableBoolean isUISpellsOpen = new ObservableBoolean(false);
  public ObservableVector2 UISpellsPosition = new ObservableVector2(new Vector2(0, 0));
  public ObservableBoolean isUIShortcutsOpen = new ObservableBoolean(false);
  public ObservableVector2 UIShortcutsPosition = new ObservableVector2(new Vector2(0, 0));

  public Dictionary<string, string> shortcuts = new Dictionary<string, string>() {
    {"isUIShortcutsOpen", "Slash"},
    {"isUISpellsOpen", "P"},
  };
}
