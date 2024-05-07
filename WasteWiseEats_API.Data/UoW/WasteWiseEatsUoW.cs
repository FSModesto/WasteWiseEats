using WasteWiseEats_API.Data.BaseContext;
using WasteWiseEats_API.Domain.Interfaces.UoW;

namespace WasteWiseEats_API.Data.UoW
{
    public class WasteWiseEatsUoW : IWasteWiseEatsUoW
    {
        private readonly WasteWiseEatsContext _context;

        public WasteWiseEatsUoW(WasteWiseEatsContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            if (_context.Transaction is not null)
                return;

            _context.Transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_context.Transaction is null)
                throw new Exception("Não há uma transação aberta com o banco WhiteLabel para efetuar commit.");

            _context.SaveChanges();
            _context.Transaction.Commit();
            _context.Transaction = null;
        }

        public void Rollback()
        {
            _context.Transaction?.Rollback();
            _context.Transaction = null;

            _context.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            if (_context.Transaction is not null)
            {
                _context.Transaction.Dispose();
                _context.Transaction = null;
            }
        }
    }
}
