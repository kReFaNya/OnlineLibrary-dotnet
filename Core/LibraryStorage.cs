using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LibraryStorage
    {
        private List<LibraryItem> items = new List<LibraryItem>();
        private Dictionary<int, LibraryItem> itemsById = new Dictionary<int, LibraryItem>();

        public void AddItem(LibraryItem item)
        {
            items.Add(item);

            if (!itemsById.ContainsKey(item.Id))
            {
                itemsById.Add(item.Id, item);
            }
        }

        public LibraryItem FindItemById(int id)
        {
            if (itemsById.ContainsKey(id))
            {
                return itemsById[id];
            }

            return null;
        }

        public List<LibraryItem> GetAvailableItems()
        {
            return itemsById
                .Where(pair => pair.Value.IsAvailable)
                .Select(pair => pair.Value)
                .ToList();
        }

        public IEnumerator<LibraryItem> GetEnumerator()
        {
            foreach (LibraryItem item in items)
            {
                yield return item;
            }
        }
    }
}
