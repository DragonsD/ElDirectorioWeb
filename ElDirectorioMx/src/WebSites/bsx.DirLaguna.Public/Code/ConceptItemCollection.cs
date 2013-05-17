using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace bsx.DirLaguna.Public.Code
{
    [Serializable]
    public class ConceptItemCollection : CollectionBase
    {
        decimal total;

        public ConceptDetail this[int index]
        {
            get
            {
                return ((ConceptDetail)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        public int Add(ConceptDetail value)
        {
            return (List.Add(value));
        }

        public int AddNewItem()
        {
            ConceptDetail value = new ConceptDetail(List.Count);
            return (List.Add(value));
        }

        public int IndexOf(ConceptDetail value)
        {
            return (List.IndexOf(value));
        }

        public void Insert(int index, ConceptDetail value)
        {
            List.Insert(index, value);
        }

        public void Remove(ConceptDetail value)
        {
            List.Remove(value);
        }

        public void Clear()
        {
            List.Clear();
            List.Add(new ConceptDetail(0));
        }

        public decimal GetSummarySubtotal()
        {
            total = 0;
            foreach (ConceptDetail item in List)
            {
                total = total + item.SubTotal;
            }

            return total;
        }

        public ConceptItemCollection GetItems()
        {
            return (ConceptItemCollection)List;
        }

        // RETORNA LOS DETALLES PERO QUE TIENEN DATOS, DESCARTANDO LOS QUE SE HAYAN AGREGADO VACIOS
        public ConceptItemCollection GetItemsValid()
        {
            ConceptItemCollection listValid = new ConceptItemCollection();
            foreach (ConceptDetail item in List)
            {
                if (!string.IsNullOrEmpty(item.Concepto) && item.Cantidad > 0)
                    listValid.Add(item);
            }

            return listValid;
        }

        public int Count
        {
            get
            {
                return List.Count;
            }
        }

    }
}