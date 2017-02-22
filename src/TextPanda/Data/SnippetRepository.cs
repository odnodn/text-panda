using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TextPanda.Models;

namespace TextPanda.Data
{
    public class SnippetRepository : ISnippetRepository
    {
        const string SnippetsFileName = "snippets.json";
        readonly string _snippetsFilePath;

        /// <summary>
        /// Constructor
        /// </summary>
        public SnippetRepository()
        {
            var currentFolder = System.AppDomain.CurrentDomain.BaseDirectory;
            _snippetsFilePath = Path.Combine(currentFolder, SnippetsFileName);
        }

        /// <summary>
        /// Get all the snippets.
        /// </summary>
        /// <returns>The saved snippets.</returns>
        public IReadOnlyList<Snippet> GetAll()
        {            
            if(File.Exists(_snippetsFilePath) == false)
            {
                return new List<Snippet>();
            }

            var snippets = File.ReadAllText(_snippetsFilePath);
            return JsonConvert.DeserializeObject<List<Snippet>>(snippets);
        }

        /// <summary>
        /// Save the complete set of snippets.
        /// </summary>
        /// <param name="snippets">The snippets to save.</param>
        public void Save(IReadOnlyList<Snippet> snippets)
        {
            File.WriteAllText(_snippetsFilePath, JsonConvert.SerializeObject(snippets));
        }
    }
}
