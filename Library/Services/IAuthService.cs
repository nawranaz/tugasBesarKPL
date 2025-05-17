using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesKPL_KitaBelajar.Library.Model;


namespace TubesKPL_KitaBelajar.Library.Services
{
    public interface IAuthService
    {
        bool Login(User user);
    }
}
