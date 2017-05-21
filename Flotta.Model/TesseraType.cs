using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    [LinkedTypeAttribute("Tessere")]
    public abstract class ITesseraType : LinkedType
    {
    }

    internal class TesseraType : ITesseraType
    {
    }
}
