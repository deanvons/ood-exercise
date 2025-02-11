using LibraryApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class LibraryManager
    {
        /// <summary>
        /// Library manager that handles all Book, Memmber, and Borrowing responsibilities.
        /// </summary>
        public class LibraryManager
        {
            public List<Book> Books { get; set; }
            public List<Member> Members { get; set; }
            public Dictionary<Member, List<Book>> BorrowedBooks { get; set; }

            public LibraryManager()
            {
                Books = new List<Book>();
                Members = new List<Member>();
                BorrowedBooks = new Dictionary<Member, List<Book>>();
            }

            public void AddBook(Book book)
            {
                Books.Add(book);
            }

            public void RemoveBook(Book book)
            {
                Books.Remove(book);
            }

            public void UpdateBook(string originalTitle, Book updatedBook)
            {
                var book = Books.Find(b => b.Title == originalTitle);
                if (book != null)
                {
                    book.Title = updatedBook.Title;
                    book.Author = updatedBook.Author;
                }
            }

            public Book FindBook(string title)
            {
                return Books.Find(b => b.Title == title);
            }

            public void RegisterMember(Member member)
            {
                Members.Add(member);
            }

            public void RemoveMember(Member member)
            {
                Members.Remove(member);
            }

            public void UpdateMember(string memberId, Member updatedMember)
            {
                var member = Members.Find(m => m.MemberId == memberId);
                if (member != null)
                {
                    member.Name = updatedMember.Name;
                    member.MemberId = updatedMember.MemberId;
                }
            }

            public Member FindMember(string memberId)
            {
                return Members.Find(m => m.MemberId == memberId);
            }

            public void BorrowBook(Member member, Book book)
            {
                if (!BorrowedBooks.ContainsKey(member))
                {
                    BorrowedBooks[member] = new List<Book>();
                }
                BorrowedBooks[member].Add(book);
            }

            public void ReturnBook(Member member, Book book)
            {
                if (BorrowedBooks.ContainsKey(member))
                {
                    BorrowedBooks[member].Remove(book);
                }
            }

            public List<Book> ViewBorrowedBooks(Member member)
            {
                if (BorrowedBooks.ContainsKey(member))
                {
                    return BorrowedBooks[member];
                }
                return new List<Book>(); // Return empty list if member has no borrowed books
            }

        }

    }
}
