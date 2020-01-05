using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {

  public static State _ = new State();

  // Camera
  public ObservableVector3 cameraPosition = new ObservableVector3(Vector3.zero);
  public ObservableVector3 cameraRotation = new ObservableVector3(45 * Vector3.forward);

  // Terrain
  public int nTilesX = 3 * 6;
  public int nTilesZ = 3 * 6;
  public Vector3[,] tiles = new Vector3[3 * 6, 3 * 6];

  // Avatar and Player
  public ObservableVector3 avatarPosition = new ObservableVector3(Vector3.zero);
  public ObservableFloat avatarRotationY = new ObservableFloat(0);
  public ObservableInt playerLevel = new ObservableInt(1);
  public ObservableInt playerExperience = new ObservableInt(0);
  public ObservableDictionaryStringInt playerStatistics = new ObservableDictionaryStringInt(new Dictionary<string, int>() {
    {"vitality", 100},
    {"earth", 0},
    {"water", 0},
    {"fire", 0},
    {"ether", 0},
    {"air", 10},
    {"plant", 0},
  });
  private static Spell[] spells = {
    Spells.SwordSlash,
    Spells.Thunder,
  };
  public ObservableArraySpell playerSpells = new ObservableArraySpell(spells);

  // UI
  public ObservableBoolean isUiCharacteristicsWindowOpen = new ObservableBoolean(false);
  public ObservableVector2 UiCharacteristicsWindowPosition = new ObservableVector2(new Vector2(Screen.currentResolution.width / 3, Screen.currentResolution.height / 2));

  // Shortcuts
  public Dictionary<string, string> shortcuts = new Dictionary<string, string>() {
    {"isUiCharacteristicsWindowOpen", "C"},
  };
  public Dictionary<string, string> shortcutNames = new Dictionary<string, string>() {
    {"isUiCharacteristicsWindowOpen", "Characteristics"},
  };
}
