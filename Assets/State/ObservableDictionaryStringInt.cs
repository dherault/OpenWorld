using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableDictionaryStringInt {
  private List<Observer> observers = new List<Observer>();
  private Dictionary<string, int> _value;
  public Dictionary<string, int> _ {
    get {
      return _value;
    }
    set {
      _value = value;
      Notify();
    }
  }

  public ObservableDictionaryStringInt(Dictionary<string, int> initialValue) {
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