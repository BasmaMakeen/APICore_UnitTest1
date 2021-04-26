using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    interface BaseRepos<T>
    {
        T Add(T data);
        List<T> GetALL();
        T Getbyid(int id);
        bool Delete(int id);
        T Edit(T data);
     
    }
}
