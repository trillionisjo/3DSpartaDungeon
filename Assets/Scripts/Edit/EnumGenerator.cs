using UnityEditor;
using System.IO;
using System.Linq;
using System.Text;

class EnumGenerator {
    [MenuItem("Tools/Generate AudioFileNameEnum")]
    public static void GeneratePrefabEnum() {
        string[] prefabPaths = AssetDatabase.FindAssets("t:AudioClip", new[] { "Assets/Resources/Audios" })
            .Select(AssetDatabase.GUIDToAssetPath)
            .ToArray();

        StringBuilder enumBuilder = new StringBuilder();
        enumBuilder.AppendLine("public enum AudioFileName");
        enumBuilder.AppendLine("{");

        for (int i = 0; i < prefabPaths.Length; i++) {
            string prefabName = Path.GetFileNameWithoutExtension(prefabPaths[i]);
            enumBuilder.AppendLine($"    {prefabName} = {i},");
        }

        enumBuilder.AppendLine("}");

        string enumFilePath = "Assets/Scripts/Audio/AudioFileNameEnum.cs";
        File.WriteAllText(enumFilePath, enumBuilder.ToString());
        AssetDatabase.Refresh();
    }
}