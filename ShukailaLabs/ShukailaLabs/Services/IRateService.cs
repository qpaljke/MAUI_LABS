using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukailaLabs.Services;
using ShukailaLabs.Entities;

internal interface IRateService
{
    IEnumerable<Rate> GetRates(DateTime date);
}
