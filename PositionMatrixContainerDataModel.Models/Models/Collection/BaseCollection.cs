using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public abstract class  BaseCollection<T>:NumericType<T>,IEnumerable<T> 
    {
        #region Fields
         protected List<T> Elements { get; private set; }
        #endregion

        #region Constructor

        protected BaseCollection()
        {
            Elements = new List<T>();
        }

        protected BaseCollection(IEnumerable<T> elements)
        {
            Elements = elements.ToList();
        }

        #endregion

        #region Methods

        protected void Fill(IEnumerable<T> elements)
        {
            Elements = elements.ToList();
        }

        public virtual void Add(T element)
        {
            if (element == null)
            {
                throw  new ArgumentNullException("Method parametr can not be null");
            }
            Elements.Add(element);
        }

        public T this[int index] => Elements.ElementAt(index);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        #endregion


    }
}
