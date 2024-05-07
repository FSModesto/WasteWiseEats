namespace WasteWiseEats_API.Domain.Interfaces.UoW
{
    public interface IUoW : IDisposable
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
