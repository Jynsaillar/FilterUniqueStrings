using System.Collections.Generic;

namespace FilterUniqueStrings.BusinessLogic
{
    public static class Filtering
    {
        public static string[] FilterUniques(string[] keywords)
        {
            HashSet<string> filteredSet = new HashSet<string>(keywords);
            string[] result = new string[filteredSet.Count];
            filteredSet.CopyTo(result);
            return result;
        }

        public static string JoinStrings(string[] strings)
        {
            return string.Join("\n", strings);
        }
    }
}
