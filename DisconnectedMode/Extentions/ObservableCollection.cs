using System.Collections.ObjectModel;

namespace DisconnectedMode.Extentions;

public static class ObservableCollectionExtension
{
    public static async Task<ObservableCollection<T>> ToObservableCollectionAsync<T>(this IEnumerable<T> enumerable) {
        var col = new ObservableCollection<T>();

        foreach (var cur in enumerable ) {
            col.Add(cur);
        }

        return col;
    }
}