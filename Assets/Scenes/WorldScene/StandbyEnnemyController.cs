using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyEnnemyController : MonoBehaviour {

  public float attackRadius = 4;
  
  private void OnMouseDown() {
    if (IsAvatarInBeginCombatRange()) {
      CombatController.BeginCombat(gameObject);
    }
  }
  
  private void OnMouseOver() {
    if (IsAvatarInBeginCombatRange()) {
      GetComponent<Outline>().enabled = true;
    }
  }

  private void OnMouseExit() {
    GetComponent<Outline>().enabled = false;
  }

  private bool IsAvatarInBeginCombatRange() {
    GameObject avatarGameObject = GameObject.Find("Avatar");

    return Math3D.IsInSphere(gameObject.transform.position, avatarGameObject.transform.position, attackRadius);
  }
  
}
