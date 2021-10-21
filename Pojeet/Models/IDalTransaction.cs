using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public interface IDalTransaction
    {
        List<Transaction> ObtientTransaction();
    }
}
