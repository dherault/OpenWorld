using UnityEngine;

class Boot {

  [RuntimeInitializeOnLoadMethod]
  static void OnRuntimeMethodLoad() {
    Debug.Log("After Scene is loaded and game is running");
  }

}
