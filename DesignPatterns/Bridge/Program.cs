using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();

            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase // abstract yapmamızın sebebi Send() fonksiyonumuzda farklı mesaj gönderme teknikleri kullanabiliyoruz örneğin SMS ya da Email e o zaman bu sınıfı abstract yapalım ki Köprü yöntemiyle bir nevi Injection yaparak kullanalım.
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body); // abstract(soyut) yapmamızın sebebi farklı metodlar ile mesaj gönderilebildiği için hangi sistemi kullanacaksak o sınıfa buradaki sınıfımızı inherit edip send fonksiyonunu ona göre değiştirebilmek.

    }

    public class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender",body.Title);
        }
    }

    //... ihtiyaç dahilinde diğer mesaj gönderme yöntemleri de yazılabilir.

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title="Customer Update"});
            Console.WriteLine("Customer updated.");
        }
    }
}
