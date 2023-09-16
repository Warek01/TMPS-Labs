namespace TMPS_Labs.Models.Person;

public abstract class Person : IPerson {
  public int    Age  { get; set; }
  public string Name { get; set; }
  public string Job  { get; set; }
}
