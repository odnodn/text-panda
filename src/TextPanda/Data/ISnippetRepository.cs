using System.Collections.Generic;
using TextPanda.Models;

namespace TextPanda.Data
{
    public interface ISnippetRepository
    {
        IReadOnlyList<Snippet> GetAll();
        void Save(IReadOnlyList<Snippet> snippets);
    }
}
