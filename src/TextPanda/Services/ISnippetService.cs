using System.Collections.Generic;
using TextPanda.Models;

namespace TextPanda.Services
{
    public interface ISnippetService
    {
        void ApplySnippets(IReadOnlyList<Snippet> snippets);
    }
}
