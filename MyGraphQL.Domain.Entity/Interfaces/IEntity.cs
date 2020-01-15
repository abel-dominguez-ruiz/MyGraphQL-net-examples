using System;
using System.Collections.Generic;
using System.Text;

namespace MyGraphQL.Domain.Entity.Interfaces
{
    public interface IEntity<T> 
    {
        T Id { get; set; }
    }
}
