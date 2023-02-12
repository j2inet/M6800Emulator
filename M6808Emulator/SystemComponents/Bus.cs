using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace M6808Emulator.SystemComponents
{
    public class BusUpdatedEventArgs<T>:EventArgs where T:notnull
    {
        public BusUpdatedEventArgs(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }
    }

    public delegate void BusUpdatedEventHandler<T>(object sender, BusUpdatedEventArgs<T> args) where T : notnull;

    public  class Bus<T> where T : notnull
    {
        T _data;

        public event  BusUpdatedEventHandler<T> BusUpdated;

        protected void OnBusUpdated(T newValue)
        {
            if(BusUpdated != null)
            {
                BusUpdated(this, new BusUpdatedEventArgs<T>(newValue));
            }
        }

        public T Data
        {  
            get => _data; 
            set 
            {
                _data = value;
                OnBusUpdated(_data);
            }
        }
    }
}
