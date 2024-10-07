﻿namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public IReadOnlyList<CartLine> Lines { get { return lines; } }

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line = this.lines
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if (line is null)
            {
                this.lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product)
            => lines.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue()
            => lines.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => lines.Clear();
    }
}
