/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Ninja"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Ninja.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);


            SimpleIoc.Default.Register<CategoryListViewModel>();
            SimpleIoc.Default.Register<NinjaListViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public NinjaListViewModel NinjaList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NinjaListViewModel>();
            }
        }

        public AddNinjaViewModel AddNinja
        {
            get
            {
                return new AddNinjaViewModel(this.NinjaList);
            }
        }

        public AddGearViewModel AddGear
        {
            get
            {
                return new AddGearViewModel(this.CategoryList);
            }
        }

        public EditGearViewModel EditGear
        {
            get
            {
                return new EditGearViewModel(this.CategoryList);
            }
        }

        public CategoryListViewModel CategoryList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CategoryListViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}