using UnityEditor;
using UnityEngine;

namespace Anz.Editor.iTunes
{
	public class Config : ScriptableObject
	{
		public bool needsAutoPlay = false;

		public static void Create()
		{
			var config = CreateInstance<Config>();
			config.needsAutoPlay = false;
			AssetDatabase.CreateAsset(config, Settings.File.Config.AssetPath());
			AssetDatabase.Refresh();
		}
	}
}