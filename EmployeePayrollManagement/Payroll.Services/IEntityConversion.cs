using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Services
{
    public interface IEntityConversion<Tin,Tout>
    {
        Tout DtoToEntity(Tin dto);
        Tin EntityToDto(Tout Entity);
    }
}
