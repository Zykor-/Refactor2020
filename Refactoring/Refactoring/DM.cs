using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring
{
    public interface DM
    {
        void AddOption(String add);
        void DisplayMenu();
        int Select();
        void ChangeHeader(String change);
    }
}
