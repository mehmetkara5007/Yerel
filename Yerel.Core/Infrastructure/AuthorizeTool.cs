using System.Collections.Generic;

namespace Yerel.Core.Infrastructure
{
    public class AuthorizeTool
    {
        public static bool Authorize(int actionId)
        {
            return new List<int> {2, 15, 147, 58, 3, 5, 8, 9}.Contains(actionId);
        }
    }
}
