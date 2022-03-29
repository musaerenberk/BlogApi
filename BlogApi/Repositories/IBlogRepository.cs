using BlogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> Get();
        Task<Blog> Get(int id);
        Task<Blog> Create(Blog book);
        Task Update(Blog book);
        Task Delete(int id);
    }
}
