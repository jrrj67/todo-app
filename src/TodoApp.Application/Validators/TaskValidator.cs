using FluentValidation;
using TodoApp.Domain.Interfaces;
using Task = TodoApp.Domain.Domains.Task;

namespace TodoApp.Application.Validators
{
    public class TaskValidator : AbstractValidator<Task>, IValidatable
    {
        public IReadOnlyCollection<string>? Errors { get; private set; }

        public TaskValidator()
        {
            RuleFor(x => x.Title)
                .MinimumLength(1)
                .MinimumLength(255);

            RuleFor(x => x.Description)
               .MinimumLength(1)
               .MinimumLength(255);
        }

        public bool IsValid<T>(T obj)
        {
            var task = obj as Task;

            if (task == null) 
                throw new ArgumentException($"Could not parse {nameof(obj)}.");

            var validator = new TaskValidator();

            var result = validator.Validate(task);

            if (!result.IsValid)
            {
                Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                return false;
            }

            return true;
        }
    }
}
