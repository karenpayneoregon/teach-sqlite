#nullable disable
using System.ComponentModel;
#pragma warning disable IDE0044

namespace SampleApp1.Classes;
public class BindingListView<T> : BindingList<T>, IBindingListView, IRaiseItemChangedEvents
{
    private bool _sorted = false;
    private bool _isFiltered = false;
    private string _filterString = null;
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;
    private PropertyDescriptor _sortProperty = null;
    private ListSortDescriptionCollection _sortDescriptions = [];
    private List<T> _originalCollection = [];

    public BindingListView() : base()
    {
    }

    public BindingListView(List<T> list) : base(list)
    {
    }

    protected override bool SupportsSearchingCore => true;

    protected override int FindCore(PropertyDescriptor property,
    object key)
    {
        // Simple iteration:
        for (int index = 0; index < Count; index++)
        {
            T item = this[index];
            if (property.GetValue(item).Equals(key))
            {
                return index;
            }
        }
        return -1; // Not found
        
    }

    protected override bool SupportsSortingCore => true;
    protected override bool IsSortedCore => _sorted;
    protected override ListSortDirection SortDirectionCore => _sortDirection;
    protected override PropertyDescriptor SortPropertyCore => _sortProperty;

    protected override void ApplySortCore(PropertyDescriptor property,
      ListSortDirection direction)
    {
        _sortDirection = direction;
        _sortProperty = property;
        SortComparer<T> comparer = new SortComparer<T>(property, direction);
        ApplySortInternal(comparer);
    }

    private void ApplySortInternal(SortComparer<T> comparer)
    {
        if (_originalCollection.Count == 0)
        {
            _originalCollection.AddRange(this);
        }

        List<T> listRef = this.Items as List<T>;

        if (listRef == null)
        {
            return;
        }

        listRef.Sort(comparer);
        _sorted = true;
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }

    protected override void RemoveSortCore()
    {
        if (!_sorted)
        {
            return;
        }

        Clear();

        foreach (T item in _originalCollection)
        {
            Add(item);
        }

        _originalCollection.Clear();
        _sortProperty = null;
        _sortDescriptions = null;
        _sorted = false;
    }

    void IBindingListView.ApplySort(ListSortDescriptionCollection sorts)
    {
        _sortProperty = null;
        _sortDescriptions = sorts;
        SortComparer<T> comparer = new SortComparer<T>(sorts);
        ApplySortInternal(comparer);
    }

    string IBindingListView.Filter
    {
        get
        {
            return _filterString;
        }
        set
        {
            _filterString = value;
            _isFiltered = true;
            UpdateFilter();
        }
    }

    void IBindingListView.RemoveFilter()
    {
        if (!_isFiltered)
        {
            return;
        }

        _filterString = null;
        _isFiltered = false;
        _sorted = false;
        _sortDescriptions = null;
        _sortProperty = null;

        Clear();

        foreach (T item in _originalCollection)
        {
            Add(item);
        }

        _originalCollection.Clear();

    }
    ListSortDescriptionCollection IBindingListView.SortDescriptions
    {
        get => _sortDescriptions;
    }

    bool IBindingListView.SupportsAdvancedSorting => true;

    bool IBindingListView.SupportsFiltering => true;

    public void RemoveFilter()
    {
        ((IBindingListView)this).RemoveFilter();
    }
    protected virtual void UpdateFilter()
    {
        if (_filterString == null)
        {
            ((IBindingListView)this).RemoveFilter();
            return;
        }

        int equalsPos = _filterString.IndexOf('=');

        // Get property name
        string propName = _filterString.Substring(0, equalsPos).Trim();

        // Get filter criteria
        string criteria = _filterString.Substring(equalsPos + 1, _filterString.Length - equalsPos - 1).Trim();

        // Strip leading and trailing quotes
        criteria = criteria.Substring(1, criteria.Length - 2);

        // Get a property descriptor for the filter property
        PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[propName];

        if (_originalCollection.Count == 0)
        {
            _originalCollection.AddRange(this);
        }

        List<T> currentCollection = [..this];

        Clear();

        foreach (T item in currentCollection)
        {
            object value = propDesc.GetValue(item);
            if (value.ToString() == criteria)
            {
                Add(item);
            }
        }
    }

    bool IBindingList.AllowNew => CheckReadOnly();

    bool IBindingList.AllowRemove => CheckReadOnly();

    private bool CheckReadOnly()
    {
        if (_sorted || _isFiltered)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected override void InsertItem(int index, T item)
    {
        foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(item))
        {
            if (propDesc.SupportsChangeEvents)
            {
                propDesc.AddValueChanged(item, OnItemChanged);
            }
        }
        base.InsertItem(index, item);
    }

    protected override void RemoveItem(int index)
    {
        T item = Items[index];
        PropertyDescriptorCollection propDescs = TypeDescriptor.GetProperties(item);

        foreach (PropertyDescriptor propDesc in propDescs)
        {
            if (propDesc.SupportsChangeEvents)
            {
                propDesc.RemoveValueChanged(item, OnItemChanged);
            }
        }
        base.RemoveItem(index);
    }

    void OnItemChanged(object sender, EventArgs args)
    {
        int index = Items.IndexOf((T)sender);
        OnListChanged(new ListChangedEventArgs(
          ListChangedType.ItemChanged, index));
    }

    bool IRaiseItemChangedEvents.RaisesItemChangedEvents => true;
}

class SortComparer<T> : IComparer<T>
{
    private ListSortDescriptionCollection _sortCollection = null;
    private PropertyDescriptor _propertyDescriptor = null;
    private ListSortDirection _direction = ListSortDirection.Ascending;

    public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
    {
        _propertyDescriptor = propDesc;
        _direction = direction;
    }

    public SortComparer(ListSortDescriptionCollection sortCollection)
    {
        _sortCollection = sortCollection;
    }

    int IComparer<T>.Compare(T x, T y)
    {
        if (_propertyDescriptor != null) // Simple sort
        {
            object xValue = _propertyDescriptor.GetValue(x);
            object yValue = _propertyDescriptor.GetValue(y);

            return CompareValues(xValue, yValue, _direction);

        }
        else if (_sortCollection != null && _sortCollection.Count > 0)
        {
            return RecursiveCompareInternal(x, y, 0);
        }
        else return 0;
    }

    private int CompareValues(object xValue, object yValue, ListSortDirection direction)
    {

        int retValue = 0;
        if (xValue is IComparable)
        {
            retValue = ((IComparable)xValue).CompareTo(yValue);
        }
        else if (yValue is IComparable)
        {
            retValue = ((IComparable)yValue).CompareTo(xValue);
        }
        // not comparable, compare String representations
        else if (!xValue.Equals(yValue))
        {
            retValue = xValue.ToString().CompareTo(yValue.ToString());
        }
        if (direction == ListSortDirection.Ascending)
        {
            return retValue;
        }
        else
        {
            return retValue * -1;
        }
    }

    private int RecursiveCompareInternal(T x, T y, int index)
    {
        if (index >= _sortCollection.Count)
        {
            return 0; // termination condition
        }

        ListSortDescription listSortDesc = _sortCollection[index];

        object xValue = listSortDesc.PropertyDescriptor.GetValue(x);
        object yValue = listSortDesc.PropertyDescriptor.GetValue(y);

        int retValue = CompareValues(xValue, yValue, listSortDesc.SortDirection);
        if (retValue == 0)
        {
            return RecursiveCompareInternal(x, y, ++index);
        }
        else
        {
            return retValue;
        }
    }
}