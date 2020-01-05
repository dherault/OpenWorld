using UnityEngine;

class Boot {

  [RuntimeInitializeOnLoadMethod]
  static void OnRuntimeMethodLoad() {
    UiController.CreateUI();
  }

}
