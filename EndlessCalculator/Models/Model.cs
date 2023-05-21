using EndlessCalculator.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EndlessCalculator.Models
{
    public abstract class Model : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event PropertyChangingEventHandler? PropertyChanging;

        protected readonly Dictionary<string, List<string>> Dependencies = new();

        protected Model()
        {
            foreach (PropertyInfo property in GetType().GetProperties())
            {
                foreach (DependsOnAttribute attr in property.GetCustomAttributes<DependsOnAttribute>())
                {
                    if (attr != null)
                    {
                        string dependency = attr.Dependency;

                        if (!Dependencies.ContainsKey(dependency))
                        {
                            Dependencies.Add(dependency, new List<string>());
                        }

                        Dependencies[dependency].Add(property.Name);
                    }
                }
            }
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null, Action? onChanging = null, Action? onChanged = null, Func<T, T, bool>? validator = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            if (validator != null && !validator(field, value))
            {
                return false;
            }

            onChanging?.Invoke();
            OnPropertyChanging(propertyName);

            field = value;

            onChanged?.Invoke();
            OnPropertyChanged(propertyName);

            return true;
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (Dependencies.TryGetValue(propertyName ?? "", out List<string>? dependecies))
            {
                foreach (string dependency in dependecies)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(dependency));
                }
            }
        }

        protected virtual void OnPropertyChanging([CallerMemberName] string? propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
