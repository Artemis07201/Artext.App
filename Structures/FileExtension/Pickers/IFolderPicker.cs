using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artext.Structures.FileExtension.Pickers
{
    public interface IFolderPicker
    {
        Task<string?> PickFolder();
    }
}
