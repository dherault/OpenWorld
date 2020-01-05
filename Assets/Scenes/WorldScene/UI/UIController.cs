using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController {

  static public void CreateUI() {
    UiWindowController characteristicsWindowController = GameObject.Find("CharacteristicsWindow").AddComponent<UiWindowController>();

    characteristicsWindowController.isOpen = State._.isUiCharacteristicsWindowOpen;
    characteristicsWindowController.position = State._.UiCharacteristicsWindowPosition;
  }

}
