using System.Collections.Generic;
using UnityEngine;

public class ObservableVector2 {
  private List<Observer> observers = new List<Observer>();
  private Vector2 _value;
  public Vector2 _ {
    get {
      return _value;
    }
    set {
      _value = value;
      Notify();
    }
  }

  public ObservableVector2(Vector2 initialValue) {
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
