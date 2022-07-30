using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PixLi
{
#if UNITY_EDITOR
	public static class TextFileTemplateConversionInterfaceCreator
	{
		private const string TEXT_FILE_EXTENSION = ".txt";
		private const string TEXT_FILE_TEMPLATE_CONVERTED_COLLECTION_FILE_NAME = "TextFileTemplateConversionInterfaceCollection.cs";

		public static void Create()
		{
			DirectoryInfo directoryInfo = Directory.CreateDirectory(
				Path.Combine(PathUtility.ASSETS_PATH_NAME, PathUtility.GetScriptFileDirectoryPath())
			);

			using (StreamWriter streamWriter = new StreamWriter(
				Path.Combine(
					directoryInfo.FullName,
					"Editor",
					TextFileTemplateConversionInterfaceCreator.TEXT_FILE_TEMPLATE_CONVERTED_COLLECTION_FILE_NAME
				)))
			{
				string fORMAT = $@"/* Created by Max.K.Kimo */

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.UIElements;

using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

using Kimo.Assistance;
using Kimo.Assistance.UTILITY;

using Random = Kimo.Core.RandomDistribution.Random;

#if UNITY_EDITOR
public partial class TextFileTemplateConversionInterfaceCollection
{{{{
	/// <summary>
	/// C#'s Script Icon [The one MonoBhevaiour Scripts have].
	/// </summary>
	private static readonly Texture2D s_scriptIcon = (EditorGUIUtility.IconContent(""cs Script Icon"").image as Texture2D);{{0}}
}}}}
#endif
";
				FileInfo[] files = directoryInfo.GetFiles($"*{TextFileTemplateConversionInterfaceCreator.TEXT_FILE_EXTENSION}");

				StringBuilder generatedConversionInterfaces = new StringBuilder(files.Length);

				string template = $@"

	[MenuItem(""Assets/Create/{{0}}"", false, {{1}})]
	private static void Create{{2}}()
	{{{{
		if (TextFileTemplateConverter.TryGetTemplatePath(""{{3}}"", out string templatePath))
		{{{{
			TextFileTemplateConverter.Convert(
				""{{4}}"",
				templatePath,
				s_scriptIcon
			);
		}}}}
	}}}}";

				string[] restrictedMethodNamingSymbols = new string[] { " ", "#", "$", "%", "^", "/", "\\", ";", ",", "*", "\r", "\t", "\n" };

				for (int a = 0; a < files.Length; a++)
				{
					string[] splitFileName = files[a].Name.Split('_');

					string[] templateDefinitions = new string[5]
					{
						string.Empty, // Template name in asset menu. Constructed below.
						splitFileName[0], // Template order in asset menu.
						string.Empty, // Template creation method name.
						Path.GetFileNameWithoutExtension(files[a].Name), // Template full name in project folder.
						Path.GetFileNameWithoutExtension(splitFileName[splitFileName.Length - 1]) // Template default name during creation.
					};

					// Construction of template name in asset menu.
					for (int b = 1; b < splitFileName.Length - 1; b++)
					{
						templateDefinitions[0] = $"{templateDefinitions[0]}{Path.AltDirectorySeparatorChar}{splitFileName[b]}";
						templateDefinitions[2] += splitFileName[b];
					}

					//// Remove empty chars.
					//templateDefinitions[2] = templateDefinitions[2].Replace(' ', char.MinValue);

					// Remove empty strings.
					templateDefinitions[2] = templateDefinitions[2].Replace(restrictedMethodNamingSymbols, string.Empty);

					generatedConversionInterfaces.Append(
						string.Format(
							template,
							templateDefinitions
						)
					);
				}

				streamWriter.Write(
					string.Format(
						fORMAT,
						generatedConversionInterfaces
					)
				);
			}


			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
	}
#endif
}