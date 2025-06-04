using Microsoft.EntityFrameworkCore;
using Moq;
using LibraryManagement;
//using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Contracts;
using LibraryManagement.Interface;
using LibraryManagement.Model;
using LibraryManagement.Data;
using System.Data.Common;
using LibraryManagement.DbContexts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LibraryManagement.Service;
using LibraryManagement.Controllers;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Mvc;
namespace LibraryManagement.Test
{
    public class UnitTest1
    {
         
        [Fact]
        public async void GetMostBorrowedBooks_ShouldReturnLists()
        {
            // Arrange           
            var mockBookService = new Mock<IBookService>();
            List<Book> books = new List<Book>();
            var dataBooks = new List<Book>
            {
                new Book { Id=4,Title = "Othello",AuthorId=1,ISBN="978-000-9786",CopiesAvailable=1 },
                new Book { Id=5,Title = "Sam Sheep",AuthorId=1,ISBN="978-000-1247",CopiesAvailable=1 },
                new Book { Id=7,Title = "Goose on the",AuthorId=2,ISBN="754-2-2-642-19999",CopiesAvailable=2 },
            };

            mockBookService.Setup(r => r.GetMostBorrowedBooksService())
              .Returns(Task.FromResult(dataBooks));
            var bookController = new BookController(mockBookService.Object);


            // Act
            var result = await bookController.GetMostBorrowedBooks();
            if(result!=null)
            {
                books = (result.Result as OkObjectResult).Value as List<Book>;
            }
             
            // Assert
            mockBookService.Verify(r => r.GetMostBorrowedBooksService());
            Assert.Equal(dataBooks, books);
        }
       
    }
}