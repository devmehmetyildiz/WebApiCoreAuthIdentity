using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarNoteWebAPICore.DataAccess.Repositories.Abstract;

namespace StarNoteWebAPICore.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        ICaseRepository CaseRepository { get; }

        ICostumerRepository CostumerRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        ICostumerorderRepository CostumerorderRepository { get; }
        IFilemanagementRepository FilemanagementRepository { get; }
        IJoborderRepository JoborderRepository { get; }
        IKdvRepository KdvRepository { get; }
        ILisanceRepository LisanceRepository { get; }
        IPaymenttypeRepository PaymenttypeRepository { get; }
        IProcesstypeRepository ProcesstypeRepository { get; }
        IProductRepository ProductRepository { get; }
        IRememberRepository RememberRepository { get; }
        IRememberstatusRepository RememberstatusRepository { get; }
        ISalesmanRepository SalesmanRepository { get; }
        IStokRepository StokRepository { get; }
        ITypedetailRepository TypedetailRepository { get; }
        ITypeRepository TypeRepository { get; }
        IUnitRepository UnitRepository { get; }
        IUserRepository UserRepository { get; }
        int Complate();
    }
}
