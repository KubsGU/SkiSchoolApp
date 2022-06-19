using FluentAssertions;
using NUnit.Framework;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.TodoLists.Commands.CreateTodoList;
using SkiSchool.Application.TodoLists.Commands.DeleteTodoList;
using SkiSchool.Domain.Entities;
using static Testing;

namespace SkiSchool.Application.IntegrationTests.TodoLists.Commands
{
    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public async Task ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand { Id = 99 };
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            await SendAsync(new DeleteTodoListCommand
            {
                Id = listId
            });

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}