using System.Collections.Generic;

namespace Roulette
{
    public interface IFieldFactory
    {
        List<Field> CreateFields();
    }
}
