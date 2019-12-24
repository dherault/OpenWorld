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

    GameObject backgroundImageGameObject = new GameObject();
    backgroundImageGameObject.name = "UIShortcutsCanvas-backgroundImage";
    backgroundImageGameObject.transform.SetParent(canvas.transform);

    Image backgroundImage = backgroundImageGameObject.AddComponent<Image>();
    backgroundImage.color = new Color(255, 255, 255);

    backgroundImage.rectTransform.sizeDelta = new Vector2(Screen.width * widthRatio, Screen.height * heightRatio);
    backgroundImage.rectTransform.anchoredPosition = new Vector2(0, 0);

    GameObject dragImageGameObject = new GameObject();
    dragImageGameObject.name = "UIShortcutsCanvas-backgroundImage-dragImage";
    dragImageGameObject.transform.SetParent(backgroundImageGameObject.transform);

    Image dragImage = dragImageGameObject.AddComponent<Image>();
    dragImage.color = new Color(0, 255, 0);

    dragImage.rectTransform.sizeDelta = new Vector2(Screen.width * widthRatio, 50);
    dragImage.rectTransform.anchoredPosition = new Vector2(0, Screen.height * heightRatio / 2 - 50 / 2);

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
