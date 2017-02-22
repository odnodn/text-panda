using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Validar;

namespace TextPanda.Models
{
    [InjectValidation]
    public class Snippet : INotifyPropertyChanged
    {
        //public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Shortcut { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ReplaceWith { get; set; }

        public bool IsEnabled { get; set; } = true;

        public ReplaceMode ReplaceMode { get; set; } = ReplaceMode.Auto;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

