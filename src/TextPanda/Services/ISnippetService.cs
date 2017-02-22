using System.Collections.Generic;
using TextPanda.Models;

namespace TextPanda.Services
{
    public interface ISnippetService
    {
        /// <summary>
        /// Apply the snippets.
        /// </summary>
        /// <param name="snippets">The snippets to apply.</param>
        void ApplySnippets(IReadOnlyList<Snippet> snippets);
    }
}
