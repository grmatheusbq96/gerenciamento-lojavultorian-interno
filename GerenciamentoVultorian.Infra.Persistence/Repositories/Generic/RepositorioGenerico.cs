using GerenciamentoVultorian.Domain.Interfaces.Repositories.Generic;
using GerenciamentoVultorian.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoVultorian.Infra.Persistence.Repositories.Generic;

public class RepositorioGenerico<TEntity, Tid> : IRepositorioGenerico<TEntity, Tid>
    where TEntity : Entity<Tid>
    where Tid : IEquatable<Tid>
{
    protected DbContext Db;
    protected DbSet<TEntity> DbSet;

    public RepositorioGenerico(DbContext context)
    {
        Db = context ?? throw new ArgumentException("Falha ao inicializar o repositório.");
        DbSet = Db.Set<TEntity>();
    }

    public void Commit()
    {
        Db.SaveChanges();
    }

    public void Create(TEntity entity)
    {
        Db.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        Db.Remove(entity);
    }

    public IQueryable<TEntity> GetAll()
    {
        return DbSet;
    }

    public TEntity GetById(Tid id)
    {
        return DbSet.Find(id);
    }

    public void Update(TEntity entity)
    {
        Db.Update(entity);
    }
}