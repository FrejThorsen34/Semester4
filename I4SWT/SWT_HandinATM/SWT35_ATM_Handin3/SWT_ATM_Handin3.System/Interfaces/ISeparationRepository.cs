using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_ATM_Handin3.System.Interfaces
{
    public interface ISeparationRepository
    {
        void AddSeperationEvent(SeparationEvent e);
        void DeleteSeperationEvent(SeparationEvent e);
        SeparationEvent Get(string tag1, string tag2);
        List<SeparationEvent> GetAll();
    }
}
