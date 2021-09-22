using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examtst2
{
    interface IUsingPositions

    {
        public bool IsPositionUsedByInstance(int x, int y);
        public bool IsPositionUsedByInstance(Position position);
        public void RegisterNewPositionUsed(Position position);
        public List<Position> usedOnRight(int x, int y);

    }
}
