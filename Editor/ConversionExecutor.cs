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
	public class ConversionExecutor : ScriptableObjectSingleton<ConversionExecutor>
	{
		public void Execute()
		{
			TextFileTemplateConversionInterfaceCreator.Create();
		}

		protected override string GetInstanceDirectoryPath() => PathUtility.GetScriptFileDirectoryPath();

		[CustomEditor(typeof(ConversionExecutor)), CanEditMultipleObjects]
		public class ConversionExecutorEditor : MultiSupportEditor
		{
			private ConversionExecutor _tConversionExecutor;

			public override void OnEnable()
			{
				base.OnEnable();

				this._tConversionExecutor = this.target as ConversionExecutor;
			}

			public override void MainDrawGUI()
			{
				this.DrawDefaultInspector();

				if (GUILayout.Button("Convert"))
				{
					this._tConversionExecutor.Execute();
				}
			}
		}
	}
#endif
}