using System.Threading.Tasks;
using ProsumerInfo.DAL.Repositories;

namespace ProsumerInfo.DAL
{
	public interface IUnitOfWork
	{
		IProsumerRepository ProsumerRepository { get; set; }
		IIdentityRepository IdentityRepository { get; set; }
		void Save();
		Task SaveAsync();
	}
}