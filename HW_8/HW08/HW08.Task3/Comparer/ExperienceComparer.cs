using HW08.Task3.Contracts;
using System.Collections.Generic;

namespace HW08.Task3
{
    class ExperienceComparer : IComparer<IEngineer>
    {
        public int Compare(IEngineer x, IEngineer y)
        {
            if (x.CurrentPositioin < y.CurrentPositioin)
            {
                return -1;
            }
            else if (x.CurrentPositioin > y.CurrentPositioin)
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }
    }
}
