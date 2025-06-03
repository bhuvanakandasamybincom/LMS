using Microsoft.EntityFrameworkCore;
using Moq;
using LibraryManagement;
//using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LibraryManagement.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //var repositoryMock = new Mock<IAuthenticationModule>();
            //repositoryMock
            //    .Setup(r => r.GetBlogByNameAsync("Blog2"))
            //    .Returns(Task.FromResult(new book { Name = "Blog2", Url = "http://blog2.com" }));

            //ar controller = new BloggingControllerWithRepository(repositoryMock.Object);

            //// Act
            //var blog = await controller.GetBlog("Blog2");

            //// Assert
            //repositoryMock.Verify(r => r.GetBlogByNameAsync("Blog2"));
            //Assert.Equal("http://blog2.com", blog.Url);



            //var mockSet = new Mock<DbSet<Book>>();
            //mockSet.As<IDbAsyncEnumerable<Blog>>()
            //    .Setup(m => m.GetAsyncEnumerator())
            //    .Returns(new TestDbAsyncEnumerator<Blog>(data.GetEnumerator()));

        }
    }
}