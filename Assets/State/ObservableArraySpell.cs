using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableArraySpell {
  private List<Observer> observers = new List<Observer>();
  private Spell[] _value;
  public Spell[] _ {
    get {
      return _value;
    }
    set {
      _value = value;
      Notify();
    }
  }

  public ObservableArraySpell(Spell[] initialValue) {
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