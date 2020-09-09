namespace Domain
{
    public static class CurrentUser
    {
        private static int id;

        public static void SetUserId(int userid)
        {
            id = userid;
        }

        public static int GetUserId()
        {
            return id;
        }
    }
}