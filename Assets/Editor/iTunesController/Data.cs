using UnityEditor;
using UnityEngine;

namespace Anz.Editor.iTunes
{
	public class Data : ScriptableObject
	{
		public bool needsAutoPlay = false;

		public static void Create()
		{
			var data = CreateInstance<Data>();
			data.needsAutoPlay = false;
			AssetDatabase.CreateAsset(data, Settings.File.Data.AssetPath());
			AssetDatabase.Refresh();
		}
	}
}