﻿

namespace DvdStore.Domain.Repositories;
public interface IUnitOfWork
{
    public Task Commit();
}
