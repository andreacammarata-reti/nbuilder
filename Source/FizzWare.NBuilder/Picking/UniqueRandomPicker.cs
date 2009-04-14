using System;
using System.Collections.Generic;

namespace FizzWare.NBuilder
{
    public class UniqueRandomPicker<T>
    {
        private readonly IConstraint constraint;
        private readonly IUniqueRandomGenerator<int> uniqueRandomGenerator;

        public UniqueRandomPicker(IConstraint constraint, IUniqueRandomGenerator<int> uniqueRandomGenerator)
        {
            this.constraint = constraint;
            this.uniqueRandomGenerator = uniqueRandomGenerator;
        }

        public IList<T> From(IList<T> listToPickFrom)
        {
            uniqueRandomGenerator.Reset();

            int capacity = listToPickFrom.Count;
            var listToReturn = new List<T>();

            int end = constraint.GetEnd();

            for (int i = 0; i < end; i++)
            {
                int index = uniqueRandomGenerator.Generate(0, capacity - 1);

                listToReturn.Add(listToPickFrom[index]);
            }

            return listToReturn;
        }
    }
}