using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appcess_dev.Models
{
    public interface IEntity
    {
        string Name { get; set; }
        string Path { get; set; }
        DateTime? LastAccessTime { get; set; }
    }
}
