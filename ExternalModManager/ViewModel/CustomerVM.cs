using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ExternalModManager.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ExternalModManager.ViewModel
{
    class CustomerVM : ReactiveObject
    {
        public ReactiveCommand<Unit, string> GetString { get; set; } 
        
        
        public ReactiveCommand<Unit, Unit> GetString2 { get; set; } 

        [Reactive]
        public string OutputSearch { get; set; } = "AAAAAAAAAA";
        
        [Reactive]
        public string OutputSearchSecond { get; set; } = "AAAAAAAAAA";
        
        
        [Reactive]
        public string Search { get; set; } = "AAAAAAAAAA";
        
        
        private readonly ObservableAsPropertyHelper<string> _users;
        public string Users => _users.Value;

        public CustomerVM()
        {
            
            GetString = ReactiveCommand.CreateFromTask(GetDotNetCount);
            
            GetString2 = ReactiveCommand.CreateFromTask(GetDotNetCount2);

            _users = GetString.ToProperty(this, x => x.Users, scheduler: RxApp.MainThreadScheduler);
            
            this.WhenAnyValue(x => x.Search)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Select(time => Unit.Default)
                .InvokeCommand(this, x => x.GetString2);
            

            // this.WhenAnyValue(x => x.Search).InvokeCommand(this, vm => vm.GetString);


            // this.WhenAnyValue(x => x.Search)
            //     .Throttle(TimeSpan.FromMilliseconds(500))
            //     .Subscribe(x =>
            //     {
            //         OutputSearch = x;
            //     });
        }
        
        public async Task<string> GetDotNetCount()
        {
            Console.WriteLine(Search);

            // Thread.Sleep(3000);
            
            return "BABY";
        }
        
        public async Task<Unit> GetDotNetCount2()
        {
            Console.WriteLine(Search);

            Thread.Sleep(3000);
            
            return Unit.Default;
        }
    }
}
