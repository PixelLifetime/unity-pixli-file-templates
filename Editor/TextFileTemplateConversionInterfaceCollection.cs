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

using Random = PixLi.RandomDistribution.Random;

namespace PixLi
{
#if UNITY_EDITOR
	public partial class TextFileTemplateConversionInterfaceCollection
	{
		/// <summary>
		/// C#'s Script Icon [The one MonoBhevaiour Scripts have].
		/// </summary>
		private static readonly Texture2D s_scriptIcon = (EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D);

		[MenuItem("Assets/Create//Script Templates/Advanced C# Script", false, 80)]
		private static void CreateScriptTemplatesAdvancedCScript()
		{
			if (TextFileTemplateConverter.TryGetTemplatePath("80_Script Templates_Advanced C# Script_NewAdvancedBehaviourScript.cs", out string templatePath))
			{
				TextFileTemplateConverter.Convert(
					"NewAdvancedBehaviourScript.cs",
					templatePath,
					s_scriptIcon
				);
			}
		}

		[MenuItem("Assets/Create//Script Templates/Common C# Script", false, 80)]
		private static void CreateScriptTemplatesCommonCScript()
		{
			if (TextFileTemplateConverter.TryGetTemplatePath("80_Script Templates_Common C# Script_NewCommonBehaviourScript.cs", out string templatePath))
			{
				TextFileTemplateConverter.Convert(
					"NewCommonBehaviourScript.cs",
					templatePath,
					s_scriptIcon
				);
			}
		}

		[MenuItem("Assets/Create//Script Templates/Extensions", false, 81)]
		private static void CreateScriptTemplatesExtensions()
		{
			if (TextFileTemplateConverter.TryGetTemplatePath("81_Script Templates_Extensions_Extensions.cs", out string templatePath))
			{
				TextFileTemplateConverter.Convert(
					"Extensions.cs",
					templatePath,
					s_scriptIcon
				);
			}
		}

		[MenuItem("Assets/Create//Script Templates/Utility", false, 81)]
		private static void CreateScriptTemplatesUtility()
		{
			if (TextFileTemplateConverter.TryGetTemplatePath("81_Script Templates_Utility_Utility.cs", out string templatePath))
			{
				TextFileTemplateConverter.Convert(
					"Utility.cs",
					templatePath,
					s_scriptIcon
				);
			}
		}

		[MenuItem("Assets/Create//Script Templates/Views/View", false, 81)]
		private static void CreateScriptTemplatesViewsView()
		{
			if (TextFileTemplateConverter.TryGetTemplatePath("81_Script Templates_Views_View_UserInterfaceView.cs", out string templatePath))
			{
				TextFileTemplateConverter.Convert(
					"UserInterfaceView.cs",
					templatePath,
					s_scriptIcon
				);
			}
		}

		[MenuItem("Assets/Create//Script Templates/Class Attribute", false, 82)]
		private static void CreateScriptTemplatesClassAttribute()
		{
			if (TextFileTemplateConverter.TryGetTemplatePath("82_Script Templates_Class Attribute_Attribute.cs", out string templatePath))
			{
				TextFileTemplateConverter.Convert(
					"Attribute.cs",
					templatePath,
					s_scriptIcon
				);
			}
		}

		[MenuItem("Assets/Create//Script Templates/Multi Support Property Attribute", false, 82)]
		private static void CreateScriptTemplatesMultiSupportPropertyAttribute()
		{
			if (TextFileTemplateConverter.TryGetTemplatePath("82_Script Templates_Multi Support Property Attribute_Attribute.cs", out string templatePath))
			{
				TextFileTemplateConverter.Convert(
					"Attribute.cs",
					templatePath,
					s_scriptIcon
				);
			}
		}
	}
#endif
}