namespace Generic;

public interface IRepository<TIEntity> where TIEntity : IIdentity
{
    void Add(TIEntity item);
    void Update(TIEntity item);
    void Remove(TIEntity item);
    List<TIEntity> GetAll();
    TIEntity GetById(int id);
}