using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_9
{
    public class Store<T> : IStore<T> where T : IProduct
    {
        private List<T> product_list_ = new List<T>();


        public void Add(T product)
        {
            if (!product_list_.Any(i => i.Id == product.Id))
            {
                product_list_.Add(product);
            }
            else
            {
                throw new Exception("ERROR\nТовар с таким Id уже есть.");
            }
        }


        public void Remove(int id)
        {
            var storeRemove = product_list_.FirstOrDefault(i => i.Id == id);
            if (storeRemove != null)
            {
                product_list_.Remove(storeRemove);
            }
            else
            {
                throw new InvalidOperationException("ERROR\nТовара с таким Id нет.");
            }
        }


        public T GetProductById(int id)
        {
            var item = product_list_.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new Exception("ERROR\nТовара с таким Id нет.");
            }
        }


        public void UpdatePrice(int id, decimal newPrice)
        {
            var item = product_list_.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Price = newPrice;
            }
            else
            {
                throw new ArgumentException("ERROR\nТовара с таким Id нет.");
            }
        }


        public void UpdateQuantity(int id, int newQuantity)
        {
            var item = product_list_.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Quantity = newQuantity;
            }
            else
            {
                throw new ArgumentException("ERROR\nТовара с таким Id нет.");
            }
        }


        public List<T> GetProductsByCategory(string category)
        {
            return product_list_.Where(i => i.Category == category).ToList();
        }


        public Dictionary<string, List<T>> GroupByCategory()
        {
            Dictionary<string, List<T>> groups = new Dictionary<string, List<T>>();
            var result = product_list_.GroupBy(i => i.Category);

            foreach (var i in result)
            {
                groups[i.Key] = i.ToList();
            }

            return groups;
        }
    }
}
