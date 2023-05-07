using TodoApp.Domain.Interfaces;

namespace TodoApp.Domain.Domains
{
    public class Task
    {
        private readonly IValidatable _validator;

        public Guid Id { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public bool IsFavorited { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdateAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public Task(IValidatable validator, Guid id, string title, string description, bool isFavorited, DateTime createdAt,
            DateTime? updateAt = null, DateTime? deletedAt = null)
        {
            _validator = validator;

            Id = id;
            Title = title;
            Description = description;
            IsFavorited = isFavorited;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
            DeletedAt = deletedAt;

            if (!_validator.IsValid(this))
                throw new ArgumentException(_validator?.Errors?.First());
        }
    }
}