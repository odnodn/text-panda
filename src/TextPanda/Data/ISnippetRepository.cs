using System.Collections.Generic;
using TextPanda.Models;

namespace TextPanda.Data
{
    public interface ISnippetRepository
    {
        /// <summary>
        /// Get all the snippets.
        /// </summary>
        /// <returns>The saved snippets.</returns>
        IReadOnlyList<Snippet> GetAll();

        /// <summary>
        /// Save the complete set of snippets.
        /// </summary>
        /// <param name="snippets">The snippets to save.</param>
        void Save(IReadOnlyList<Snippet> snippets);
    }
}
