using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication6.Model;
namespace WebApplication6.Auth
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
