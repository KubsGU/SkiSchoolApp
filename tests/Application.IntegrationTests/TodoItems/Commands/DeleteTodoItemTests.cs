using FluentAssertions;
using NUnit.Framework;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.TodoItems.Commands.CreateTodoItem;
using SkiSchool.Application.TodoItems.Commands.DeleteTodoItem;
using SkiSchool.Application.TodoLists.Commands.CreateTodoList;
using SkiSchool.Domain.Entities;
using static Testing;

namespace SkiSchool.Application.IntegrationTests.TodoItems.Commands
{
    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public async Task ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand { Id = 99 };

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteTodoItemCommand
            {
                Id = itemId
            });

            var item = await FindAsync<TodoItem>(itemId);

            item.Should().BeNull();
        }
    }
}