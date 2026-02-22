
using System;
using System.Collections.Generic;
// BookManager 클래스에서 Book 클래스를 사용하기 위해 선언
using BookLibrary.Models; 

namespace BookLibrary.Models
{
    // 도서 정보 클래스 (모델)
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Title} - {Author}";
        }
    }
}

namespace BookLibrary.Core
{
    // 도서 목록 관리 클래스 (로직)
    public class BookManager
    {
        private List<Book> books = new List<Book>();
        private int nextId = 1;

        public void AddBook(string title, string author)
        {
            books.Add(new Book { Id = nextId++, Title = title, Author = author });
            Console.WriteLine("도서가 추가되었습니다.");
        }

        public void DisplayBooks()
        {
            Console.WriteLine("\n--- 도서 목록 ---");
            if (books.Count == 0) Console.WriteLine("도서가 없습니다.");
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine("-----------------\n");
        }

        public void DisplayBooksByLinq()
        {
            Console.WriteLine("\n--- EVEN도서 목록 ---");
            if (books.Count == 0) Console.WriteLine("도서가 없습니다.");
            List<Book> bk = books;
            var evenlists = bk.Where(x => x.Id % 2 == 0).ToList();
            foreach (var evl in evenlists)
            {
                Console.WriteLine(evl.ToString());
            }
            Console.WriteLine("--------EVEN END---------\n");
            Book book12 = (from p in books
                                 where p.Author == "Honda tetsuya"
                                 select p)
                                 .First();
            Console.WriteLine(book12.ToString());
            Console.WriteLine("--------.First END---------\n");
            Console.WriteLine("--------DisplayBooksByLinq END---------\n");
            
        }         
    }
}


namespace BookLibrary.ConsoleApp
{
    using BookLibrary.Core; // BookManager 사용

    class Program
    {
        static void Main(string[] args)
        {
            BookManager manager = new BookManager();
            bool running = true;

            manager.AddBook("The Adventures of Tom Sawyer", "Mark twain");
            manager.AddBook("Strawberry night1", "Honda tetsuya");
            manager.AddBook("The great gatsby", "Scott Fitzgerald");
            manager.AddBook("Strawberry night2", "Honda tetsuya");

            while (running)
            {
                Console.WriteLine("1. 도서 추가 | 2. 목록 보기 | 3. 종료 | 4. Linq test");
                Console.Write("선택: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("제목: ");
                        string title = Console.ReadLine();
                        Console.Write("저자: ");
                        string author = Console.ReadLine();
                        manager.AddBook(title, author);
                        break;
                    case "2":
                        manager.DisplayBooks();
                        break;
                    case "3":
                        running = false;
                        break;
                    case "4":
                        manager.DisplayBooksByLinq();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}
/*


// See https://aka.ms/new-console-template for more information
Console.WriteLine("--------------------");



var users = new List<User>
{
    new User { Name = "홍길동", IsActive = true },
    new User { Name = "김철수", IsActive = false }
};

var activeUsers = users.Where(u => u.IsActive).ToList();
*/