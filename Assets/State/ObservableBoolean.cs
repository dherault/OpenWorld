using System.Collections.Generic;

public class ObservableBoolean {
  private List<Observer> observers = new List<Observer>();
  private bool _value;
  public bool _ {
    get {
      return _value;
    }
    set {
      _value = value;
      Notify();
    }
  }

  public ObservableBoolean(bool initialValue) {
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
