using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Prime_Numbers
{
    class VM : INotifyPropertyChanged
    {
        /* binding code for the list box*/
        public List<int> AllPrimes
        {
            get { return _allPrimes; }
            set { _allPrimes = value; OnPropertyChanged(); }
        }
        /* declare allPrimes list variable */
        private List<int> _allPrimes;

        /* test all numbers between 1 and 100 to find prime numbers, excluding 1 as a prime number must be greater than 1 */
        public VM()
        {
            _allPrimes = new List<int>();
            int MIN_VALUE = 2;
            int MAX_VALUE = 100;
            for (int i = MIN_VALUE; i <= MAX_VALUE; i++)
            {
                /* call IsPrime function */
                if (IsPrime(i))
                {
                    _allPrimes.Add(i);
                }
            }
        }

        /* function that actually tests if number is prime */
        private bool IsPrime(int testNumber)
        {
            bool functionResult = true;
            for (int j = 2; j <= Math.Sqrt(testNumber); j++)
            {
                if (testNumber % j == 0)
                {
                    functionResult = false;
                    break;
                }
            }
            return functionResult;
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
        #endregion

    }
}
