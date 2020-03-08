using System.Collections.Generic;

namespace Adesso.RideShare.Business.Models
{
    public class Neighbour
    {
        public List<int> CreateNeighbourList(int toFrom, int toWhere)
        {
            var Neighbours = new List<int>();

            if (toFrom > toWhere)
            {
                for (int i = toFrom; i >= toWhere; i--)
                {
                    if ((toWhere % 10 <= i % 10) && (toFrom % 10 == 0 ? 10 >= i % 10 : toFrom % 10 >= i % 10))
                    {
                        Neighbours.Add(i);
                    }
                }
            }
            else
            {
                for (int i = toFrom; i <= toWhere; i++)
                {
                    if ((toFrom % 10 <= i % 10) && (toWhere % 10 == 0 ? 10 >= i % 10 : toWhere % 10 >= i % 10))
                    {
                        Neighbours.Add(i);
                    }
                }
            }
    
            return Neighbours;
        }
    }
}
