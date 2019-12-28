using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsController : MonoBehaviour {

  void Start() {

  }

  void Update() {
    // if (Input.GetKeyDown(KeyCode.Z)) {
    //   State._.isUIShortcutsOpen._ = !State._.isUIShortcutsOpen._;
    // }

    foreach (KeyValuePair<string, string> item in State._.shortcuts) {
      KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), State._.shortcuts[item.Key]);

      if (Input.GetKeyDown(keyCode)) {
        ((ObservableBoolean)typeof(State).GetField(item.Key).GetValue(State._))._ = !((ObservableBoolean)typeof(State).GetField(item.Key).GetValue(State._))._;
      }
    }
  }

}
