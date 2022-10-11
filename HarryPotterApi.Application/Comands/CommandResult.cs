using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarryPotterApi.Application.Comands
{
    public class CommandResult<T> : ICommandResult
    {
        private readonly IEnumerable<T> _data;
        public CommandResult(int totalPages, int currentPage, IEnumerable<T> data)
        {
            TotalPages = totalPages;
            CurrentPage = currentPage;
            _data = data ?? throw new ArgumentNullException();
        }
        public int TotalPages { get; }
        public int CurrentPage { get; }
        public int Items => Data.Count();
        public IReadOnlyCollection<T> Data => _data.ToArray();
    }
}