using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiDragController : MonoBehaviour, IDragHandler {

  private ObservableVector2 _position;

  public UiDragController(ObservableVector2 position) {
    _position = position;
  }

  private void Start() {
    gameObject.GetComponent<RectTransform>().anchoredPosition = _position._;
  }

  void Update() {
    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

    if (rectTransform.anchoredPosition != _position._) {
      rectTransform.anchoredPosition = _position._;
    }
  }

  public void OnDrag(PointerEventData eventData) {
    _position._ += eventData.delta;
  }

};
