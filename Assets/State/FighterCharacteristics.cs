using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCharacteristics {

  public int actionPints;
  public float movementRange;
  public int vitality;
  public int earth;
  public int water;
  public int fire;
  public int plant;
  public int air;
  public int ether;
  public int remainingPoints;

  public int initiative {
    get {
      return vitality + earth + water + fire + plant + air + ether;
    }
  }

  private List<Observer> observers = new List<Observer>();

  public FighterCharacteristics(
    int initialActionPoints,
    float initialMovementRange,
    int initialVitality,
    int initialEarth,
    int initialWater,
    int initialFire,
    int initialPlant,
    int initialAir,
    int initialEther,
    int initialRemainingPoints
  ) {
    actionPints = initialActionPoints;
    movementRange = initialMovementRange;
    vitality = initialVitality;
    earth = initialEarth;
    water = initialWater;
    fire = initialFire;
    plant = initialPlant;
    air = initialAir;
    ether = initialEther;
    remainingPoints = initialRemainingPoints;
  }

  public void Notify() {
    observers.ForEach(x => x.Update());
  }

  public void Subscribe(Observer observer) {
    observers.Add(observer);
  }

  public void Unsubscribe(Observer observer) {
    observers.Remove(observer);
  }

}
