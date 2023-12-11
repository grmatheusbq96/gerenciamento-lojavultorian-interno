namespace GerenciamentoVultorian.Domain.Interfaces.Repositories.Generic;

public interface IRepositorioGenerico<TEntity, Tid>
{
    IQueryable<TEntity> GetAll();

    TEntity GetById(Tid id);

    void Create(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    void Commit();
}