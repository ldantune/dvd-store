﻿namespace DvdStore.Domain.Repositories.Category;
public interface ICategoryWriteOnlyRepository
{
    Task Add(Entities.Category category);
    Task Delete(int id);
}
