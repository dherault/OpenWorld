using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShortcutsController : MonoBehaviour, Observer {

  private static float widthRatio = 0.75f;
  private static float heightRatio = 0.75f;

  static public void CreateUI() {
    GameObject gameObject = new GameObject();
    gameObject.name = "UIShortcutsCanvas";
    gameObject.AddComponent<Canvas>();

    Canvas canvas = gameObject.GetComponent<Canvas>();
    canvas.renderMode = RenderMode.ScreenSpaceOverlay;

    GameObject imageGameObject = new GameObject();
    imageGameObject.name = "UIShortcutsCanvas-image";
    imageGameObject.transform.SetParent(canvas.transform);

    Image image = imageGameObject.AddComponent<Image>();
    image.color = new Color(255, 255, 255);

    image.rectTransform.sizeDelta = new Vector2(Screen.width * widthRatio, Screen.height * heightRatio);
  }

  void Start() {
    gameObject.SetActive(State._.isUIShortcutsOpen._);
    State._.isUIShortcutsOpen.Subscribe(this);
  }

  public void Update() {
    if (gameObject.activeSelf != State._.isUIShortcutsOpen._) {
      gameObject.SetActive(State._.isUIShortcutsOpen._);
    }
  }

}
