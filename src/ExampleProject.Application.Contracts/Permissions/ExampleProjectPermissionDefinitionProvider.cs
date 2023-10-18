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
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ExampleProjectResource>(name);
    }
}
