using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyEnnemyController : MonoBehaviour {

  public float attackRadius = 5;

  private void OnMouseDown() {
    if (IsAvatarInBeginCombatRange()) {
      CombatController.BeginCombat(transform.parent);
    }
  }

  private void OnMouseEnter() {
    if (IsAvatarInBeginCombatRange()) {
      GetComponentInParent<Outline>().enabled = true;
    }
  }

  private void OnMouseExit() {
    GetComponentInParent<Outline>().enabled = false;
  }

  private bool IsAvatarInBeginCombatRange() {
    GameObject avatarGameObject = GameObject.Find("Avatar");

    return Math3D.IsInSphere(gameObject.transform.position, avatarGameObject.transform.position, attackRadius);
  }

}
