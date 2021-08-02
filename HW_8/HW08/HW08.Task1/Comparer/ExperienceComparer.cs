using System.Collections.Generic;

namespace HW08.Task1
{
    class ExperienceComparer : IComparer<Engineer>
    {
        public int Compare(Engineer x, Engineer y)
        {
            if (x.Experience < y.Experience)
            {
                return -1;
            }
            else if (x.Experience > y.Experience)
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
