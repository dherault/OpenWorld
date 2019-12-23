using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsController : MonoBehaviour {

  void Start() {
    
  }

  void Update() {
    if (Input.GetKeyDown("P")) {
      print("space key was pressed");
    }
  }

}
