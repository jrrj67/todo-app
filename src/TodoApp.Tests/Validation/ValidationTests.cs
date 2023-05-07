using TodoApp.Application.Validators;
using Task = TodoApp.Domain.Domains.Task;

namespace TodoApp.Tests.Validation
{
    public class ValidationTests
    {
        [Fact]
        public void ValidationShouldThrowArgumentException()
        {
            var id = Guid.NewGuid();

            var createdAt = DateTime.Now;

            var validator = new TaskValidator();

            Assert.Throws<ArgumentException>(() =>
            {
                new Task(
                validator,
                id: id,
                title: "",
                description: "Test task description",
                isFavorited: true,
                createdAt: createdAt);
            });
        }

        [Fact]
        public void ValidationShouldReturnValidationMessage()
        {
            var id = Guid.NewGuid();

            var createdAt = DateTime.Now;

            var validator = new TaskValidator();

            var message = string.Empty;

            try
            {
                var task = new Task(
                    validator,
                    id: id,
                    title: "",
                    description: "Test task description",
                    isFavorited: true,
                    createdAt: createdAt);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.NotEmpty(message);
        }
    }
}