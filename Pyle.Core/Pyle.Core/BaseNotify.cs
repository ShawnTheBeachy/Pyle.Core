using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pyle.Core
{
    public class BaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raise a PropertyChanged event.
        /// </summary>
        /// <param name="propName"></param>
        public void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Set the property and raise a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public bool Set<T>(ref T storage, T value, [CallerMemberName()]string propertyName = null, bool allowNull = true)
        {
            if (!allowNull && value == null)
                return false;

            if (!Equals(storage, value))
            {
                storage = value;
                RaisePropertyChanged(propertyName);
                return true;
            }

            return false;
        }
    }
}
