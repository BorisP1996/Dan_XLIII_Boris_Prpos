using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class ModifyStartViewModel
    {
        ModifyStart ms = new ModifyStart();

        public ModifyStartViewModel(ModifyStart open)
        {
            ms = open;
        }
        private ICommand create;
        public ICommand Create
        {
            get
            {
                if (create==null)
                {
                    create = new RelayCommand(param => CreateExecute(), param => CanCreateExecute());
                }
                return create;
            }
        }
        private void CreateExecute()
        {
            ModifyMenager mm = new ModifyMenager();

            mm.ShowDialog();
        }
        private bool CanCreateExecute()
        {
            return true;
        }

        private ICommand view;
        public ICommand View
        {
            get
            {
                if (view == null)
                {
                    view = new RelayCommand(param => ViewExecute(), param => CanViewExecute());
                }
                return view;
            }
        }

        private void ViewExecute()
        {
            ModifyMenagerDelete mmd = new ModifyMenagerDelete();
            mmd.ShowDialog();
        }
        private bool CanViewExecute()
        {
            return true;
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            ms.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }
    }
}
