using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice8_Book.Models;
using Practice8_Book.Repasitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice8_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepasitory<Book> repasitory;
        public BookController(IRepasitory<Book> repasitory)
        {
            this.repasitory = repasitory;
        }
        [HttpPost]
        public string Create(Book book)
        {
            var result = repasitory.Insert(book);
            repasitory.Save();
            return book.Id + result;
        }
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            if (repasitory.GetAll().Where(b => b.Id == id).ToList().Count != 0)
                return repasitory.Get(id);
            return null;
        }
        [HttpGet]
        public List<Book> GetAll()
        {
            return repasitory.GetAll();
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (repasitory.GetAll().Where(b => b.Id == id).ToList().Count != 0)
            {
                try
                {
                    var result = repasitory.Delete(id);
                    repasitory.Save();
                    return result;
                }
                catch
                {
                    return "There is a dependency for this book in Book-Category table or Author-Book table....";

                }
            }
            return "Not found any book with this id for delete";

        }
        [HttpPut]
        public string Update(Book book)
        {
            try
            {
                var end = repasitory.Update(book);
                repasitory.Save();
                return end;
            }
            catch (Exception)
            {
                return " Not found any book with this id for update";
            }

        }
        //[HttpPost("Search")]
        //public OUTPUT_BOOKLIST Search(search_model search)
        //{
        //    var allbooks = repository.GetAll();
        //    var endList = new OUTPUT_BOOKLIST();

        //    if (search.publication != null)
        //    {
        //        endList.books = allbooks.Where(b => b.Publication.Name == search.publication).ToList();
        //    }
        //    if (search.categories != null)
        //    {
        //        var bookcategory = new List<List<Book_Catrgiry>>();
        //        foreach (var book in allbooks)
        //            bookcategory.Add(book.book_Catrgiries);

        //        for (int i = 0; i < bookcategory.Count; i++)
        //        {
        //            for (int j = 0; j < bookcategory[i].Count; j++)
        //            {
        //                var categoryname = bookcategory[i][j].Category.Name;
        //                if (search.categories.Contains(categoryname))
        //                {
        //                    var exist = allbooks.Where(b => b.book_Catrgiries.Contains(bookcategory[i][j])).ToList();
        //                    foreach (var book in exist)
        //                        if (!endList.books.Contains(book))
        //                            endList.books.Add(book);
        //                }

        //            }
        //        }
        //    }
        //    if (search.authors != null)
        //    {
        //        var boocauthor = new List<List<Author_Book>>();
        //        foreach (var book in allbooks)
        //            boocauthor.Add(book.author_Books);

        //        for (int i = 0; i < boocauthor.Count; i++)
        //        {
        //            for (int j = 0; j < boocauthor[i].Count; j++)
        //            {
        //                var authorname = boocauthor[i][j].Author.FullName;
        //                if (search.authors.Contains(authorname))
        //                {
        //                    var exist = allbooks.Where(b => b.author_Books.Contains(boocauthor[i][j])).ToList();
        //                    foreach (var book in exist)
        //                        if (!endList.books.Contains(book))
        //                            endList.books.Add(book);
        //                }

        //            }
        //        }
        //    }

        //    return endList;
        //}
    }
}
