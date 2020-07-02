using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class ModifyMenagerDeleteViewModel : ViewModelBase
    {
        Entity context = new Entity();
        ModifyMenagerDelete mmd = new ModifyMenagerDelete();

        public ModifyMenagerDeleteViewModel(ModifyMenagerDelete mmdOpen)
        {
            mmd = mmdOpen;
        }
        private List<tblEmploye> listEmploye;
        public List<tblEmploye> ListEmploye
        {
            get
            {
                return context.tblEmployes.ToList();
            }
            set
            {
                listEmploye = value;
                OnPropertyChanged("ListEmploye");
            }
        }
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
            mmd.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        private ICommand deleteUser;
        public ICommand DeleteUser
        {
            get
            {
                if (deleteUser == null)
                {
                    deleteUser = new RelayCommand(param => DeleteUserExecute(), param => CanDeleteUserExecute());
                }
                return deleteUser;
            }
        }
        public void DeleteUserExecute()
        {
            try
            {
                if (Employe != null)
                {
                    using (Entity context = new Entity())
                    {
                        //taking registration number from selected user 
                        int IdNumber = Employe.EmployeID;
                        //inserting message box that will be shown when delete button is pressed
                        MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure that you want to delete employe?", "Delete Confirmation", MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            List<int> employeInManagerList = new List<int>();
                            List<tblManager> managerList = context.tblManagers.ToList();
                            foreach (tblManager item in managerList)
                            {
                                employeInManagerList.Add(item.EmployeID.GetValueOrDefault());
                            }
                            //menager loged in
                            if (employeInManagerList.Contains(IdNumber))
                            {
                                tblManager managerToDelete = (from r in context.tblManagers where r.EmployeID == IdNumber select r).First();
                                context.tblManagers.Remove(managerToDelete);
                                context.SaveChanges();
                            }
                            List<int> employeInReportList = new List<int>();
                            List<tblReport> reportList = context.tblReports.ToList();
                            foreach (tblReport item in reportList)
                            {
                                employeInReportList.Add(item.EmployeID.GetValueOrDefault());
                            }
                            if (employeInReportList.Contains(IdNumber))
                            {
                                tblReport reportToDelete = (from r in context.tblReports where r.EmployeID == IdNumber select r).First();
                                context.tblReports.Remove(reportToDelete);
                                context.SaveChanges();
                            }
                            //finding user and card that needs to be deleted, finding them with registration number 
                            tblEmploye employeToDelete = (from r in context.tblEmployes where r.EmployeID == IdNumber select r).First();
                            //removing from database=> both user and his ID card
                            context.tblEmployes.Remove(employeToDelete);

                            // saving changes in database
                            context.SaveChanges();
                            // writing action into file
                            //Write.Writer.WriteDelete(userToDelete);
                            //// refreshing => getting new state from database
                            ListEmploye = context.tblEmployes.ToList();
                        }
                        // in case "No" is clicked in line 77
                        else
                        {
                            MessageBox.Show("Deleting proccess is stoped");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeleteUserExecute()
        {
            if (Employe == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
