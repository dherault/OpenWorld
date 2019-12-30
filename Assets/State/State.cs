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
    {"isUIShortcutsOpen", "Z"},
    {"isUISpellsOpen", "P"},
  };

  public Dictionary<string, string> shortcutNames = new Dictionary<string, string>() {
    {"isUIShortcutsOpen", "Shortcuts"},
    {"isUISpellsOpen", "Spells"},
  };

  // Avatar
  public ObservableVector3 avatarPosition = new ObservableVector3(new Vector3(0, 0, 0));

  // Terrain
  public int nTilesX = 3 * 6;
  public int nTilesZ = 3 * 6;
  public Vector3[,] tiles = new Vector3[3 * 6, 3 * 6];
}
