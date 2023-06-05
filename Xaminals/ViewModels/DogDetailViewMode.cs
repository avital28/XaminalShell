using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Web;
using Xaminals.Data;
using Xaminals.Models;

namespace Xaminals.ViewModels
{
     [QueryProperty(nameof(Name), "name")]
    public class DogDetailPageViewModel : ViewModel
    {
        private readonly DataSource _source;

        public string Name {
            set
            {
                LoadAnimal(value);
                
            }
        }

        
        public Animal Dog { get; private set; }
        public DogDetailPageViewModel (DataSource source)
        {
            _source = source;
        }
       
        void LoadAnimal(string name)
        {
            try
            {
                Dog = _source.FirstOrDefault(a => a.Name == name);
                OnPropertyChanged(nameof(Dog));


            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load animal.");
            }
        }


    }
}
