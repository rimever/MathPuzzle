namespace MathPuzzle;

public static class ListExtension
{
    /// <summary>
    /// 配列から組み合わせを取得する
    /// </summary>
    /// <param name="self"></param>
    /// <param name="n"></param>
    /// <typeparam name="T"></typeparam>
    /// <remarks>https://baba-s.hatenablog.com/entry/2019/12/04/124000</remarks>
    /// <returns></returns>
    public static IEnumerable<List<T>> Combination<T>( this IList<T> self, int n )
    {
        return Enumerable.Range( 0, n - 1 )
            .Aggregate(
                Enumerable.Range( 0, self.Count - n + 1 )
                    .Select( num => new List<int> { num } ),
                ( list, _ ) => list.SelectMany(
                    c =>
                        Enumerable.Range( c.Max() + 1, self.Count - c.Max() - 1 )
                            .Select( num => new List<int>( c ) { num } )
                )
            )
            .Select(
                c => c
                    .Select( num => self[ num ] )
                    .ToList()
            );
    }
}