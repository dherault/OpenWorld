using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiCharasteristicWindowController : MonoBehaviour, Observer {

  private void Start() {
    State._.playerCharacterisitics.Subscribe(this);
    PopulateCharacteristicsFields();
  }

  public void Update() {
    PopulateCharacteristicsFields();
  }

  private void PopulateCharacteristicsFields() {
    GameObject.Find("VitalityValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.vitality.ToString();
    GameObject.Find("EarthValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.earth.ToString();
    GameObject.Find("WaterValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.water.ToString();
    GameObject.Find("FireValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.fire.ToString();
    GameObject.Find("PlantValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.plant.ToString();
    GameObject.Find("AirValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.air.ToString();
    GameObject.Find("EtherValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.ether.ToString();
    GameObject.Find("RemainingPointsValue").GetComponent<TextMeshProUGUI>().text = State._.playerCharacterisitics.remainingPoints.ToString();
  }
}
