using StarNoteWebAPICore.DataAccess.Repositories.Abstract;
using StarNoteWebAPICore.DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarNoteWebAPICore.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private StarNoteEntity _starnoteapicontext;
        public UnitOfWork(StarNoteEntity context)
        {
            _starnoteapicontext = context;
            CaseRepository = new CaseRepository(_starnoteapicontext);
            CostumerRepository = new CostumerRepository(_starnoteapicontext);
            CompanyRepository = new CompanyRepository(_starnoteapicontext);
            CostumerorderRepository = new CostumerorderRepository(_starnoteapicontext);
            FilemanagementRepository = new FilemanagementRepository(_starnoteapicontext);
            JoborderRepository = new JoborderRepository(_starnoteapicontext);
            KdvRepository = new KdvRepository(_starnoteapicontext);
            LisanceRepository = new LisanceRepository(_starnoteapicontext);
            PaymenttypeRepository = new PaymenttypeRepository(_starnoteapicontext);
            ProcesstypeRepository = new ProcesstypeRepository(_starnoteapicontext);
            ProductRepository = new ProductRepository(_starnoteapicontext);
            RememberRepository = new RememberRepository(_starnoteapicontext);
            RememberstatusRepository = new RememberstatusRepository(_starnoteapicontext);
            SalesmanRepository = new SalesmanRepository(_starnoteapicontext);
            StokRepository = new StokRepository(_starnoteapicontext);
            TypedetailRepository = new TypedetailRepository(_starnoteapicontext);
            TypeRepository = new TypeRepository(_starnoteapicontext);
            UnitRepository = new UnitRepository(_starnoteapicontext);
            UserRepository = new UserRepository(_starnoteapicontext);          
        }

        public ICaseRepository CaseRepository { get; private set; }

        public ICostumerRepository CostumerRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }

        public ICostumerorderRepository CostumerorderRepository { get; private set; }

        public IFilemanagementRepository FilemanagementRepository { get; private set; }

        public IJoborderRepository JoborderRepository { get; private set; }

        public IKdvRepository KdvRepository { get; private set; }

        public ILisanceRepository LisanceRepository { get; private set; }

        public IPaymenttypeRepository PaymenttypeRepository { get; private set; }

        public IProcesstypeRepository ProcesstypeRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IRememberRepository RememberRepository { get; private set; }

        public IRememberstatusRepository RememberstatusRepository { get; private set; }

        public ISalesmanRepository SalesmanRepository { get; private set; }

        public IStokRepository StokRepository { get; private set; }

        public ITypedetailRepository TypedetailRepository { get; private set; }

        public ITypeRepository TypeRepository { get; private set; }

        public IUnitRepository UnitRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public int Complate()
        {
            return _starnoteapicontext.SaveChanges();
        }

        public void Dispose()
        {
            _starnoteapicontext.Dispose();
        }
    }
}
