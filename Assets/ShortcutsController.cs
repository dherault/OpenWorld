using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsController : MonoBehaviour {

  void Start() {

  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Z)) {
      State._.isUISpellsOpen._ = !State._.isUISpellsOpen._;
    }

    if (Input.GetKeyDown(KeyCode.Question)) {
      State._.isUIShortcutsOpen._ = !State._.isUIShortcutsOpen._;
    }
  }

}
