using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Title = "Mavi Ev",
                Author = "Kahraman Tazeoğlu",
                Isbn = "123412231",
            };

            book.ShowBook();
            CareTaker _history = new CareTaker();
            _history.Memento = book.CreateUndo();

            book.Isbn = "3212412";
            book.ShowBook();

            book.RestoreFromUndo(_history.Memento);
            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        DateTime _lastEdited;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
            }
        }
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_title, _author, _isbn, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("---- ** ----)");
            Console.WriteLine("Title: {0}, Author: {1}", Title, Author);
            Console.WriteLine();
            Console.WriteLine("ISBN: {0}, Edited: {1}", Isbn, _lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            LastEdited = lastEdited;

        }


    }

    class CareTaker // Eski bilgileri tutabilmek için kullanırız.
    {
        public Memento Memento { get; set; } // Memento'daki hafızanın kendisini ekledik buraya
    }
}
