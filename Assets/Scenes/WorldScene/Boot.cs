using UnityEngine;

class Boot {

  [RuntimeInitializeOnLoadMethod]
  static void OnRuntimeMethodLoad() {
    UIController.CreateUI();
  }

}
