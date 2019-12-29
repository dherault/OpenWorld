using System.Collections.Generic;
using UnityEngine;

public class ObservableVector3 {
  private List<Observer> observers = new List<Observer>();
  private Vector3 _value;
  public Vector3 _ {
    get {
      return _value;
    }
    set {
      _value = value;
      Notify();
    }
  }

  public ObservableVector3(Vector3 initialValue) {
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
