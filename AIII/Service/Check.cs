namespace AIII.Service
{
    public static class Check
    {
        public static bool IsImdb(string id)
        {
            if (id.StartsWith("aaa"))
                return false;
            return true;
        }
    }
}