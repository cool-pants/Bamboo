using Microsoft.Win32;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
        }

        public void NewFile()
        {
            Document.FileName = String.Empty;
            Document.FilePath = String.Empty;
            Document.Text = String.Empty;
        }

        private void saveFile(string filepath)
        {
            File.WriteAllText(filepath, Document.Text);
        }

        private void SaveFile()
        {
            saveFile(Document.FilePath);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if(saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                saveFile(saveFileDialog.FileName);
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void DockFile(FileDialog dialog)
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
