using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TubesKPL_KitaBelajar.Model;

namespace TubesKPL_KitaBelajar.Services
{
    public interface IAuthService
    {
        bool Login(User user);
    }
}
