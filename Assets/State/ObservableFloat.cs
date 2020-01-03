using System.Collections.Generic;
using UnityEngine;

public class ObservableFloat {
  private List<Observer> observers = new List<Observer>();
  private float _value;
  public float _ {
    get {
      return _value;
    }
    set {
      _value = value;
      Notify();
    }
  }

  public ObservableFloat(float initialValue) {
    _value = initialValue;
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