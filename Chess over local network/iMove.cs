using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_over_local_network
{
    interface iMove
    {
        List<Square> GetLegalMovesOnBoard();

    }
}
