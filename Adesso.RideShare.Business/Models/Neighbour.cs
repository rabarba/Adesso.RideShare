using System.Collections.Generic;

namespace Adesso.RideShare.Business.Models
{
    public class Neighbour
    {
        public List<int> CreateNeighbourList(int toFrom, int toWhere)
        {
            var Neighbours = new List<int>();

            var modToFrom = toFrom % 10 == 0 ? 10 : toFrom % 10;
            var modToWhere = toWhere % 10 == 0 ? 10 : toWhere % 10;

            if (toFrom > toWhere)
            {
                for (int i = toFrom; i >= toWhere; i--)
                {
                    var mod = i % 10 == 0 ? 10 : i % 10;

                    if (modToFrom <= modToWhere)
                    {
                        if (modToFrom <= mod && modToWhere >= mod)
                        {
                            Neighbours.Add(i);
                        }
                    }
                    else
                    {
                        if (modToFrom >= mod && modToWhere <= mod)
                        {
                            Neighbours.Add(i);
                        }
                    }
                }
            }
            else
            {

                for (int i = toFrom; i <= toWhere; i++)
                {
                    var mod = i % 10 == 0 ? 10 : i % 10;

                    if (modToFrom <= modToWhere)
                    {
                        if (modToFrom <= mod && modToWhere >= mod)
                        {
                            Neighbours.Add(i);
                        }
                    }
                    else
                    {
                        if (modToFrom >= mod && modToWhere <= mod)
                        {
                            Neighbours.Add(i);
                        }
                    }
                }
            }
    
            return Neighbours;
        }
    }
}
