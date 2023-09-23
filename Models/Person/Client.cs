namespace TMPS_Labs.Models.Person;

public class Client : Person {
  public override IPerson Clone() {
    return new Client {
      Age = Age,
      Name = Name,
      Job = Job,
    };
  }
}
