namespace TmpsLabs.Models; 

public interface IObservable<T, V> {
  public void Subscribe(Action<T, V> callback);
}
