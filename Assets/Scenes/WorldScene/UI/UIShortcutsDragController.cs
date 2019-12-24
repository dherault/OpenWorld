using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIShortcutsDragController : MonoBehaviour, IDragHandler {

  public float width;
  public float height;

  void Start() {
    Image image = gameObject.GetComponent<Image>();

    image.rectTransform.sizeDelta = new Vector2(width, height);
    image.rectTransform.anchoredPosition = State._.UIShortcutsPosition._;
  }

  void Update() {
    Image image = gameObject.GetComponent<Image>();

    if (State._.UIShortcutsPosition._ != image.rectTransform.anchoredPosition) {
      image.rectTransform.anchoredPosition = State._.UIShortcutsPosition._;
    }
  }

  public void OnDrag(PointerEventData eventData) {
    State._.UIShortcutsPosition._ += eventData.delta;
  }

}
