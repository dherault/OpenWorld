using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpellsController : MonoBehaviour, Observer {

  void Start() {
    gameObject.SetActive(State._.isUISpellsOpen._);
    State._.isUISpellsOpen.Subscribe(this);
  }

  public void Update() {
    if (gameObject.activeSelf != State._.isUISpellsOpen._) {
      gameObject.SetActive(State._.isUISpellsOpen._);
    }
  }

}
