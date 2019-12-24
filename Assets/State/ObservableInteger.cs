using System.Collections.Generic;

public class ObservableInteger {
  private List<Observer> observers = new List<Observer>();
  private int _value;
  public int _ {
    get {
      return _value;
    }
    set {
      _value = value;
      Notify();
    }
  }

  public ObservableInteger(int initialValue) {
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
