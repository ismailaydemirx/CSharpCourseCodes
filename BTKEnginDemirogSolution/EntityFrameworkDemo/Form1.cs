using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            /*
            using (ETradeContext context = new ETradeContext()) // using kullanmamızın sebebi using'de blok bittiği anda garbagecollector'un gelmesini beklemeden kendimiz bellekte kaplanan o yeri boşaltıyoruz. 
            {
                dgwProducts.DataSource = context.Products.ToList<Product>(); // product dediğimizde ToList yani listeye çevirmeliyiz. Tabloya eriştik bu kod sayesinde çok kısa

            }
            */
        }

        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           _productDal.Add(new Product
           {
               Name = tbxName.Text,
               UnitPrice=Convert.ToDecimal(tbxUnitPrice.Text),
               StockAmount=Convert.ToInt32(tbxStockAmount.Text),
           });
            LoadProducts();
            MessageBox.Show("Added!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice=Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount=Convert.ToInt32(tbxStockAmountUpdate.Text),
            });
            LoadProducts();
            MessageBox.Show("Updated!");
            
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            });
            LoadProducts();
            MessageBox.Show("Deleted");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);

        }

        private void SearchProducts(string key)
        {
            var result = _productDal.GetByName(key);
            
            //var result = _productDal.GetAll().Where(p=>p.Name.ToLower().Contains(key.ToLower())).ToList(); // C# key sensetive olduğundan ToLower metodunu hem arama yaptığımız kısma hem de gönderdiğimiz veri de yazıları küçültüp o harfi içeren tüm sonuçların gelmesini sağladık.
            dgwProducts.DataSource = result;
            // en sonda ToList() metodunu kullanmalıyız aksi takdirde data null dönderiyor ve veriler listelenmiyor.
        }

        private void tbxGetById_Click(object sender, EventArgs e)
        {
            _productDal.GetByID(3);
        }

        private void tbxGetById2_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbxGetById2.Text,out int id))
            {
                var result = _productDal.GetByID(Convert.ToInt32(tbxGetById2.Text));
                dgwProducts.DataSource = result;
            }
            else
            {
                dgwProducts.DataSource = _productDal.GetAll();
            }
            
        }
    }
}
