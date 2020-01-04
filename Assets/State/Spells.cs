
public struct Spell {
  public string Name;
  public float Range;
  public Elements Element;
  public int MinDamage;
  public int MaxDamage;
  public int MinCriticalDamage;
  public int MaxCriticalDamage;

  public Spell(string name, float range, Elements element, int minDamage, int maxDamage, int minCriticalDamage, int maxCriticalDamage) {
    Name = name;
    Range = range;
    Element = element;
    MinDamage = minDamage;
    MaxDamage = maxDamage;
    MinCriticalDamage = minCriticalDamage;
    MaxCriticalDamage = maxCriticalDamage;
  }
}

public class Spells {
  
  public static Spell SwordSlash = new Spell(
    "Sword Slash", 
    1f,
    Elements.None,
    12,
    16,
    14,
    18
  );
  
  public static Spell Thunder = new Spell(
    "Thunder",
    8f,
    Elements.Air,
    10,
    14,
    12,
    16
  );
}
