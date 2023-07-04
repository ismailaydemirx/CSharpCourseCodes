using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("NIKON");  // 1 ve 2. id'ler aynı çünkü multiton desgin pattern ile çalışıyoruz.
            Camera camera2 = Camera.GetCamera("NIKON");
            Camera camera3 = Camera.GetCamera("CANON"); // 3 ve 4. id'ler aynı çünkü multiton desgin pattern ile çalışıyoruz.
            Camera camera4 = Camera.GetCamera("CANON");
            Camera camera5 = Camera.GetCamera("OLYMPUS"); // farklı id

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);
            Console.WriteLine(camera5.Id);

            Console.ReadLine();
        }
    }

    class Camera // farklı marka kameralar için her biri için ayrı (tek tek) instance üretmek istiyoruz.
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>(); // 1 den fazla instance olacağı için bunları "Dictionary" ile tutacağız.
        static object _lock = new object(); // aynı anda birden fazla işa parçacığı tarafından erişimi engelleyerek, dictionary'e erişimi senkronize ederek thread güvenliği sağlamak için kullanılır.
        public Guid Id { get; set; }


        private Camera()
        {
            Id = Guid.NewGuid(); // gerçekten aynı instance'nin üretildiğini garanti etmeye çalışıyoruz.
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock) // burada üst kısımda tanımladığımız object _lock static olmadığı için hata aldık ve sonra onun başına static getirdik.
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
