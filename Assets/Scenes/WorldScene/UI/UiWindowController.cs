using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UiWindowController : MonoBehaviour, Observer, IDragHandler {

  public ObservableVector2 position;
  public ObservableBoolean isOpen;
  private RectTransform _rectTransform;

  private void Start() {
    isOpen.Subscribe(this);

    gameObject.SetActive(isOpen._);

    _rectTransform = gameObject.GetComponent<RectTransform>();

    _rectTransform.anchoredPosition = position._;
  }

  public void Update() {
    if (gameObject.activeSelf != isOpen._) {
      gameObject.SetActive(isOpen._);
    }

    if (_rectTransform.anchoredPosition != position._) {
      _rectTransform.anchoredPosition = position._;
    }
  }

  public void OnDrag(PointerEventData eventData) {
    position._ += eventData.delta;
  }

};
