using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EmployeeInformation
{
    internal class VM : INotifyPropertyChanged
    {
        #region properties
        DB db = DB.Instance;

        List<Employee> employees;

        public BindingList<Employee> Employees { get; set; } = new BindingList<Employee>();

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; NotifyPropertyChanged(); }
        }
        #endregion

        #region singleton
        private static VM vm;

        public static VM Instance
        {
            get
            {
                vm ??= new VM();
                return vm;
            }
        }

        private VM()
        {
            employees = db.Get();
            updateEmployees();
        }
        #endregion

        #region logic

        public void Save(Employee employee)
        {
            bool success = false;

            if (employee.IsNew)
            {
                success = db.Insert(employee);
            }
            else
            {
                success = db.Update(employee);
                if (success)
                {
                    employees.Remove(employee);
                    SelectedEmployee = null;
                }
            }
            if (success)
            {
                updateEmployees();
            }

        }

        public void Delete()
        {
            if (db.Delete(SelectedEmployee))
            {
                Employees.Remove(SelectedEmployee);
                employees.Remove(SelectedEmployee);
                SelectedEmployee = null;
            }
        }



        private void updateEmployees()
        {
            employees = db.Get();
            employees = employees.OrderBy(employee => employee.EmployeeID).ToList();

            Employees.Clear();
            foreach (Employee employee in employees)
            {
                Employees.Add(employee);
            }
        }
        public void Search(string searchKey)
        {
            employees = db.SearchResult(searchKey);
            employees = employees.OrderBy(employee => employee.EmployeeID).ToList();
            Employees.Clear();
            foreach (Employee employee in employees)
            {
                Employees.Add(employee);
            }
        }


        #endregion






        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
