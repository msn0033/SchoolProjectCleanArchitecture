using SchoolProject.Infrustructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Interface.Views
{
    public interface IViewRepository<T>:IGenericRepositoryAsync<T> where T:class
    {
    }
}
