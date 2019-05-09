using System;

namespace Contracts.DAL.Base
{
    // int based interface for entity meta fields
    public interface IBaseEntity : IBaseEntity<int>
    {
        
    }
    
    public interface IBaseEntity<TKey>
        where TKey : IComparable
    {
        TKey Id { get; set; }
    }
}
