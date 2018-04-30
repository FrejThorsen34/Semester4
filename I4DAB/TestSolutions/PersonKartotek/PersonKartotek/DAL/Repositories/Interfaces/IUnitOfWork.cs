using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Models;

namespace PersonKartotek.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get; set; }
        IPersonAddressRepository PersonAddressRepository { get; set; }
        IPersonRepository PersonRepository { get; set; }
        IPhoneNumberRepository PhoneNumberRepository { get; set; }
        IPrimaryAddressRepository PrimaryAddressRepository { get; set; }
        IZipRepository ZipRepository { get; set; }
        void Save();
        Task SaveAsync();
    }
}
