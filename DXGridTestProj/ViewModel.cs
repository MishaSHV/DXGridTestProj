using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXGridTestProj
{
    class ViewModel : ViewModelBase
    {
        private NorthwindEntities northwindDbContext;

        public ViewModel()
        {
            if (IsInDesignMode)
            {
                Orders = new ObservableCollection<Order>();
                Shippers = new ObservableCollection<Shipper>();
                Employees = new ObservableCollection<Employee>();
            }
            else
            {
                northwindDbContext = new NorthwindEntities();

                northwindDbContext.Orders.Load();
                Orders = northwindDbContext.Orders.Local;

                northwindDbContext.Shippers.Load();
                Shippers = northwindDbContext.Shippers.Local;

                northwindDbContext.Employees.Load();
                Employees = northwindDbContext.Employees.Local;
            }
        }

        public ObservableCollection<Order> Orders
        {
            get => GetValue<ObservableCollection<Order>>();
            private set => SetValue(value);
        }

        public ObservableCollection<Shipper> Shippers
        {
            get => GetValue<ObservableCollection<Shipper>>();
            private set => SetValue(value);
        }

        public ObservableCollection<Employee> Employees
        {
            get => GetValue<ObservableCollection<Employee>>();
            private set => SetValue(value);
        }
    }
}
