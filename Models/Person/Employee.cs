namespace TMPS_Labs.Models.Person; 

public class Employee : Person {
  public override IPerson Clone() {
    return new Employee {
      Age = Age,
      Job = Job,
      Name = Name
    };
  }
}
