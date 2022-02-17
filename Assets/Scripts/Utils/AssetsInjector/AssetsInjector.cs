using System;
using System.Reflection;

public static class AssetsInjector
{
    private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);
    public static T Inject<T>(this AssetsContext context, T target)
    {
        var targetType = target.GetType();
        var allFields = targetType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

        foreach (var fieldInfo in allFields)
        {
            var injectAssetAttribute = fieldInfo.GetCustomAttribute(_injectAssetAttributeType) as InjectAssetAttribute;
            if (injectAssetAttribute == null)
                continue;

            var objectTolnject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetAttribute.AssetName);
            fieldInfo.SetValue(target, objectTolnject);
        }

        return target;
    }
}
