using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStatisctics {

  public readonly int actionPints;
  public readonly float movementRange;
  public readonly int vitality;
  public readonly int earth;
  public readonly int water;
  public readonly int fire;
  public readonly int plant;
  public readonly int air;
  public readonly int ether;
  public int remainingPoints;

  public int initiative {
    get {
      return vitality + earth + water + fire + plant + air + ether;
    }
  }

  public FighterStatisctics(
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

}
