using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AdoNetDemo
{
    public class ProductDal
    {
        //Tablomuzun Add,Insert,Delete,Update gibi işlemlerini burada yapacağız
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade;integrated security=true"); // bağlantı işlemini yapıyoruz. @ işaretini koymamızın sebebi @ işaretinden sonraki her şeyi string olarak kabul et dedik.
        public List<Product> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("SELECT * FROM Products", _connection);//sorgumuzu bağlantıya gönderdik. Bağlantının açık olduğunu kontrol edelim.

            SqlDataReader reader = command.ExecuteReader(); // üstte sorgumuzu tanımladık ve burada da sorgumuzu çalıştırıyoruz. Yani bir nevi sorguyu yazdık burada çalıştırıyoruz.

            List<Product> products = new List<Product>();

            while (reader.Read()) // reader de dolaşacak kayıt bitene kadar dolaş
            {
                Product product = new Product // burada ürünü oluşturduk
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                };
                products.Add(product); // burada da içinde gezerek oluşturduğumuz kaydı ekliyoruz.
            }

            reader.Close(); // komutumuzu kapatıyoruz
            _connection.Close();//şimdi de bağlantımızı kapatıyoruz. Bağlantımızı açık bırakmak iyi olmayacaktır o yüzden bağlantımızı kapatmamız gerekir. bağlantıyı kapatmayı UNUTMAMALIYIZ
            return products;
        }

        

        public DataTable GetAll2()
        {

            ConnectionControl();
            SqlCommand command = new SqlCommand("SELECT * FROM Products", _connection);//sorgumuzu bağlantıya gönderdik. Bağlantının açık olduğunu kontrol edelim.
            SqlDataReader reader = command.ExecuteReader(); // üstte sorgumuzu tanımladık ve burada da sorgumuzu çalıştırıyoruz. Yani bir nevi sorguyu yazdık burada çalıştırıyoruz.

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close(); // komutumuzu kapatıyoruz
            _connection.Close();//şimdi de bağlantımızı kapatıyoruz. Bağlantımızı açık bırakmak iyi olmayacaktır o yüzden bağlantımızı kapatmamız gerekir. bağlantıyı kapatmayı UNUTMAMALIYIZ
            return dataTable;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "INSERT INTO Products values(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery(); // ExecuteNonQuery'i böyle çalıştırabiliriz aynı zamanda int bir değer olan etkilenen kayıt sayısını döndürür yani biz 1 kayıt ekleyeceğimiz için 1 değerini döndürür.

            _connection.Close();
        }

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "UPDATE Products set Name=@name, UnitPrice=@unitPrice, StockAmount=@stockAmount where ID=@id", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id",product.Id);
            command.ExecuteNonQuery(); // ExecuteNonQuery'i böyle çalıştırabiliriz aynı zamanda int bir değer olan etkilenen kayıt sayısını döndürür yani biz 1 kayıt ekleyeceğimiz için 1 değerini döndürür.

            _connection.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
                "DELETE FROM Products where Id=@id",_connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            _connection.Close();
        }

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open(); // bağlantıyı üstte tanımladık şimdi bağlantıyı açıyoruz. Ancak eğer bağlantı açıkken bir daha açmaya çalışırsak sorun olacağından if ile kontrol edeceğiz bu durumu.

            }
        }
    }
}
