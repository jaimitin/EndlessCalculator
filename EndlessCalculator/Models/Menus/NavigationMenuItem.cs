using EndlessCalculator.Attributes;
using Microsoft.Maui.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EndlessCalculator.Models.Menu
{
    public interface INavigationMenuItem : IMenuItem
    {
        INavigationMenuItem? Parent { get; set; }
        Type? Target { get; }
        ObservableCollection<INavigationMenuItem> Children { get; }
    }

    public class NavigationMenuItem<TTarget> : MenuItem, ICollection<INavigationMenuItem>, INavigationMenuItem where TTarget : class, new()
    {
        private INavigationMenuItem? _parent;

        public NavigationMenuItem()
        {
        }

        public NavigationMenuItem(string text)
        {
            Text = text;
        }

        public NavigationMenuItem(string text, ImageSource icon)
        {
            Text = text;
            Icon = icon;
        }

        public INavigationMenuItem? Parent
        {
            get => _parent;
            set => Set(ref _parent, value);
        }

        public Type? Target { get; } = typeof(TTarget);

        public ObservableCollection<INavigationMenuItem> Children { get; } = new ObservableCollection<INavigationMenuItem>();

        [DependsOn(nameof(Parent))]
        public bool IsRoot => Parent is null;

        [DependsOn(nameof(Children))]
        public bool HasChildren => Children.Any();


        #region ICollection

        public int Count => Children.Count;

        public bool IsReadOnly => false;

        public void Add(INavigationMenuItem item)
        {
            item.Parent = this;

            Children.Add(item);

            OnPropertyChanged(nameof(HasChildren));
        }

        public void Clear()
        {
            Children.Clear();

            OnPropertyChanged(nameof(HasChildren));
        }

        public bool Contains(INavigationMenuItem item) => Children.Contains(item);

        public void CopyTo(INavigationMenuItem[] array, int arrayIndex) => Children.CopyTo(array, arrayIndex);

        public bool Remove(INavigationMenuItem item)
        {
            bool removed = Children.Remove(item);

            if (removed)
            {
                OnPropertyChanged(nameof(HasChildren));
            }

            return removed;
        }

        public IEnumerator<INavigationMenuItem> GetEnumerator() => Children.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();

        #endregion

    }

    public class NavigationMenuItem : NavigationMenuItem<object>
    {
        public NavigationMenuItem()
        {
        }

        public NavigationMenuItem(string text) : base(text)
        {
        }

        public NavigationMenuItem(string text, ImageSource icon) : base(text, icon)
        {
        }

        public new Type? Target { get; } = null;
    }
}
