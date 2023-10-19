using ExampleProject.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ExampleProject.Permissions;

public class ExampleProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(ExampleProjectPermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookStoreGroup.AddPermission(ExampleProjectPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(ExampleProjectPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(ExampleProjectPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(ExampleProjectPermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = bookStoreGroup.AddPermission(
            ExampleProjectPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            ExampleProjectPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            ExampleProjectPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
            ExampleProjectPermissions.Authors.Delete, L("Permission:Authors.Delete"));

        var comicBooksPermission = bookStoreGroup.AddPermission(
    ExampleProjectPermissions.ComicBooks.Default, L("Permission:ComicBooks"));
        comicBooksPermission.AddChild(
            ExampleProjectPermissions.ComicBooks.Create, L("Permission:ComicBooks.Create"));
        comicBooksPermission.AddChild(
            ExampleProjectPermissions.ComicBooks.Edit, L("Permission:ComicBooks.Edit"));
        comicBooksPermission.AddChild(
            ExampleProjectPermissions.ComicBooks.Delete, L("Permission:ComicBooks.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ExampleProjectResource>(name);
    }
}
