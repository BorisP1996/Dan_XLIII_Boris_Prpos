using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class CreateManagerViewModel:ViewModelBase
    {
        CreateManager createManagerWindow;
        Entity context = new Entity();

        public CreateManagerViewModel(CreateManager cmOpen)
        {
            createManagerWindow = cmOpen;
            SectorList = GetSectors();
            LevelList = GetLevels();
        }
        #region Properties
        private tblEmploye employe;
        public tblEmploye Employe
        {
            get
            {
                return employe;
            }
            set
            {
                employe = value;
                OnPropertyChanged("Employe");
            }
        }
        private tblLevel level;
        public tblLevel Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }
        private List<tblLevel> levelList;
        public List<tblLevel> LevelList
        {
            get
            {
                return levelList;
            }
            set
            {
                levelList = value;
                OnPropertyChanged("LevelList");
            }
        }
        private tblSector sector;
        public tblSector Sector
        {
            get
            {
                return sector;
            }
            set
            {
                sector = value;
                OnPropertyChanged("Sector");
            }
        }   
        private List<tblSector> sectorList;
        public List<tblSector> SectorList
        {
            get
            {
                return sectorList;
            }
            set
            {
                sectorList = value;
                OnPropertyChanged("SectorList");
            }
        }
        #endregion

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save==null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private void SaveExecute()
        {

        }
        private bool CanSaveExecute()
        {
            return false;
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close==null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            createManagerWindow.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        #region Methods
        private List<tblSector> GetSectors()
        {
            List<tblSector> listOfSectors = new List<tblSector>();
            listOfSectors = context.tblSectors.ToList();
            return listOfSectors;
        }
        private List<tblLevel> GetLevels()
        {
            List<tblLevel> listOfLevels = new List<tblLevel>();
            listOfLevels = context.tblLevels.ToList();
            return listOfLevels;
        }
        #endregion
    }
}
