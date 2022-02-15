using Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    public class EditorViewModel
    {
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }
        public FormatModel Format { get; set; }
        public DocumentModel Document { get; set; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
            FormatCommand = new RelayCommand(OpenStyleDialog);
            WrapCommand = new RelayCommand(ToggleWrap);
        }

        private void OpenStyleDialog()
        {
            throw new NotImplementedException();
        }

        private void ToggleWrap()
        {
            if (Format.TextWrapping == System.Windows.TextWrapping.Wrap)
                Format.TextWrapping = System.Windows.TextWrapping.NoWrap;
            else
                Format.TextWrapping = System.Windows.TextWrapping.Wrap;
        }
    }
}
