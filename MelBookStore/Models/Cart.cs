using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        // When you go to add an item, pass in the project object and the quantity 
        public virtual void AddItem(Project project, int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Project.BookID == project.BookID)
                .FirstOrDefault();

            // if there wasn't anything, then add a new line that has the project and the qty
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = project,
                    Quantity = quantity
                });
            }

            // otherwise just update the quantity 
            else
            {
                line.Quantity += quantity;
            }

        }

        // 
        public virtual void RemoveLine(Project project) =>
            Lines.RemoveAll(x => x.Project.BookID == project.BookID);

        //
        public virtual void Clear() => Lines.Clear();

        //
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => e.Project.Price * e.Quantity);

        // build a class within a class: CartLine
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Project Project { get; set; }
            public int Quantity { get; set; }
        }

    }
}
