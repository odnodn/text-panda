using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TextPanda.Data;
using TextPanda.Models;
using TextPanda.Services;
using TextPanda.Windows;

namespace TextPanda.ViewModels
{
    public class SnippetsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ISnippetRepository _snippetRepository;
        ISnippetService _snippetService;

        public SnippetsViewModel()
        {
            _snippetRepository = new SnippetRepository();
            _snippetService = new SnippetService();

            Snippets = new ObservableCollection<Snippet>(
                _snippetRepository.GetAll());

            _snippetService.ApplySnippets(Snippets);

            AddCommand = new DelegatingCommand(x => true, OnAdd);
            SaveCommand = new DelegatingCommand(x => true, OnSave);
            DeleteCommand = new DelegatingCommand(x => true, OnDelete);
        }

        public void OnAdd(object param)
        {
            Snippets.Add(new Snippet());
        }

        public void OnSave(object param)
        {
            // todo use Rx to debounce and auto-save
            _snippetRepository.Save(Snippets);
            _snippetService.ApplySnippets(Snippets);
        }

        public void OnDelete(object param)
        {
            if (param is Snippet == false)
            {
                return;
            }

            // todo add to undo stack
            Snippets.Remove((Snippet)param);
        }

        public ObservableCollection<Snippet> Snippets { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
    }
}
