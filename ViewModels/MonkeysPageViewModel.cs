
using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class MonkeysPageViewModel:ViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public ICommand LoadCommand{get;private set;}
        public MonkeysPageViewModel() 
        {
            Monkeys = new ObservableCollection<Monkey>();
            LoadCommand = new Command(async () => await LoadByCommand()) ;
            
        }

        private async Task LoadByCommand()
        {
            MonkeysService service = new MonkeysService();
            var list =service.GetMonkeys();
            Monkeys.Clear();
            foreach(var monkey in list)
                Monkeys.Add(monkey);



        }
    }
}
