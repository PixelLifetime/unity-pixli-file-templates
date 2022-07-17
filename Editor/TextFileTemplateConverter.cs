using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
#endif

namespace PixLi
{
#if UNITY_EDITOR
	public static class TextFileTemplateConverter
	{
		internal static Object Convert(string pathName, string templatePath)
		{
			string className = Path.GetFileNameWithoutExtension(pathName).Replace(" ", string.Empty);
			string templateText = string.Empty;

			UTF8Encoding encoding = new UTF8Encoding(true, false);

			if (File.Exists(templatePath))
			{
				// Read template.

				StreamReader reader = new StreamReader(templatePath);
				templateText = reader.ReadToEnd();
				reader.Close();

				templateText = templateText
					.Replace("#SCRIPTNAME#", className)
					.Replace("#NOTRIM#", string.Empty)
					.Replace("    ", "\t");
				// Add new custom Tags here...

				// Write file.

				StreamWriter writer = new StreamWriter(Path.GetFullPath(pathName), false, encoding);
				writer.Write(templateText);
				writer.Close();

				AssetDatabase.ImportAsset(pathName);

				return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
			}
			else
				Debug.LogError(string.Format("The template file was not found: {0}", templatePath));

			return null;
		}

		public static void Convert(string name, string templatePath, Texture2D icon)
		{
			ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
				0,
				ScriptableObject.CreateInstance<TextFileTemplateConversionEndNameEditAction>(),
				name,
				icon,
				templatePath
			);
		}

		public static bool TryGetTemplatePath(string templateName, out string templatePath)
		{
			string[] guids = AssetDatabase.FindAssets(templateName);
			if (guids.Length == 0)
			{
				Debug.LogWarning($"{templateName}.txt not found in AssetDatabase.");

				templatePath = null;

				return false;
			}

			templatePath = AssetDatabase.GUIDToAssetPath(guids[0]);

			return true;
		}

		internal class TextFileTemplateConversionEndNameEditAction : EndNameEditAction
		{
			public override void Action(int instanceId, string pathName, string resourceFile)
			{
				Object script = TextFileTemplateConverter.Convert(pathName, resourceFile);
				ProjectWindowUtil.ShowCreatedAsset(script);
			}
		}
	}
#endif
}