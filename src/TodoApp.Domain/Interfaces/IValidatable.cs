namespace TodoApp.Domain.Interfaces
{
    public interface IValidatable
    {
        IReadOnlyCollection<string>? Errors { get; }
        bool IsValid<T>(T validatable);
    }
}
