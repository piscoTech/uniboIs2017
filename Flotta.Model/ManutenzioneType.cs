using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flotta.Model
{
    [LinkedTypeAttribute("Manutenzioni")]
    public abstract class IManutenzioneType : LinkedType
    {
    }

    internal class ManutenzioneType : IManutenzioneType
    {
    }
}
