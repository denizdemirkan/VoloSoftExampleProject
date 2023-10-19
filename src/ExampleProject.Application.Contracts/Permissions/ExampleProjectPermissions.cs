namespace ExampleProject.Permissions;

public static class ExampleProjectPermissions
{
    public const string GroupName = "BookStore";

    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class ComicBooks
    {
        public const string Default = GroupName + ".ComicBooks";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}