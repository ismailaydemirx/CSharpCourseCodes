using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator(); // Mediator tanımladık.

            Teacher engin = new Teacher(mediator); // Teacher'a senin asıl iletişim kuracağın kişi Mediator'dedik
            engin.Name = "Engin"; // teacher'in ismini belirledik.

            mediator.Teacher = engin; // Mediator'a bir öğretmen ekledik.



            Student ismail = new Student(mediator); // Student olan Ismail'in asıl iletişime geçeceği yer Mediator olacak.
            ismail.Name = "Ismail";

            Student salih = new Student(mediator);
            salih.Name = "Salih";

            mediator.Students = new List<Student>{ismail, salih}; // New'leme yapmasaydık hata olurdu. Students listesini başlattık.
            // Students'i list olarak oluşturmuştuk Students.Add 'add' ibaresini eklememizin sebebi bu

            engin.SendNewImageUrl("slide1.jpg");
            engin.RecieveQuestion("is this true", salih);
            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator; // Protected yaptığımızda büyük harfle değişken tanımlanır. // Öğretmen ve öğrencinin sistemle iletişime geçebileceği bir yapı tasarlıyoruz.

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; internal set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question fron {0}, {1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question : {0}, {1}",student.Name,answer);
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} recieved image : {0}",url,Name);
        }

        public void RecieveAnswer(string answer, Student student)
        {
            Console.WriteLine("Student recieved answer {0}, {1}",student,answer);
        }
    }

    class Mediator 
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students{ get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.RecieveAnswer(answer,student);
        }
    }
}
